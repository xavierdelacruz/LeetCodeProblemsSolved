public class Solution {
    public bool Exist(char[][] board, string word) {
        
        if (board.Length == 0) {
            return false;
        }
        
        if (string.IsNullOrEmpty(word)) {
            return false;
        }
        
        // Takes the first character of target word.
        // This will be important for looking at starting points during iteration.
        var start = word[0];
        
        for (int i = 0; i < board.Length; i++) {
            for (int j = 0; j < board[i].Length; j++) {
                if (board[i][j].Equals(start)) {
                    // Do backtracking here
                    // Could also use a nxm boolean array to set true or false on the indexes. Either works. O(1) access.
                    // However, hashset will use less memory since it only stores that has to be stored.
                    var visited = new HashSet<(int x, int y)>();
                    var sb = new StringBuilder();
                    sb.Append(board[i][j]);
                    if (ExistHelper(board, visited, word, 0, sb, i, j)) {
                        return true;
                    }
                }
            }
        }
        
        // If we do not see any of the words, return false
        return false;
    }
    
    private bool ExistHelper(char[][] board, HashSet<(int x, int y)> visited, string targetWord, int targetIdx, StringBuilder currWord, int x, int y) {
        var dirs = new List<(int x, int y)>() { (1, 0), (-1, 0), (0, 1), (0, -1) };
        
        if (currWord.ToString().Length > targetWord.Length) {
            return false;
        }
        
        if (!board[x][y].Equals(targetWord[targetIdx])) {
            return false;
        }
        
        if (currWord.ToString().Equals(targetWord)) {
            return true;
        }
        
        var res = false;
        visited.Add((x, y));
        foreach (var dir in dirs) {
            
            var newX = x + dir.x;
            var newY = y + dir.y;
            if (IsTraverseable(board, newX, newY, visited)) {                
                currWord.Append(board[newX][newY]);              
                res = res || ExistHelper(board, visited, targetWord, targetIdx+1, currWord, newX, newY);
                currWord.Remove(currWord.Length-1, 1);
            }       
        }
        
        // By removing it from visited, we can revisit it on another iteration.
        visited.Remove((x, y));
        return res;
    }
    
    private bool IsTraverseable(char[][] board, int x, int y, HashSet<(int x, int y)> visited) {
        if (x < 0 || x >= board.Length || y < 0 || y >= board[0].Length || visited.Contains((x, y))) {
            return false;
        }        
        return true; 
    }
}