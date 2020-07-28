public class Solution {
    public bool Find132pattern(int[] nums) {
        if (nums.Length < 3) {
            return false;
        }
        
        var i = 0;
        var min = Int32.MaxValue;
        while (i < nums.Length-2) {
            var j = i+1;
            var k = nums.Length-1;
            min = Math.Min(min, nums[i]);
            // Advances i if we're already used this value before.
            if (i != 0 && nums[i] == nums[i-1]) {
                i++;
                continue;
            }
            
            // MAJOR improvement in runtime. This checks if our first element is larger the current value of k. Otherwise, advance.
            // This also checks if its larger than the second element.
            if (nums[i] >= nums[k] && nums[i] >= nums[j]) {
                i++;
                continue;
            }
            
            while (j < k) {
                // We found our answer.
                if (min < nums[j] && nums[j] > nums[k] && nums[k] > min) {
                    return true;
                }
                
                // Advance j and k if we've already used this value before.
                if (i+1 != j && nums[j] == nums[j-1]) {
                    j++;
                    k--;
                    continue;
                }
                
                // Advance j if its a duplicate, along with k, since its important that it stays ahead of j
                if (nums[i] == nums[j] || nums[j] <= nums[i]) {
                    j++;
                    k--;
                    continue;
                }
                
                // Advance only k if its a duplicate. j will stay in place.
                // It will also advance if value of k > j
                if (nums[j] == nums[k] || nums[k] >= nums[j] || nums[k] <= nums[i]) {
                    k--;
                    continue;
                }
                  
                // In all other cases, advance j
                k--;
                j++;
            }
            i++;   
        }
        return false;        
    }
}