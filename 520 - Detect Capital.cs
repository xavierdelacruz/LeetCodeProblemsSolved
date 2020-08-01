public class Solution {
    public bool DetectCapitalUse(string word) {
        if (string.IsNullOrEmpty(word) || word.Length == 1) {
            return true;
        }
        
        
        var isLowerFirst = Char.IsLower(word[0]) ? true : false;
        var isLowerSecond = Char.IsLower(word[1]) ? true: false;
        for (int i = 1; i < word.Length; i++) {
            
            // Case 1: Lower case start, remaining must be all lower case.
            if (isLowerFirst && isLowerSecond) { 
                if (Char.IsUpper(word[i])) {
                    return false;
                }
            }
            
            // Case 2: Upper case start, second char is lower. Rest must be lower.
            if (!isLowerFirst && isLowerSecond) {
               if (Char.IsUpper(word[i])) {
                   return false;
               } 
            }
            
            // Case 3: Upper case start, second char is upper. Rest must be upper.
            if (!isLowerFirst && !isLowerSecond) {
                if (Char.IsLower(word[i])) {
                    return false;
                }
            }
            
            // Case 4: Invalid case.
            if (isLowerFirst && !isLowerSecond) {
                return false;
            }
        }
        
        return true;
    }
}