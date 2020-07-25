public class Solution {
    public int MaxProfit(int[] prices) {
        
        if (prices.Length < 2) {
            return 0;
        }
        
        var i = 0;        
        var buy = Int32.MaxValue;
        var profit = 0;
        while (i < prices.Length) {            
            buy = Math.Min(prices[i], buy);          
            profit = Math.Max(prices[i] - buy, profit);
            
            i++;
        }      
        return profit;
    }
}