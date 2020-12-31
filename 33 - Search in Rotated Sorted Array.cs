public class Solution {
    public int Search(int[] nums, int target) {
        if (nums.Length == 0) {
            return -1;
        }
        
        var hi = nums.Length-1;
        var lo = 0;
        var ans = -1;
        
        while (lo <= hi) {
            var mid = lo + (hi-lo)/2;
            var curr = nums[mid];
            
            // CASE 1: We found our target. The answer is the index, mid.
            if (curr == target) {
                ans = mid;
                break;
            }
            
            // CASE 2: Now lets see if the midpoint is larger than the low end.
            // This is usually the case where things are all good in the hood.
            if (curr >= nums[lo]) {
                // CASE 2a: Check if the target is between curr and nums[lo]
                if (target <= curr && target >= nums[lo]) {
                    hi = mid - 1;              
                } else {
                // CASE 2b: Then otherwise, it is likely in the upper half
                    lo = mid + 1;
                }
            // CASE 3: Now let's see if the midpoint is smaller than the low end
            // Usually, this is the case where its rotated. Disgusting.
            } else {
                // CASE 3a: Check if the target is larger than the midpoint
                // AND target is smaller than nums[hi]. That means the target is LIKELY upper half
                // For example, [4,5,6,0,1,2,3], target = 2. nums[hi] is larger than target, but current is smaller than target.
                if (target >= curr && target <= nums[hi]) {
                    lo = mid + 1;
                // CASE 3b: Otherwise, it is in the lower half.
                } else {
                    hi = mid - 1;
                }
            }           
        }        
        return ans;
    }
}