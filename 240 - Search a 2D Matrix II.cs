public class Solution {
    public bool SearchMatrix(int[,] matrix, int target) {
        
        int row = matrix.GetLength(0);
        int col = matrix.GetLength(1);
        // We have an empty array row dimension, which implies it is an empty array
        if (row == 0 || col == 0) {
            return false;
        }
        
        // We have to start at either the upper right, or lower left corners to have directed values.
        int i = row-1;
        int j = 0;
        
        while (i >= 0 && j < col) {
            if (matrix[i,j] > target) {
                i--;
                continue;
            }
            
            if (matrix[i, j] < target) {
                j++;
                continue;
            }
            
            if (matrix[i,j] == target) {
                return true;
            }
        }
        
        return false;
    }
}