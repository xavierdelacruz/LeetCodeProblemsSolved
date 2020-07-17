public class Solution {
    public void Solve(char[][] board) {
        
        if (board.Length == 0) {
            return;
        }
               
        // Find All Bad points, and change htem to #
        // This is using BFS (or DFS). O(MN) at most.
        MarkBad(board);

        for (int i = 0; i < board.Length; i++) {
            for (int j = 0; j < board[i].Length; j++) {
                if (board[i][j].Equals('O')) {
                    board[i][j] = 'X';
                }      
                
                if (board[i][j].Equals('#')) {
                    board[i][j] = 'O';
                }
            }
        }
    }
    
    // Main BFS Algorithm.
    private void MarkBadBFS(char[][] board, HashSet<(int x, int y)> visited, int x, int y) {
        var dirs = new List<(int x, int y)>() { (0, 1), (0, -1), (1, 0), (-1, 0) };      
        var q = new Queue<(int x, int y)>();
        q.Enqueue((x, y));
        visited.Add((x, y));
        while (q.Count != 0) {
            var curr = q.Dequeue();
            board[curr.x][curr.y] = '#';
            foreach (var dir in dirs) {
                var newX = curr.x + dir.x;
                var newY = curr.y + dir.y;
                if (IsTraverseable(board, visited, newX, newY)) {
                    q.Enqueue((newX, newY));
                    visited.Add((newX, newY));
                }
            }
        }
    }
    
    private bool IsTraverseable(char[][] board, HashSet<(int x, int y)> visited, int x, int y) {        
        if (x < 0 || x >= board.Length || y < 0 || y >= board[0].Length || visited.Contains((x, y)) || board[x][y].Equals('X')) {
            return false;
        }       
        return true;    
    }
    
    private void MarkBad(char[][] board) {    
        var startCol = 0;
        var endCol = board[0].Length-1;
        var visited = new HashSet<(int x, int y)>(); 
        for (int i = 0; i < board.Length; i++) {
            if (board[i][startCol].Equals('O') && !visited.Contains((i, startCol))) {
                MarkBadBFS(board, visited, i, startCol);
            }
            
            if (board[i][endCol].Equals('O') && !visited.Contains((i, endCol))) {
                MarkBadBFS(board, visited, i, endCol);
            }
        }
        
        var startRow = 0;
        var endRow = board.Length-1;       
        for (int j = 0; j < board[0].Length; j++) {
            if (board[startRow][j].Equals('O') && !visited.Contains((startRow, j))) { 
                MarkBadBFS(board, visited, startRow, j);
            }
            
            if (board[endRow][j].Equals('O') && !visited.Contains((endRow, j))) {
                MarkBadBFS(board, visited, endRow, j);
            }
        }
    }
}