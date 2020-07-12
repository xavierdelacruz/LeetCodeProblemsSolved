public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
       
        if (nums.Length == 0 || k <= 0) {
            return new int[nums.Length];
        }
        // Group by the element itself first. This means it groups it by the group
        // After grouping, it counts the occurences of each element and orders it descending
        // Only take the keys
        // Finally, take only the first k, and turn it into an array.
        var result = nums.GroupBy(x => x)           
            .OrderByDescending(y => y.Count())         
            .Select(i => i.Key)          
            .Take(k)
            .ToArray();
        
        return result;
    }
}