public class Solution {
    public int MinMutation(string start, string end, string[] bank) {
        
        var bankSet = new HashSet<string>(bank);
        
        // Base case: One or more of the strings are null or empty.
        // Moreover, if bank is empty, no mutations are valid at all.
        // Moreover, if the start and end genes are different in length, then it is an issue.
        // Lastly, if bank does not contain the end result, then it is an issue.
        if (string.IsNullOrEmpty(start) || string.IsNullOrEmpty(end) || bankSet.Count == 0 || start.Length != end.Length || !bankSet.Contains(end)) {
            return -1;
        }
        
        // Trivial case: start and end require no mutation, and is in the bank.
        if (start.Equals(end) && bankSet.Contains(end)) {
            return 1;
        }

        // Contains diffs that are 1 change away from the end.
        var endDiff = GenerateDifferences(end, bank);
        
        // BFS Data structures
        var queue = new Queue<string>();
        var visited = new HashSet<string>();
        
        queue.Enqueue(start);
        visited.Add(start);
        var level = 0;
        
        // BFS, or level order traversal.
        // Overall O(b^2 * n)
        while (queue.Count != 0) {
            var qCount = queue.Count;
            level++;
            
            while (qCount > 0) {
                var currStr = queue.Dequeue();
                
                // Termination case 1: When we have a string that is 1 change away from the end
                // O(1) because we are using a set
                if (endDiff.Contains(currStr)) {
                    return level;
                }
                
                // Remove this from the set so we do not have to iterate over it again.
                bankSet.Remove(currStr);
                
                // O(b), which is continously shrinking.
                foreach (var word in bankSet) {
                    if (!visited.Contains(word)) {
                        // O(n)
                        var pathDiff = FindDifference(word, currStr);
                        if (pathDiff == 1) {
                            // Termination case 2: When we have the actual end string.
                            if (word.Equals(end)) {
                                return level;
                            }
                            queue.Enqueue(word);
                            visited.Add(word);
                        }
                    }      
                }  
                qCount--;
            }
        }     
        return -1;
    }
    
    // O(n*b)
    private HashSet<string> GenerateDifferences(string end, string[] bank) {        
        var diffSet = new HashSet<string>();
        foreach (var gene in bank) {
            var diff = FindDifference(end, gene);
            if (diff == 1) {
                diffSet.Add(gene);
            }
        }
        
        return diffSet;
        
    }
    
    // O(n) complexity, since its a single scan of both strings at the same time
    private int FindDifference(string s1, string s2) {
        int diff = 0;        
        for (int i = 0; i < s1.Length; i++) {
            if (!s1[i].Equals(s2[i])) {
                diff++;
            }
        }
        return diff;
    }
}