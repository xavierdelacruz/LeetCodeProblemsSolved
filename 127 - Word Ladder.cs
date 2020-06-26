public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        
        var wordSet = new HashSet<string>(wordList);

        // Base case: If the endWord is not included in the expected list of transitions
        // Transitions also include the final state.
        if (!wordSet.Contains(endWord)) {
            return 0;
        }
        
        // Both O(n*w) time, and O(w) space.  
        var endDiff = GenerateEndDiff(wordList, endWord);
        var currStr = beginWord;
        var visited = new HashSet<string>();
        var queue = new Queue<string>();
        queue.Enqueue(beginWord);
        visited.Add(beginWord);
        var level = 1;
        
        // Overall O(w^2 * n)        
        while (queue.Count != 0) {
            var qCount = queue.Count;
            level++;
            
            
            // O(w) at most, if we end up queueing the entire wordList
            while (qCount > 0) {
                currStr = queue.Dequeue();       
                
                // O(1), since it is a set.
                if (endDiff.Contains(currStr)) {
                    //Console.WriteLine("Return");
                    return level;
                }
            
                // Shrink set each time.
                wordSet.Remove(currStr);
                
                // O(n*w) at most.
                foreach (var word in wordSet) { 
                    if (!visited.Contains(word)) {
                        // O(n), sicne we iterate through the entire currStr
                        var pathDiff = FindDiff(word, currStr);
                        //Console.WriteLine("diff is " + pathDiff);
                        if (pathDiff == 1) {
                            if (word == endWord) {
                                return level;
                            }
                            //Console.WriteLine("Queueing " + word);
                            visited.Add(word);
                            queue.Enqueue(word);
                        }
                    }
                }
                qCount--;
            }
            
        }
        
        return 0;
    }
    
    // O(n)
    private int FindDiff(string s1, string s2) {
        var diffCount = 0;
        for (int i = 0; i < s1.Length; i++) {
            if (!s1[i].Equals(s2[i])) {
                diffCount++;
            }
        }
        return diffCount;
    }
    
    
    private HashSet<string> GenerateEndDiff(IList<string> list, string end) {
        var endSet = new HashSet<string>();
        
        foreach (var word in list) {
            var diff = FindDiff(word, end);
            if (diff == 1) {
                endSet.Add(word);
            }
        }
        
        return endSet;
    }
}