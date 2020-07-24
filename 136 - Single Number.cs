public class Solution {
    public int SingleNumber(int[] nums) {
        if (nums.Length == 0) {
            return 0;
        }
        
        if (nums.Length == 1) {
            return nums[0];
        }
        
        // Using O(n) space;
        var hashset = new HashSet<int>();
        
        for (int i = 0; i < nums.Length; i++) {
            if (!hashset.Contains(nums[i])) {
                hashset.Add(nums[i]);
            } else {
                hashset.Remove(nums[i]);
            }
        }
        
        var result = 0;
        foreach (var item in hashset) {
            result += item;
        }
        
        return result;
    }
}