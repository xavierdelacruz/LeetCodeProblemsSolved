public class Solution {
    public int GetMaximumGold(int[][] grid) {
        
        if (grid.Length == 0) {
            return 0;
        }
        
        var largestGoldSoFar = 0;
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (grid[i][j] != 0) {
                    // Instantiate a new hashset every time we visit a non-zero entry
                    var visited = new HashSet<(int x, int y)>();
                    largestGoldSoFar = Math.Max(DFS((i, j), visited, 0, grid), largestGoldSoFar); 
                }
            }
        }
      
        return largestGoldSoFar;
    }
    
    // For each starting point, do a DFS, since we do not know how many things are connected.
    private int DFS((int x, int y) node, HashSet<(int x, int y)> visited, int gold, int[][] grid) {
        var directions = new List<(int x, int y)>() {(1,0), (-1,0), (0,1), (0,-1)};   
        gold += grid[node.x][node.y];
        visited.Add(node);
        
        // Make our maxSoFar as much as the current gold we have.
        var maxSoFar = gold;
        for (int i = 0; i < directions.Count; i++) {     
            var next = (node.x + directions[i].x, node.y + directions[i].y);  
            if (IsTraverseable(next, grid, visited)) {       
                maxSoFar = Math.Max(DFS(next, visited, gold, grid), maxSoFar);
            }         
        }
        // In backtracking, we need to remove it from our visited
        // Since there is a chance we may visit it again.
        visited.Remove(node);
        return maxSoFar; 
    }
    
    private bool IsTraverseable((int x, int y) node, int[][] grid, HashSet<(int x, int y)> visited) {       
        if (node.x >= grid.Length || node.x < 0 || node.y >= grid[0].Length || node.y < 0) {
            return false;
        }
        
        if (visited.Contains(node)) { 
            return false; 
        }
        
        if (grid[node.x][node.y] == 0) { 
            return false;
        }   
        return true; 
    }
}