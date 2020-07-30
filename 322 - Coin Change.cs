public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if (amount < 1) {
            return 0;
        }
        
        if (coins.Length == 0) {
            return -1;
        }
        
        var soln = new int[amount+1];
        soln[0] = 0;        
        for (int i = 1; i < soln.Length; i++) {
            var minSoFar = amount+1;
            foreach (var coin in coins) {
                var idx = i - coin;
                
                if (idx < 0) {
                    continue;
                }               
                minSoFar = Math.Min(minSoFar, 1 + soln[idx]);               
            }
            soln[i] = minSoFar;
        }       
        return soln[amount] == amount+1 ? -1 : soln[amount];
    }
}