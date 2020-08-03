public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        
        var res = new List<IList<int>>();
        if (nums.Length <= 0) {
            return res;
        }
        Array.Sort(nums);
        var visited = new HashSet<int>();
        var combo = new List<int>();
        
        GeneratePermutations(nums, res, combo, visited);
        return res;
    }
    
    private void GeneratePermutations(int[] nums, List<IList<int>> res, List<int> combo, HashSet<int> visited) {
        if (combo.Count == nums.Length) {
            res.Add(new List<int>(combo));
            return;
        }
        
        for (int i = 0; i < nums.Length; i++) {
            
            if (visited.Contains(i)) {
                continue;
            }
            
            // This is the important check that tells the current iteration to skip
            // if the next value is a duplicate, then just go to the next value and use it instead.
            // This is more efficient than checking if the PREVIOUSLY used one is a duplicate.
            if (i + 1 < nums.Length && nums[i] == nums[i+1] && visited.Contains(i+1)) {
                continue;
            }
            
            combo.Add(nums[i]); 
            visited.Add(i);
            GeneratePermutations(nums, res, combo, visited);
            visited.Remove(i);
            combo.RemoveAt(combo.Count-1);
        }
        
        return;
    }
}