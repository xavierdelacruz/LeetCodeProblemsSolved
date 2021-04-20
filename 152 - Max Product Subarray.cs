public class Solution {
    public int MaxProduct(int[] nums) {
        
        // BASE CASE 1: no elements. Return 0.
        if (nums.Length == 0) {
            return 0;
        }
        
        // BASE CASE 2: only a single element. Return just that.
        if (nums.Length == 1) {
            return nums[0];
        }
        
        var max = nums[0];
        var min = nums[0];
        var bestValue = nums[0];
        
        // Start at idx 1, since we are accounting for the first element already.
        for (int i = 1; i < nums.Length; i++) {
            var prevMin = min;
            var prevMax = max;
            
            // This is where both - x + or vice versa would end up in
            // Store smallest negative number.
            min = Math.Min(nums[i], Math.Min(prevMin*nums[i], prevMax*nums[i]));
            
            // This is where both - x -, or + x + would end up in
            max = Math.Max(nums[i], Math.Max(prevMin*nums[i], prevMax*nums[i]));
            
            // Continually update the global max so far.
            bestValue = Math.Max(bestValue, max);
        }
        
        return bestValue;
    }  
}