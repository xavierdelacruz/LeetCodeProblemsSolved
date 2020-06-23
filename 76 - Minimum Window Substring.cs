public class Solution {
    public string MinWindow(string s, string t) {
        // Main idea is to NOT use substrings within the inner loop, but store indexes
        // Especially the start point.
        
        // Handles null or empty string inputs, or if t is longer than s
        if (t.Length > s.Length || String.IsNullOrEmpty(s) || String.IsNullOrEmpty(t)) {
            return "";
        }
        
        // If t is just of length one, check if s contains t, and return it if true
        // If t is equal to s (same exact string), return t
        // O(n) in the worst case (t is found at the very end of s)
        if (t.Length == 1 && s.Contains(t) || t.Equals(s)) {
            return t;
        }
        
        // Rather than use a map, use an ascii indexed array (extended ascii is 256)
        // to store occurrences. Guaranteed access at O(1), and placement is guaranteed too
        // The same will be done for sArr with the usage of s in the main loop
        int[] tArr = new int[256];
        int[] sArr = new int[256];
        
        // Fill the ASCII-indexed array with the ocurrences
        foreach (var character in t) {
            tArr[character]++;
        }
        
        // Pointers for the sliding window
        int i = -1;
        int substringStart = -1;
        
        int counter = 0;
        int minSoFar = Int32.MaxValue;
        
        // We will also actively fill the ascii-indexed arrayt for s
        // by calling sArr[s[j]]++ - the character will be an interger index
        // based on ASCII (as mentioned earlier)
        for (int j = 0; j < s.Length; j++) {
            sArr[s[j]]++;
            
            // This compares both arrays
            // If the current window contains what tArr has AND if this is what we want ( > 0) based on tArr
            // then we increment the counter (and it will only get incremented once per character of t)
            if (sArr[s[j]] <= tArr[s[j]] && tArr[s[j]] != 0) {
                if (i == -1) {
                    // Set our new starting point to the first occurence of a hit with tArr
                    // This cuts down the problem to a start point that is valid
                    i = j;
                }            
                counter++;
            }
            
            // In the event that we find all characters as we iterate through
            // We want to validate the answer
            if (counter == t.Length) {
                
                // As we iterate through the string, check if the current char exists in tArr
                // If it does not, move to the next position of start
                // We also contract if we find an entry in tArr that is less in occurence
                // than that in sArr. This means that there could be more occurrences
                // that could produce the smallest window substring
                // We need to decrement the occurence in sArr to indicate that it has been visited
                // and there is occurence - 1 left to see
                // To exit this condition, we would have seen the last occurence of that character
                // such that the occurrence in tArr == sArr, and we are currently on that last occurence
                // that fulfills the condition
                while(tArr[s[i]] == 0 || tArr[s[i]] < sArr[s[i]]) {
                    sArr[s[i]]--;
                    i++;
                }
                
                // Now, find the length of the window where j last left off
                // J would now be at the occurrence of the last character we've seen
                // but would enclose all necessary characters in t
                int windowLength = j - i + 1;
                if (minSoFar > windowLength) {
                    minSoFar = windowLength;
                    substringStart = i;
                }
            }
        }
        
        // If the substring start has not changed at all, return an empty string
        // This means that there were no qualifying characters that fulfilled t in s        
        return (substringStart == -1 ? "" : s.Substring(substringStart, minSoFar));
    }
}