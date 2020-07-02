public class Solution {
    public int FindDuplicate(int[] nums) {
        
        // Not necessary, but I like just to have it here.
        if (nums.Length == 0 || nums.Length == 1) {
            return -1;
        }
        
        var tortoise = nums[0];
        var hare = nums[0];
        
        // Update once. Can use a do-while.
        tortoise = nums[tortoise];
        hare = nums[nums[hare]];
        
        // Find intersection point of the tortoise and hare
        while (hare != tortoise) {
            tortoise = nums[tortoise];
            hare = nums[nums[hare]];
        }
        
        // Now let the tortoise start from the beginning again.
        // When they meet again, the current value of the hare will be the duplicate.
        tortoise = nums[0];     
        while (hare != tortoise) {
            hare = nums[hare];
            tortoise = nums[tortoise];
        }
        
        return hare;
    }
}