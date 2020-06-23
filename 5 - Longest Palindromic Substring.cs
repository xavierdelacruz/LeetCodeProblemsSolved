public class Solution {
    public string LongestPalindrome(string s) {
     
        // Edge case: Null or Empty string
        if (string.IsNullOrEmpty(s)) {
            return "";
        }
        
        // Make a memo of previous solutions
        // O(n^2) space
        var soln = new bool[s.Length,s.Length];
        
        // Base case 1:
        // Solve smaller subproblems first, where it is of size 1
        // We know that length = 1 strings are always palindromes.
        // O(n)
        for (int i = 0; i < s.Length; i++) {
            soln[i,i] = true;
        }
        
        // Base case 2:
        // What about length = 2?
        // They are technically neighbors, so just check for them
        // O(n)    
        var finalStart = 0;
        var finalEnd = 0;
        
        for (int j = 0; j < s.Length-1; j++) {
            if (s[j].Equals(s[j+1])) {
                soln[j, j+1] = true;
                finalStart = j;
                finalEnd = j+1;
            }
        }
        
        // Non-trivial case. Do basic checks using previous solutions
        // Rather than checking if its a palindrome, which takes O(n).
        // This means you have pre calculated the sub-problems already
        // O(n2)
        var start = 0;
        var k = start;
        var length = 3;
        var l = length-1;

        while (length <= s.Length) {
            k = start;
            l = length-1;
            while (l < s.Length) {
                if (k < l) {
                    if (soln[k+1, l-1] && s[k].Equals(s[l])) {
                        soln[k, l] = true;
                        finalStart = k;
                        finalEnd = l;
                    } else {
                        soln[k, l] = false;
                    }
                    k++;
                    l++;
                } else {
                    if (s[k].Equals(s[l])) {
                        soln[k, l] = true;
                        finalStart = k;
                        finalEnd = l;
                    }         
                    k++;
                    l++;
                }
            }
            length++;
        }
                
        return s.Substring(finalStart, finalEnd-finalStart + 1);
    }
    
    // UTILITY FUNCTION FOR TESTING LATER.
    // Just to calculate the length. This is the recurrence
    private int LengthCalculator(string s, int i, int j) {
        if (i > j) {
            return 0;
        }
        
        if (i == j) {
            return 1;
        }
        
        if (s[i].Equals(s[j])) {
            return 2 + LengthCalculator(s, i+1, j-1);
        } else {
            return Math.Max(LengthCalculator(s, i+1, j), LengthCalculator(s, i, j-1));
        }
    }
}