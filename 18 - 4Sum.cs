public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        var list = new List<IList<int>>();
        
        // If we use Java, we can declare an object that has these properties.
        var visited = new HashSet<(int i, int j, int k, int l)>();
        
        if (nums.Length < 4) {
            return list;
        }
        
        // O(nlogn) Sort the array.
        Array.Sort(nums);
        
        // 4-pointer approach.
        var i = 0;
        
        while (i < nums.Length-3) {
            // This ensures that i is always before j.
            var j = i+1;
            
            // Again, this only works if the array is sorted.
            if (i != 0 && nums[i] == nums[i-1]) { 
                i++;
                continue;
            }
            
            // Start 3Sum here
            while (j < nums.Length-2) {
                      
                // This ensures that j is always before k
                var k = j+1;
                var l = nums.Length-1;
                
                // We have seen this previous value of j before.
                // Increment to the next value that's different.
                if (j-1 != i && nums[j] == nums[j-1]) {
                    j++;
                    continue;
                }
    
                // Real stars of the show here
                while (k < l) {
                    
                    // Reduces the search. No need to compute the sum and other comparisons.
                    if (k-1 != j && nums[k] == nums[k-1]) {
                        k++;
                        continue;
                    }
                    
                    var sum = nums[i] + nums[j] + nums[k] + nums[l];
                    
                    // Case 1: We found a target sum. Add it to the list of results.
                    if (sum == target) {
                        var quad = new List<int>() {
                            nums[i],
                            nums[j],
                            nums[k],
                            nums[l]
                        };
                        var quadObj = (nums[i], nums[j], nums[k], nums[l]);
                        if (!visited.Contains(quadObj)) {
                            visited.Add(quadObj);
                            list.Add(quad);
                        }
                        k++;
                        l--;
                    }
                    
                    // Case 2: Sum is larger than target. Make it smaller by decrementing l.
                    if (sum > target) {
                        l--;
                    }
                    
                    // Case 3: Sum is small than target. Make it bigger by incrementing k.
                    if (sum < target) {
                        k++;
                    }                    
                }
                j++;
            }
            i++;
        }
        
        return list;
        
    }
}