public class Solution {
    public int[][] UpdateMatrix(int[][] matrix) {
        if (matrix.Length == 0) {
            return matrix;
        }
        
        var startPts = FindStartPts(matrix);
        
        foreach (var startPt in startPts) {
            var x = startPt.x;
            var y = startPt.y;
            
            BFS(matrix, x, y);
        }
        
        return matrix;
    }
    
    private HashSet<(int x, int y)> FindStartPts(int[][] grid) {
        
        var startPts = new HashSet<(int x, int y)>();
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (grid[i][j] == 1) {
                    startPts.Add((i, j));
                }
            }
        }
        
        return startPts;
    }
    
    private void BFS(int[][] grid, int x, int y) {
        var dirs = new List<(int x, int y)>() {(1, 0), (-1, 0), (0, 1), (0, -1)}; 
        var visited = new HashSet<(int x, int y)>();
        var queue = new Queue<(int x, int y)>();
        
        int shortestDistance = -1;
        grid[x][y] = shortestDistance;
        visited.Add((x, y));
        queue.Enqueue((x, y));
        
        while (queue.Count != 0) {
            
            var qCount = queue.Count;
            shortestDistance++;
            
            while (qCount > 0) {
                var curr = queue.Dequeue();
                qCount--;
                foreach (var dir in dirs) {
                    var newX = curr.x + dir.x;
                    var newY = curr.y + dir.y;
                    
                    if (IsTraverseable(grid, newX, newY, visited)) {                 
                        if (grid[newX][newY] == 0) {
                            grid[x][y] = shortestDistance+1;
                            return;
                        }
                        
                        queue.Enqueue((newX, newY));
                        visited.Add((newX, newY));
                    }
                }
            }          
        }
        return;
    }
    
    private bool IsTraverseable(int[][] grid, int x, int y, HashSet<(int x, int y)> visited) {
        if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length || visited.Contains((x, y))) {
            return false;
        }
        
        return true;
    }
}