public class Solution {
    public bool IsValidSudoku(char[][] board) {
        
        // Keeps track of visited grids (once we have fully traversed)
        var visited = new HashSet<(int i, int j)>();
        
        // Bounded by O(n^3)
        for (int i = 0; i < board.Length; i++) {
            // Reset backt empty set when we move to the next row, which also means we reset the columns too.
            var currRowSet = new HashSet<char>();
            var currColSet = new HashSet<char>();
            for (int j = 0; j < board[i].Length; j++) {
                var currElemRow = (char) board[i][j];
                var currElemCol = (char) board[j][i];
                
                // Case 1: We've seen this in the entire row already. Return false
                if (!currElemRow.Equals('.') && currRowSet.Contains(currElemRow)) {
                    return false;
                // Case 2: Otherwise, we have not seen it in this row, add to set of visited row elems
                } else if (!currElemRow.Equals('.') && !currRowSet.Contains(currElemRow)) {
                    currRowSet.Add(currElemRow);
                }
                
                // Case 3: We've seen this in the entire row already. Return false
                if (!currElemCol.Equals('.') && currColSet.Contains(currElemCol)) {
                    return false;
                // Case 4: Otherwise, we have not seen it in this col, add to set of visited col elems
                } else if (!currElemCol.Equals('.') && !currColSet.Contains(currElemCol)) {
                    currColSet.Add(currElemCol);
                    
                }
                
                var rowStart = 0;
                var colStart = 0;
                // 3 <= row < 6
                if (i >= 3 && i < 6) {
                    rowStart = 3;
                }
                // 6 <= row < 9
                if (i >= 6 && i < 9) {
                    rowStart = 6;
                }
                // 3 <= col < 6
                if (j >= 3 && j < 6) {
                    colStart = 3;
                }
                // 6 <= col < 9
                if (j >= 6 && j < 9) {
                    colStart = 6;
                }
                
                if (visited.Contains((rowStart, colStart))) {
                    continue;
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
                
                visited.Add((rowStart, colStart));
            }
        }
        // All rows and cols check out
        return true;
    } 
}