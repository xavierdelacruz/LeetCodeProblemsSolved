public class Solution {
    public int Change(int amount, int[] coins) {
        
        // At any given moment when the amount is 0, then no matter how many coins I have, I always return 1.
        // Why? Because there is only one way to do this, which is not using any coins at all. This COUNTS as a way.
        if ((coins.Length >= 0 && amount <= 0)) {
            return 1;
        }
        
        // Make a 2D solution array. The +1 serves to cover the base cases that we've observed earlier.
        var soln = new int[coins.Length+1, amount+1];
        
        // This is the entry where we have no coins, and 0 amount. There is only one way, which is not using any coins.
        soln[0,0] = 1;
        
        // Fill the top row with the correct values, where if we have no coins - but some non zero target. This means we have no ways.
        for (int i = 1; i < amount + 1; i++) {
            soln[0,i] = 0; 
        }
        
        // Fill the first column with the correct values, where if we have an amount 0 despite having many coins - there is ONE WAY.
        // That way ONE WAY counts as returning no coins.
        for (int j = 1; j < coins.Length+1; j++) {
            soln[j,0] = 1;
        }
        
        
        // The approach in DP now is using previously answered questions. For example, if we only have a 1 coin, and we want to get an amount of 1
        // Then there is only one way to do it. If we [1,2] coins, and we have an amount of 4 - then consider this:
        // If we only use 1 coins, we only have 1 way to do it, which is 1+1+1+1. If we use a 2 coin, we have 4-2 = 2 amount left remaining. How many ways can we get an amount 2 with [1,2] coins?
        // There's 2 ways, which is 1+1, and 2. So in total, we have 1 (using only 1 coins) + 2 ways (using 1 and 2 coins) = 3 ways to get an amount of 4.     
        for (int row = 1; row < coins.Length+1; row++) {
            for (int col = 1; col < amount+1; col++) {
                if (col-coins[row-1] >= 0) {
                    soln[row,col] = soln[row-1, col] + soln[row, col-coins[row-1]];
                } else {
                    soln[row,col] = soln[row-1, col];
                }
            }
        } 
        return soln[coins.Length, amount];
    }
}