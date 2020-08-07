public class Solution {
    public string LongestPalindrome(string s) {
        
        // Brute force is O(n^3) where you have 2 pointers and doing an O(n^2) iteration 
        // This is followed by validating palindromic substrings, O(n)
        
        // BASE CASE 1: string is null or emptry.
        if (string.IsNullOrEmpty(s) || s.Length == 1) {
            return s;
        }        
        
        var finalStart = 0;
        var finalEnd = 0;
        var longestSoFar = Int32.MinValue;
        
        // O(n^2), since we call substring outside of the loop.
        for (int i = 0; i < s.Length; i++) {
            var start = 0;
            var end = 0;      
            
            ExpandFromCenter(i, i, s, ref start, ref end);
            var len = end - start + 1;
            if (longestSoFar < len) {
                finalStart = start;
                finalEnd = end;
                longestSoFar = len;
            }
            start = 0;
            end = 0;
            ExpandFromCenter(i, i+1, s, ref start, ref end);
            len = end - start + 1;
            if (longestSoFar < len) {
                finalStart = start;
                finalEnd = end;
                longestSoFar = len;
            }
        }
        
        return s.Substring(finalStart, finalEnd - finalStart + 1);
    }
    
    public void ExpandFromCenter(int left, int right, string s, ref int start, ref int end) {       
        while (left >= 0 && right < s.Length && s[left].Equals(s[right])) {
            start = left;
            end = right;
            left--;
            right++;
        }
    }
}