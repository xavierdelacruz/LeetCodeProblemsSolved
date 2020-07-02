public class Solution {
    public int FourSumCount(int[] A, int[] B, int[] C, int[] D) {
        
        if (A.Length < 1 || B.Length < 1 || C.Length < 1 || D.Length < 1) {
            return 0;
        }
        
        var length = A.Length;
        
        // Dictionary to store sums, and how many combinations can exist to produce that sum
        // In Java, we can use an object wrapper.
        var dict = new Dictionary<int, int>();
        
        for (int i = 0; i < length; i++) {
            for (int j = 0; j < length; j++) {
                var sum = A[i] + B[j];
                if (!dict.ContainsKey(sum)) {
                    dict.Add(sum, 1);
                } else {
                    dict[sum]++;
                }
            }
        }
           
        // Ensures there are no duplicates.
        var result = 0;
        
        // Treat it like 2-Sum. Divide and Conquer, where we lookup the difference in the map.        
        for (int k = 0; k < length; k++) {
            for (int l = 0; l < length; l++) {
                var diff = 0 - (C[k] + D[l]);   
                
                // If we find the diff in the diff dict, then we found our tuple(s).
                // For example, if the diff contains 2 as value, that means we could have different combination of A and B 
                // for the current combination of C and D. For example, A[0] + B[0] = A[1] + B[0] = diff, and C[0], D[0],
                // Then we have two combinations, where we have (0, 0, 0, 0), and (1, 0, 0, 0)
                if (dict.ContainsKey(diff)) {
                    result += dict[diff];                    
                }
            }
        }      
        return result;
    }
}