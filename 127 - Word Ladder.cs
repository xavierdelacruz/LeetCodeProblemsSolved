public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
             
        var wordSet = new HashSet<string>(wordList);
        var newSet = wordSet.ToHashSet();
              
        if (wordSet.Count == 0 || !wordSet.Contains(endWord)) {
            return 0;
        }
        
        // Generate a set to see if we are one edit distance away from the final word.
        //var singleDiffSet = GetOneDiffToEnd(wordSet, endWord);   
        var q = new Queue<string>();
        var visited = new HashSet<string>();
        q.Enqueue(beginWord);
        visited.Add(beginWord);
        
        var level = 0;
        
        // O(w^2*n)
        while (q.Count != 0) {
            var qCount = q.Count;            
            level++;          
            while (qCount > 0) {     
                var curr = q.Dequeue();
                
                if (curr.Equals(endWord)) {
                    return level;
                }                         
                qCount--;                
                // O(w) each time.
                foreach (var word in wordSet) {
                    
                    if (visited.Contains(word)) {
                        continue;
                    }
                    // O(n) each time.
                    if (FindDiff(word, curr) == 1) {
                        q.Enqueue(word);
                        visited.Add(word);
                        newSet.Remove(word);
                    }
                }   
                
                // LINQ - significantly shrinks the search space
                wordSet = newSet.ToHashSet();
            }
        }      
        return 0;
    }
    
    private int FindDiff(string s1, string s2) {
        int count = 0;
        for (int i = 0; i < s1.Length; i++) {
            if (!s1[i].Equals(s2[i])) {
                count++;
            }
        }
        
        return count;
    }
}