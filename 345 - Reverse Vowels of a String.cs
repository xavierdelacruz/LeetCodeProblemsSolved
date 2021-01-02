public class Solution {
    public string ReverseVowels(string s) {
        
        if (s.Length == 0 || s.Length == 1) {
            return s;
        }
        
        char[] sChar = s.ToCharArray();
        int i = 0;
        int j = sChar.Length-1;
        
        while (i < j) {
            char lo = sChar[i];
            char hi = sChar[j];
            
            while (i < j && !IsVowel(sChar[i])) {
                i++;
            }
            
            while (i < j && !IsVowel(sChar[j])) {
                j--;
            }        
            
            if (i < j) {
                char tmp = sChar[i];
                sChar[i] = sChar[j];
                sChar[j] = tmp;
                i++;
                j--;
            } else {
               break; 
            }
        }
        
        return new String(sChar);
    }
    
    private bool IsVowel(char s) {
        return (s == 'a' || s == 'e' || s == 'i' || s == 'o' || s == 'u' || s == 'A' || s == 'E' || s == 'I' || s == 'O' || s == 'U');
    }
}