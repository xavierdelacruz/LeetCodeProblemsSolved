public class Solution {
    public int SingleNumber(int[] nums) {
        if (nums.Length == 0) {
            return 0;
        }
        
        if (nums.Length == 1) {
            return nums[0];
        }
        
        // Using O(n) space;
        var result = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            result ^= nums[i];
        }
        
        return result;
    }
}