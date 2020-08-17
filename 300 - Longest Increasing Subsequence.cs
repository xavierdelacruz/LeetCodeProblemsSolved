public class Solution {
    public int LengthOfLIS(int[] nums) {
        if (nums.Length <= 0) {
            return 0;
        }
        
        var soln = new int[nums.Length];
        // The first element is always length 1.
        soln[0] = 1;
        var max = 1;
        for (int i = 1; i < nums.Length; i++) {
            var maxSoFar = 0;
            var anchor = nums[i];
            for (int j = 0; j < i; j++) {
                var curr = nums[j];
                if (curr < anchor) {
                    // This updates the max that we've seen.
                    // In this if statement, if we see that the current anchor
                    // remains larger than the current element, then 
                    // we will check if the previously calculated max is the largest.
                    maxSoFar = Math.Max(soln[j], maxSoFar);
                }
            }
            // Add the anchor itself (ie. + 1) to the max length calculated
            soln[i] = 1 + maxSoFar;
            max = Math.Max(max, soln[i]);
        }
        
        return max;
    }
}