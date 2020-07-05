public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        
        if (matrix.Length <= 0) {
            return false;
        }
        
        // Scan the first row and col to see where the starting point may be.
        var rowStart = 0;

        // O(n)
        for (int i = 0; i < matrix.Length; i++) {            
            if (matrix[i].Length == 0) {
                return false;
            }
            
            if (matrix[i][0] < target) {
                rowStart = i;
                continue;
            }
            
            if (target == matrix[i][0]) {
                return true;
            }
            
            if (matrix[i][0] > target) {
                break;
            }
        }
        
        // O(n)
        // We now know which row. Just search that entire row.
        for (int j = 0; j < matrix[rowStart].Length; j++) {          
            if (target == matrix[rowStart][j]) {
                return true;
            }          
        }    
        return false;    
    }
}