public class Solution {
    public int CoinChange(int[] coins, int amount) {
        
        // Base case 1: Invalid inputs
        if (coins.Length == 0 && (amount < 0 || amount > 0)) {
            return -1;
        }
        
        // Base case 2: We don't need coins to hit the target.
        if (coins.Length == 0 && amount == 0) {
            return 0;
        }
        
        // We need a starting point to store the solutions.
        var soln = new int[amount+1];
        
        // Fill the solution array with invalid flag values. In this case, we could fill it with -1, but better to fill it with amount+1
        var invalid = amount+1;
        for (int k = 0; k < soln.Length; k++) {
            soln[k] = invalid;
        }
        
        // Now that we've prefilled the values, what is the amoutn of coins at the start of iteration?
        // Definitely 0.
        soln[0] = 0;
        
        // For each entry, we do a bottom up build of the smallest amount of coins at each target amount.
        for (int i = 1; i < soln.Length; i++) {
            var minSoFar = Int32.MaxValue;          
            // Recall CPSC 320, where the example we used was an unrolled version since we always had fixed type of coins.
            for (int j = 0; j < coins.Length; j++) {
                minSoFar = Math.Min(1 + SolnCheck(i-coins[j], soln, invalid), minSoFar);
            }            
            // Update that entry at the i-th index.
            soln[i] = minSoFar;
        }      
        return soln[soln.Length-1] > amount ? -1 : soln[soln.Length-1];    
    }
    
    // Check the previous stored values. We are going bottom up.
    private int SolnCheck(int idx, int[] soln, int invalid) {
        return idx < 0 ? invalid : soln[idx];
    }
}