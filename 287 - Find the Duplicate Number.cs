public class Solution {
    public int FindDuplicate(int[] nums) {
        var tortoise = nums[0];
        var hare = nums[0];
        
        // Update once. Can use a do-while.
        tortoise = nums[tortoise];
        hare = nums[nums[hare]];
        
        while (hare != tortoise) {
            tortoise = nums[tortoise];
            hare = nums[nums[hare]];
        }
        
        tortoise = nums[0];
        
        while (hare != tortoise) {
            hare = nums[hare];
            tortoise = nums[tortoise];
        }
        
        return hare;
    }
}