public class Solution {
    public int MinMutation(string start, string end, string[] bank) {
        
        // Base case: One or more of the strings are null or empty.
        // Moreover, if bank is empty, no mutations are valid at all.
        // Moreover, if the start and end genes are different in length, then it is an issue.
        // Lastly, if bank does not contain the end result, then it is an issue.
        if (string.IsNullOrEmpty(start) || string.IsNullOrEmpty(end) || bank.Length == 0 || start.Length != end.Length || !bank.Contains(end)) {
            return -1;
        }
        
        // Trivial case: start and end require no mutation, and is in the bank.
        if (start.Equals(end) && bank.Contains(end)) {
            return 1;
        }
        
        // Counter
        var count = 0;
        
        // endDiff will be useful in going backwards from the result string.
        var endDiff = new int[bank.Length];
        
        // O(n * b)
        GenerateDifferences(endDiff, end, bank);

        // O(n) - mapped the differences to each bank entry of endDiffs
        // Excluding the end string, itself.
        var bankDict = new Dictionary<string, int>();
        for (int m = 0; m < bank.Length; m++) {
            if (!bankDict.ContainsKey(bank[m]) && bank[m] != end) {
                bankDict.Add(bank[m], endDiff[m]);
            }
        }
        
        // BFS data structure using a queue
        var queue = new Queue<string>();
        var visited = new HashSet<string>();
        queue.Enqueue(end);
        
        // NOTE: All differences are referenced against the end string.
        // Therefore, at each step, we get closer to start
        var currStr = end;
        var foundOne = false;
        // O(b) at most, since we only queue valid case nodes.
        // This complexity is still smaller than O(n*b);
        
        while (true) {
            var qCount = queue.Count;

            // O(n)
            if (FindDifference(start, currStr) == 1) {
                foundOne = true;
                break;
            }
            
            if (foundOne) {
                count++;
                foundOne = false;
            }
            
            if (qCount == 0) {
                break;
            }
            
            // O(b) at most.
            while (qCount > 0) {
                currStr = queue.Dequeue();
                qCount--;
                          
                if (bankDict.ContainsKey(currStr)) {
                    bankDict.Remove(currStr);
                }
                
                // This gradually shrinks, as we find paths.
                // Therefore, we do not need to repeat and revisit old paths.
                // O(b*n) at most
                foreach (var kvp in bankDict) {
                    if (!visited.Contains(kvp.Key)) {                       
                        var diff = FindDifference(kvp.Key, currStr);
                        if (diff == 1) {
                            queue.Enqueue(kvp.Key);
                            visited.Add(kvp.Key);
                            foundOne = true;                            
                        }
                    }
                }              
            }
        }
        
        // Since it is guaranteed that once you get here, the end string is included in the bank.
        // It was not counted during the loop.
        if (foundOne) {
            count++;    
        }
        
        if (count == 0) {
            return -1;
        }
        
        return count;
    }
    
    // O(n*b)
    private void GenerateDifferences(int[] diffArr, string start, string[] bank) {        
        for (int i = 0; i < start.Length; i++) {
            for (int j = 0; j < bank.Length; j++) {
                if (!start[i].Equals(bank[j][i])) {
                    diffArr[j]++;
                }
            }
        }
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