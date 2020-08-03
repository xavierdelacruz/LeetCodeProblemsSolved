public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var res = new List<IList<int>>();
        
        if (nums.Length <= 0) {
            return res;
        }
        var combo = new List<int>();
        var visited = new HashSet<int>();
        GeneratePermutations(nums, res, combo, visited);
        
        return res;
        
    }
    
    private void GeneratePermutations(int[] nums, List<IList<int>> res, List<int> combo, HashSet<int> visited) {     
        if (combo.Count == nums.Length) {
            res.Add(new List<int>(combo));
            return;
        }
        
        for (int i = 0; i < nums.Length; i++) {
            if (visited.Contains(nums[i])) {
                continue;
            }
            combo.Add(nums[i]);
            visited.Add(nums[i]);
            GeneratePermutations(nums, res, combo, visited);
            visited.Remove(nums[i]);
            combo.RemoveAt(combo.Count-1);
        }
        return;
    }
}