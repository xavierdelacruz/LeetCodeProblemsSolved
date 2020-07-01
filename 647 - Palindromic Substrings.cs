public class Solution {
    public int CountSubstrings(string s) {
        
        // Base case 1: s is empty or null.
        if (string.IsNullOrEmpty(s)) {
            return 0;
        }
        
        // Base case 2: s is of size 1. 
        if (s.Length == 1) {
            return 1;
        }
        
        // We will not care about duplicates in this case.
        var count = 0;
        
        for (int i = 0; i < s.Length; i++) {
            ExpandFromCenter(s, i, i, ref count);
            ExpandFromCenter(s, i, i+1, ref count);
        }
        
        return count;
    }

    private void ExpandFromCenter(string s, int left, int right, ref int count) {
        while (left >= 0 && right < s.Length && s[left] == s[right]) {
            count++;
            left--;
            right++;
        }
    }  
}