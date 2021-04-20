public class Solution {
    public int MaxProduct(int[] nums) {
        
        // Base case 1:
        if (nums.Length == 0) 
        {
            return 0;
        } 
        
        // Base case 2:
        if (nums.Length == 1) 
        {
            return nums[0];
        }
        
        // Non trivial cases
        // Examples
        // [-1, 2, -1, 2] = 4
        // [-1, 0, -1, 3] = 3
        // [-3, 0, -3, 1] = 1
        // [2, -1, -1]  = 2
        // [2, -1, -1, -2] = 2
        
        // The idea is, we want to keep multiplying and keep updating the min and max, 
        // because our min (which would likely be a negative number) can become the largest suddenly when encountering another negative
        int min = nums[0];
        int max = nums[0];
        int result = nums[0];
        
        for (int i = 1; i < nums.Length; i++) 
        {
            // We need this to keep track of the min and max, since they mutate
            int prevMin = min;
            int prevMax = max;
            
            // We wnat to make three comparisons here
            // 1. The single unit subarray at nums[i]
            // 2. nums[i] and a previously known min (because it could be a new max, or new min depending on the signs)
            // 3. nums[i] and a previously known max (because it could be a new max, or new min depending on the signs)
            min = Math.Min(nums[i], Math.Min(nums[i] * prevMin, nums[i] * prevMax));
            max = Math.Max(nums[i], Math.Max(nums[i] * prevMax, nums[i] * prevMin));
            
            result = Math.Max(max, result);
        }
        
        return result;
    }
}