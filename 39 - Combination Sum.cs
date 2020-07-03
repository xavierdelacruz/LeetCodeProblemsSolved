public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        
        List<IList<int>> list = new List<IList<int>>();
        List<int> combination = new List<int>();
        
        // If these constraints are violated, return an empty list with another empty list.
        if (candidates.Length == 0 || target <= 0) {
            list.Add(combination);
            return list;
        }
    
        // Recursive backtracking solution. Checks and prunes solution spaces
        // We are doing top down (starting from target, until 0).
        CombinationSumHelper(candidates, combination, list, target, 0);

        return list;       
    }
    
    // Top down implementation
    private void CombinationSumHelper(int[] candidates, List<int> combination, List<IList<int>> list, int diff, int idx) {

        // By not having to start at i= 0 every recursive call, we can avoid duplicates, because we've already explored most of that in the first iteration.
       for (int i = idx; i < candidates.Length; i++) {
           var next = diff-candidates[i];
          
           // INVALID CASE
           // We will not bother recursing for the negative case. Early pruning.
           if (next < 0) {
               continue; 
           }
           
           // If next is not negative, then we add it to the combinations, as the other cases make it valid.
           combination.Add(candidates[i]);
           
           // CASE 1: GOAL
           // This prunes the search space ahead of time, rather than doing a recursive call then immediately returning.
           if (next == 0) {
               // In backtracking, we need to create a new list or object if we are modifying this element as we return the calls.         
               // In other words, if we dont make a new instance, the changes are modifying the references directly.
               list.Add(new List<int>(combination));    
           }
           
           // CASE 2: MAKE DECISION
           // In this case, since we did not reach the target yet. Hence, we need to recursively investigate
           if (next > 0) {
               CombinationSumHelper(candidates, combination, list, next, i); 
           }
            
           // Since the recursive call uses the combination list as pass by reference, we need to remove the last element added when we backtrack.
           combination.RemoveAt(combination.Count-1);       
        }                   
    }   

}