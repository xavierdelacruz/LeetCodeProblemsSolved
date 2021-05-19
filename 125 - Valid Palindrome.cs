using System.Text.RegularExpressions;

public class Solution {
    public bool IsPalindrome(string s) {
        
        if (string.IsNullOrEmpty(s) || s.Length <= 1) {
            return true;
        }
           
        int i = 0;
        int j = s.Length-1;
        while (i < j) {
            
            while (i < j && !Char.IsLetterOrDigit(s[i])) {
                i++;
            }
            
            while (i < j && !Char.IsLetterOrDigit(s[j])) {
                j--;
            }
            
            if (i < j && Char.ToLower(s[i]) != Char.ToLower(s[j])) {
                return false;
            }
            
            i++;
            j--;
        }
        return true;
    }
}