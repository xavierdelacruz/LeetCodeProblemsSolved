public class Solution {
    public int NumIslands(char[][] grid) {
        if (grid.Length == 0) {
            return 0;
        }
        
        var startPoints = GetStartPoints(grid);    
        // Keeps track of visited nodes.
        var claimed = new HashSet<(int x, int y)>();
        var visited = new HashSet<(int x, int y)>();
        var islands = 0;
        foreach (var start in startPoints) {
            
            // For DFS, change this to claimed
            if (!visited.Contains(start)) {
                //var visited = new HashSet<(int x, int y)>();
                DFS(grid, visited, claimed, start.x, start.y);
                //BFS(grid, visited, start.x, start.y);
                islands++;
            }         
        }   
        return islands;
    }
    
    private void DFS(char[][] grid, HashSet<(int x, int y)> visited, HashSet<(int x, int y)> claimed, int x, int y) {
        var dirs = new List<(int x, int y)>() { (1, 0), (-1, 0), (0, 1), (0, -1) };
        
        visited.Add((x, y));
        
        foreach (var dir in dirs) {
            var newX = x + dir.x;
            var newY = y + dir.y;
                
                // In BFS, set the node we are traversing as already-visited so we do not queue these nodes multiple times as we visit them.
            if (IsTraverseable(grid, visited, newX, newY)) {
                DFS(grid, visited, claimed, newX, newY);
                claimed.Add((newX, newY));
            }
        }     
    }
    
    private void BFS(char[][] grid, HashSet<(int x, int y)> visited, int x, int y) {    
        var dirs = new List<(int x, int y)>() { (1, 0), (-1, 0), (0, 1), (0, -1) };
        
        // Add the valid coordinate to the queue
        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((x, y));
        visited.Add((x, y));
        while (queue.Count != 0) {
            var curr = queue.Dequeue();       
            foreach (var dir in dirs) {
                var newX = curr.x + dir.x;
                var newY = curr.y + dir.y;
                
                // In BFS, set the node we are traversing as already-visited so we do not queue these nodes multiple times as we visit them.
                if (IsTraverseable(grid, visited, newX, newY)) {
                    queue.Enqueue((newX, newY));
                    visited.Add((newX, newY));
                }
            }
        }   
        return;
    }
    
    private bool IsTraverseable(char[][] grid, HashSet<(int x, int y)> visited, int x, int y) {
        return !visited.Contains((x, y)) && x >= 0 && x < grid.Length && y >= 0 && y < grid[0].Length && grid[x][y].Equals('1');
    }
    
    private HashSet<(int x, int y)> GetStartPoints(char[][] grid) {
        var startPts = new HashSet<(int x, int y)>();      
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (grid[i][j].Equals('1')) {
                    startPts.Add((i, j));
                }
            }
        }        
        return startPts;
    }
}