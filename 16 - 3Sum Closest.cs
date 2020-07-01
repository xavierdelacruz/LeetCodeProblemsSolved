public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        
        if (nums.Length < 3) {
            return 0;
        }
                
        // O(nlogn), sorted makes it easier to use the 3 pointer approach.
        Array.Sort(nums);
        
        // We will be using the three pointer approach, similar to 3-sum.
        var i = 0;
        
        var closestSum = 0;
        var smallestDiff = Int32.MaxValue;
        
        while (i < nums.Length -2) {     
            // j will always be ahead of i.
            var j = i+1;
            
            // k will always start at the end for each iteration of i.
            var k = nums.Length-1;
            
            // If we already encountered a duplicate val, increment i
            if (i != 0 && nums[i] == nums[i-1] && i < j) {
                i++;
                continue;
            }
            
            while (j < k) {            
                // If we already encountered a duplicate val, increment j
                if (i != j-1 && nums[j] == nums[j-1]) {
                    j++;
                    continue;
                }
                
                var sum = nums[i] + nums[j] + nums[k];
                var diff = Math.Abs(sum-target);
                
                // Update the value trackers.
                if (diff < smallestDiff) {
                    closestSum = sum;
                    smallestDiff = diff;
                }
                
                // Case 1: Nothing better than hitting the target.
                // Immediately return and call it a day!
                if (sum == target) {                                       
                    return closestSum;
                }
                
                // Case 2: If the sum is larger than the target we need to reduce the size of the sum
                // This implies that we also reduce the difference.
                if (sum > target) {
                    k--;
                }
                
                // Case 3: If the sum is smaller than the target, we need to increase size of the sum
                // This implies that we also reduce the difference.
                if (sum < target) {
                    j++;
                }
            }
            i++;
        }
        return closestSum;
    }
}