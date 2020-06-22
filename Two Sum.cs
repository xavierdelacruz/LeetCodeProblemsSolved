public class Solution {
    public int[] TwoSum(int[] nums, int target) {
                
        Dictionary<int, int> dict = new Dictionary<int, int>();        
        
        // O(n) - populate the dictionary (map) with the actual entries
        for(int i = 0; i < nums.Length; i++) {
            if (!dict.ContainsKey(nums[i])) {
                dict.Add(nums[i], i);
            } else {
                dict[nums[i]] = i;

            }
        }
        
        int[] result = new int[2];    
        int j = 0;
        
        // Start iterating forward to find the difference with the target
        // Once a difference is calculated, see if that diff exists
        // if it does, then is the solution.
        // At most, O(n)
        while (j < nums.Length) {
            var diff = target-nums[j];    
            if (dict.ContainsKey(diff) && dict[diff] != j) {
                result[0] = j;
                result[1] = dict[diff];
                return result;
            }
            j++;
        }   
        return result;
    }
}