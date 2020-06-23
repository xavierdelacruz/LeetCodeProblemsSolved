public class Solution {

    // The main idea with the 3 pointer approach is to get closer to a 0 sum.
    // We will have a pointer at the largest value (k)
    // We will have a pointer at the smallest value (i)
    // We will have a pointer between i and k (j)
    // None of the pointers will ever cross each other
    public IList<IList<int>> ThreeSum(int[] nums) {
        var result = new List<IList<int>>();
        
        if (nums.Length < 3 || nums == null) {
            return result;
        }
        
        // Sort it in order. O(nlogn)
        Array.Sort(nums);
        
        // Approx O(n^2). OVERALL, O(n^2)
        for (int i = 0; i < nums.Length-2; i++) {
            
            int j = i+1;
            int k = nums.Length-1;
            
            // This check has to be done so that we ensure that we are not reusing previously seen values
            // This will reduce the search space significantly and prevent duplicates
            if (i != 0 && nums[i] == nums[i-1]) {
                continue;
            }
            
            while (j < k) {    
                // This prevents us from reusing an old value that was already seen previous in the current iteration with i
                // This is because we will produce the same result at that current iteration of i
                // Note that j > i + 1 because only want to increment if j has seen it previous and i currently not
                if (j > i + 1 && nums[j] == nums[j-1]) {
                    j++;
                    continue;
                }                
                
                // Calculate the sum first
                var sum = nums[i] + nums[j] + nums[k];
                
                if (sum == 0) {
                    // If the sum is 0, we add them to the list in that order.
                    var list = new List<int>() {nums[i], nums[j], nums[k]};
                    result.Add(list);
                    j++;
                } else if (sum < 0) {
                    // If overall sum is negative, we need to increment j
                    // Remember that this is SORTED.
                    // That means we are going closer to a more positive value (closer to 0)
                    j++;
                } else {
                    // If overall sum is positive, we need to decrement k
                    // Remember that this is SORTED.
                    // That means we are going closer to a more negative value (closer to 0)
                    k--;
                }
            }
        }
        
        return result;
    }
}