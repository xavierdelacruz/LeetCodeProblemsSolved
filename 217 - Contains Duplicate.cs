public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        
        if (nums.Length == 0 || nums.Length == 1) {
            return false;
        }
        // Sort, which is nlogn
        Array.Sort(nums);      
        var prev = nums[0];        
        for (int i = 1; i < nums.Length; i++) {
            if (prev == nums[i]) {
                return true;
            }
            prev = nums[i];
        }
        return false;
    }
}