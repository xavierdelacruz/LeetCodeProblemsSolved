public class Solution {
    public int MinPathSum(int[][] grid) {     
        
        if (grid.Length == 0) {
            return 0;
        }
        
        var soln = new int[grid.Length, grid[0].Length];
        soln[0,0] = grid[0][0];
        
        // Fill first row
        Console.WriteLine(grid[0].Length);
        for (int j = 1; j < grid[0].Length; j++) {
            soln[0,j] = grid[0][j] + soln[0,j-1];
        }
        
        // Fill first col
        for (int i = 1; i < grid.Length; i++) {
            soln[i,0] = grid[i][0] + soln[i-1,0];
        }
        
        // fill the rest of the array.
        // The idea is to check the previous upper value, and left value.
        // Think of "how many paths can I take, to get to this, and how much will it cost?"
        for (int k = 1; k < grid.Length; k++) {
            for (int l = 1; l < grid[0].Length; l++) {
                soln[k,l] = grid[k][l] + Math.Min(soln[k-1,l], soln[k,l-1]);
            }
        }     
        return soln[grid.Length-1,grid[0].Length-1];
    }   
}