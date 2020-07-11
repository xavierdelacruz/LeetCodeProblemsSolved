public class Solution {
    public int Reverse(int x) {
        
        if (x == 0 || x <= Int32.MinValue || x >= Int32.MaxValue) {
            return 0;
        }
        
        var isNegative = x < 0 ? true : false;
        x = isNegative ? x * -1 : x;
    
        StringBuilder sb = new StringBuilder();    
        while (x != 0) {
            sb.Append(x % 10);
            x = x / 10;
        }
        
        var result = Int64.Parse(sb.ToString());       
        result = isNegative ? result * -1 : result;
        
        if (result > Int32.MaxValue || result < Int32.MinValue) {
            return 0;
        }
        return (int) result;
    }   
}