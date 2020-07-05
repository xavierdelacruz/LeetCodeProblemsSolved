public class Solution {
    public void SolveSudoku(char[][] board) {
        // General idea is to do backtracking with the sudoku solver, because we need to:
        // Make a decision while following constraints
        // and have a goal.
        Solve(board, 0, 0);
    }
    
    // The time complexity on this is exponentail, as nxn boards will be NP-complete.
    // Note that the board is pass-by-reference. Hence, at every state, it is modified.
    private bool Solve(char[][] board, int row, int col) {
        
        // base case 1: Go to the next row.
        if (col == board.Length) {
            // Reset the columns back to the first
            col = 0;
            // Advance the row
            row++;
        }
        // Base case 2: We have now checked every row.
        // To have reached this far means we are done - return true. Otherwise, continue.
        if (row == board.Length) {
            return true;
        }
            
        // Case 1: if its an occupied cell, we cannot change it.
        // Keep advancing until we encounter an empty cell.    
        while (!board[row][col].Equals('.')) {
            return Solve(board, row, col+1);
        }
        
        // Case 2: It is an empty cell. Now each number will be tested on it.
        for (char c = '1'; c <= '9'; c++) {
            board[row][col] = c;
            // Just check THAT specific column, row, and grid
            // If that is a valid board, then check the 
            if (IsValidSudoku(board, row, col)) {
                if (Solve(board, row, col+1)) {
                    // In this case, once everythign returns as all true, we are good.
                    // This only happens when we've solved in the entire board.
                    return true;
                }              
            }
            // Change it back when it is invalid.
            board[row][col] = '.';           
        } 
        return false;
    }
    
    // Bounded by O(n^2)
    private bool IsValidSudoku(char[][] board, int row, int col) {
        
        // Check rows - that means the column stays fixed
        var rowSet = new HashSet<char>();
        for (int i = 0; i < board.Length; i++) {
            var currElemRow = board[i][col];
            if (!currElemRow.Equals('.') && rowSet.Contains(currElemRow)) {
                return false;
            } else if (!currElemRow.Equals('.') && !rowSet.Contains(currElemRow)) {
                rowSet.Add(currElemRow);
            }
        }
        
        // Check col - that means the column stays fixed
        var colSet = new HashSet<char>();
        for (int j = 0; j < board[row].Length; j++) {
            var currElemCol = board[row][j];
            if (!currElemCol.Equals('.') && colSet.Contains(currElemCol)) {
                return false;
            } else if (!currElemCol.Equals('.') && !colSet.Contains(currElemCol)) {
                colSet.Add(currElemCol);
            }
        }
        
        // Validate the grid.
        // Determine the grid it belongs in first.
        var rowStart = 0;
        var colStart = 0;
        // 3 <= row < 6
        if (row >= 3 && row < 6) {
            rowStart = 3;
        }
        // 6 <= row < 9
        if (row >= 6 && row < 9) {
            rowStart = 6;
        }
        // 3 <= col < 6
        if (col >= 3 && col < 6) {
            colStart = 3;
        }
        // 6 <= col < 9
        if (col >= 6 && col < 9) {
            colStart = 6;
        }
        
        var currGridSet = new HashSet<char>();
        for (int k = rowStart; k < rowStart + board.Length/3; k++) {
            for (int l = colStart; l < colStart + board.Length/3; l++) {
                var currElem = (char) board[k][l];
                if (!currElem.Equals('.') && currGridSet.Contains(currElem)) {
                        return false;                    
                } else if (!currElem.Equals('.') && !currGridSet.Contains(currElem)) {  
                    currGridSet.Add(currElem);  
                }
            }
        }
        return true;
    } 
}