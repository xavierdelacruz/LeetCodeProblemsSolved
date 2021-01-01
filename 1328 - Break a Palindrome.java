class Solution {
    public String breakPalindrome(String palindrome) {
        
        if (palindrome.length() <= 1) {
            return "";
        }
        
        boolean isEven = palindrome.length() % 2 == 0;
        int midpoint = palindrome.length() / 2;
        
        char[] pChar = palindrome.toCharArray();
        
        for (int i = 0; i < pChar.length; i++) {
            // Trivial case - can be an any index
            if (pChar[i] != 'a' && i != midpoint) {
                pChar[i] = 'a';
                break;
            } 
            
            if (i == midpoint) {
                pChar[palindrome.length()-1] = 'b';
                break;
            }
        }
        
        String result = String.valueOf(pChar);
        return result;
    }
}