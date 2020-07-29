public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        
        if (triangle.Count == 0) {
            return 0;
        }
        
        if (triangle.Count == 1) {
            return triangle[0][0];
        }
        // Bottom length
        var length = triangle.Count;
        var maxWidth = triangle[length-1].Count;    
        var soln = new int[length, maxWidth];
        PopulateSolnArr(soln, triangle);
 
        soln[0,0] = triangle[0][0];
        var minSoFar = Int32.MaxValue;
        for (int i = 1; i < length; i++) {
            for (int j = 0; j < triangle[i].Count; j++) {
                // Get the current value triangle[j], then add with the j-1 or j at i-1
                var curr = triangle[i][j];           
                if (j == 0) {
                    soln[i, j] = curr + soln[i-1, j];
                } else if (j == triangle[i].Count-1) {
                   soln[i, j] = curr + soln[i-1, j-1];
                } else {
                     soln[i, j] = Math.Min(curr + soln[i-1, j], curr + soln[i-1, j-1]);
                }
                 
                // Get the best minimum so far at row i = length-1 (aka the last row).
                // We'll have our answer there, in the last row.
                if (i == length-1) {
                    minSoFar = Math.Min(minSoFar, soln[i, j]);
                }
                
            }
        }  
        return minSoFar;
    }
    
    private void PopulateSolnArr(int[,] soln, IList<IList<int>> triangle) {
        for (int i = 0; i < triangle.Count; i++) {
            for (int j = 0; j < triangle[i].Count; j++) {
                soln[i, j] = Int32.MaxValue;
            }
        }       
        return;
    }
}