public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        
        if (triangle.Count == 0) {
            return 0;
        }
        
        if (triangle.Count == 1) {
            return triangle[0][0];
        }

        var minSoFar = Int32.MaxValue;
        for (int i = 1; i < triangle.Count; i++) {
            for (int j = 0; j < triangle[i].Count; j++) {
                // Get the current value triangle[j], then add with the j-1 or j at i-1
                var curr = triangle[i][j];           
                if (j == 0) {
                    triangle[i][j] = curr + triangle[i-1][j];
                } else if (j == triangle[i].Count-1) {
                    triangle[i][j] = curr + triangle[i-1][j-1];
                } else {
                    triangle[i][j] = Math.Min(curr + triangle[i-1][j], curr + triangle[i-1][j-1]);
                }
                 
                // Get the best minimum so far at row i = length-1 (aka the last row).
                // We'll have our answer there, in the last row.
                if (i == triangle.Count-1) {
                    minSoFar = Math.Min(minSoFar, triangle[i][j]);
                }
                
            }
        }  
        return minSoFar;
    }
}