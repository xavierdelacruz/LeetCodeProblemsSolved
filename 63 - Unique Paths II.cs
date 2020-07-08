public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {

        if (obstacleGrid.Length == 0) {
            return 0;
        }
        
        if (obstacleGrid[0][0] == 1) {
            return 0;
        }
        
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        var soln = new int[m, n];
        
        soln[0,0] = 1;
        
        // Fixed col. Populate all rows with 1s, but start with 0's if an obstacle is encountered.
        var hasSeenRowObstacle = false;
        for (int i = 1; i < m; i++) {
            if (!hasSeenRowObstacle && obstacleGrid[i][0] == 1) {
                hasSeenRowObstacle = true;
            }
            
            if (!hasSeenRowObstacle) {
                soln[i,0] = 1;
            } else {
                soln[i,0] = 0;
            }
        }
        
        // Fixed row. Populate all cols with 1s, but start with 0's if an obstacle is encountered.
        var hasSeenColObstacle = false;
        for (int j = 1; j < n; j++) {
            if (!hasSeenColObstacle && obstacleGrid[0][j] == 1) {
                hasSeenColObstacle = true;
            }
            
            if (!hasSeenColObstacle) {
                soln[0,j] = 1;
            } else {
                soln[0,j] = 0;
            }
        }
        
        // Populate the DP array with previous results
        for (int k = 1; k < soln.GetLength(0); k++) {
            for (int l = 1; l < soln.GetLength(1); l++) {
                if (obstacleGrid[k][l] == 1) {
                    soln[k,l] = 0;
                } else {
                    soln[k,l] = soln[k-1,l] + soln[k, l-1];
                }
            }
        }
        return soln[soln.GetLength(0)-1, soln.GetLength(1)-1];
    }
}
