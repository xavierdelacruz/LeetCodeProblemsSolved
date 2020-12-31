public class Solution {
    public int MaxSubArray(int[] nums) {
        
        if (nums.Length == 0) {
            return 0;
        }
        
        if (nums.Length == 1) {
            return nums[0];
        }
        
        int prevSum = nums[0];
        int largest = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            // see if the current subarray results in a larger amount, or a single element by itself is better
            prevSum = Math.Max(prevSum + nums[i], nums[i]);
            
            // now, check if the current subarray is larger than the largest so far.
            largest = Math.Max(largest, prevSum);     
        }        
        return largest;        
    }
}