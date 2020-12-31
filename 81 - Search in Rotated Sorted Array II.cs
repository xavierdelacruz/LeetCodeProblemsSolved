public class Solution {
    public bool Search(int[] nums, int target) {
        if (nums.Length == 0) {
            return false;
        }
                
        int lo = 0;
        int hi = nums.Length-1;
        
        while (lo <= hi) {     
            int mid = (lo + hi)/2;
            int curr = nums[mid];
                    
            // CASE 1: Check early. Since there are duplicates, its prudent to check both ends ASAP.
            if (curr == target || target == nums[lo] || target == nums[hi]) {
                return true;
            }
            
            // CASE 2: This makes it O(n) in the worst case, and O(logn) on average.
            // Imagine a case where a large set values are duplicated.
            if (nums[lo] == nums[hi] && nums.Length > 1) {
                lo++;
                continue;
            }

            // CASE 3: Now lets see if the midpoint is larger than the low end.
            // This is usually the case where things are all good in the hood.
            if (curr >= nums[lo]) {
                // CASE 3a: Check if the target is between curr and nums[lo]
                if (target <= curr && target >= nums[lo]) {
                    hi = mid - 1;              
                } else {
                // CASE 3b: Then otherwise, it is likely in the upper half
                    lo = mid + 1;
                }
            // CASE 4: Now let's see if the midpoint is smaller than the low end
            // Usually, this is the case where its rotated. Disgusting.
            } else {
                // CASE 4a: Check if the target is larger than the midpoint
                // AND target is smaller than nums[hi]. That means the target is LIKELY upper half
                // For example, [4,5,6,0,1,2,3], target = 2. nums[hi] is larger than target, but current is smaller than target.
                if (target >= curr && target <= nums[hi]) {
                    lo = mid + 1;
                // CASE 4b: Otherwise, it is in the lower half.
                } else {
                    hi = mid - 1;
                }
            }  
        }
        
        return false;
        
    }
}