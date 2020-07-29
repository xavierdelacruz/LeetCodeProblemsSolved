public class Solution {
    public int CombinationSum4(int[] nums, int target) {
        if (nums.Length == 0) {
            return 0;
        }
        
        // DP question: In how many ways can I get to the target, for each element? Implies its a double for loop.
        // Runtime: O(target+1 * nums)
        var soln = new int[target+1];
        
        // There is only ONE way to get to a 0. It's by doing nothing. Doing nothing counts as 1.
        soln[0] = 1;
        
        for (int i = 1; i < soln.Length; i++) {
            var curr = 0;          
            for (int j = 0; j < nums.Length; j++) {
                // This is similar to asking:
                // "I have target = 3, and im looking at element 2. idx = 3-2 = 1. Let's take a look at soln[1]"
                var idx = i-nums[j];
                
                // Ignore all negative indexes
                if (idx >= 0) { 
                    curr += soln[idx];
                }
            }
            // Finally, update the solution array
            soln[i] += curr;
        }  
        return soln[target];
    } 
}