public class Solution {
    public bool IsAnagram(string s, string t) {
           
        // BASE CASE 1: Both are empty or null. Return true
        if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(t)) {
            return true;
        }
        
        // BASE CASE 2: Either are empty or null, or different length strings.
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || (s.Length != t.Length)) {
            return false;
        }
        
        // Could use a dictionary to count occurence, but we can fill an ascii array instead with occurence values.
        // Use the first string to fill it, then the second to check to use much less space.
        var asciiArr = new int[26];      
        for (int i = 0; i < s.Length; i++) {
            var idx = s[i] -'0' - ('a' - '0');
            asciiArr[idx]++;
        }
        
        for (int j = 0; j < t.Length; j++) {
            var idx = t[j] - '0' - ('a' - '0');
            asciiArr[idx]--;
            if (asciiArr[idx] < 0) {
                return false;
            }
        }
        
        return true;
    }
}