public class Solution {
    public bool IsPalindrome(int x) {
        
        // These are all numbers that end with a 0, other than 0 itself
        if (x % 10 == 0 && x != 0) {
            return false;
        }
        
        // negative numbers are automatically not palindromes
        if (x < 0) {
            return false;
        }
        
        
        // Storage (can be an int array too, but takes O(n) space)
        var reversed = 0;
        
        // The loop condition ensures that if the reverse string is bigger than what x currently is, then it ends.
        // As we remove digits, it reduces the value of x. When we get to the midpoint, we stop.
        while (x > reversed) {
        
            // This gets the first digit, bumps up the current reversed number, and adds that digit
            // This works similar to StringBuilder append.
            var firstDigit = x % 10;
            reversed *= 10;
            reversed += firstDigit;
            
            // Update x to the next digit;
            x = x/10;
        }
        
        
        // if it is odd, we need to check reversed / 10 == x, 
        // since it will take the middle digit for odd-digit numbers
        // Otherwise, we can simply check x == reversed for even-digit numbers
        return x == reversed || x == reversed/10;
        
        

    }
}