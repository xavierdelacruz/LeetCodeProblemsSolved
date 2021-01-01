public class Solution {
    public string BreakPalindrome(string palindrome) {     
        if (palindrome.Length <= 1) {
            return "";
        }
        
        int midpoint = palindrome.Length/2;
        char[] pChar = palindrome.ToCharArray();
        
        for (int i = 0; i < pChar.Length; i++) {
            
            if (pChar[i] != 'a' && i < midpoint) {
                pChar[i] = 'a';
                break;
            }
            
            if (i == midpoint) {
                pChar[palindrome.Length-1] = 'b';
                break;
            }
        }      
        return new String(pChar);
      
    }
}