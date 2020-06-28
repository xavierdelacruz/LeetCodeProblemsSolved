public class Solution {
    public int LengthOfLongestSubstring(string s) {
        
        if (string.IsNullOrEmpty(s)) {
            return 0;
        }
        
        if (s.Length == 1) {
            return 1;
        }
        
        // Store a set of characters, to check if it has been seen.
        // It's length will be the output, and answer too.
        var dict = new Dictionary<char, int>();
        var prevBest = 0;
        var curr = 0;
        
        int i = 0;
        while (i < s.Length) {
            if (!dict.ContainsKey(s[i])) {
                dict.Add(s[i], i);
                curr++;
                i++;
            } else {
                if (curr > prevBest) {
                    prevBest = curr;
                }
                
                // Start after the first occurence of the duplicate
                // Optimal is to mathematically calculate the distance between the first occurrence to the new one.
                curr = 0;
                i = dict[s[i]] + 1;
                dict.Clear();
            }
        }

        return Math.Max(curr, prevBest);
        
        
    }
}