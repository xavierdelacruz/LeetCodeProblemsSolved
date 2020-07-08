public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        
        // Since we are using the duplicate skipping in 3Sum, we need to sort the array.
        Array.Sort(candidates);
        
        // Holds the results
        var result = new List<IList<int>>();
       
        if (candidates.Length == 0) {
            return result;
        }
        
        // Keep track of visited items via indexes.
        var visited = new HashSet<IList<int>>();
         var combo = new List<int>();

        CombinationSum2Helper(candidates, combo, result, target, 0);         
        
        return result; 
    }
    
    // Top down implementation
    private void CombinationSum2Helper(int[] candidates, List<int> combo, List<IList<int>> result, int target, int idx) {
        
        for (int i = idx; i < candidates.Length; i++) {
            
            var next = target - candidates[i];
            
            if (next < 0) {
                continue;
            }
            // If we have seen this element before, then ignore that element, and move onwards.
            // This was used in the 3-pointer solution fo 3 sum.
            if (i > idx && candidates[i] == candidates[i-1]) {
                continue;
            }
            
            combo.Add(candidates[i]);
            if (next == 0) {
                result.Add(new List<int>(combo));
            }
            
            if (next > 0) {
                CombinationSum2Helper(candidates, combo, result, target - candidates[i], i+1); 
            }
            
            combo.RemoveAt(combo.Count - 1);
        }        
    }
}