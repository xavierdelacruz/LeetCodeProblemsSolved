public class Solution {
    public int UniquePaths(int m, int n) {      
        if (m == 0 || n == 0) {
            return 0;
        }
        
        var soln = new int[m, n];
        
        // It is 0 since there are no paths.
        soln[0,0] = 0; 
        
        // There is only one way to get to the bottom grids at col 0,
        // since there is no going back up or left.
        for (int i = 0; i < m; i++) {
            soln[i, 0] = 1;
        }
        
        // There is only one way to get to the rightmost grids at row 0,
        // since there is no going back up or left.
        for (int j = 0; j < n; j++) {
            soln[0, j] = 1;
        }
        
        // We can now use the relationship based on directions.
        for (int k = 1; k < m; k++) {
            for (int l = 1; l < n; l++) {
                soln[k, l] = soln[k-1, l] + soln[k, l-1];
            }
        }
           
        return soln[m-1, n-1]; 
        
        // BACKTRACKING. WORKS BUT TLE at higher numbers.
        // var visited = new HashSet<(int x, int y)>();
        // int count = 0;
        // FindAllUniquePaths(m, n, 0, 0, visited, ref count);
        // return count;
    }
    
    // Backtracking implementation. This is exponential, however. So it will result in a TLE. O(2^n) since its 2 branches.
    private void FindAllUniquePaths(int m, int n, int x, int y, HashSet<(int x, int y)> visited, ref int count) {
        var dir = new List<(int x, int y)> { (1, 0), (0, 1)};
        
        if (x == m-1 && y == n-1) {
            count++;
            return;
        }
        visited.Add((x, y));
        // Try each direction.
        for (int i = 0; i < dir.Count; i++) {
            var newX = x + dir[i].x;
            var newY = y + dir[i].y;
            if (IsTraverseable(newX, newY, m, n, visited)) {
                FindAllUniquePaths(m, n, newX, newY, visited, ref count);
            }
        }       
        visited.Remove((x,y));
        return;  
    }
    
    private bool IsTraverseable(int x, int y, int m, int n, HashSet<(int x, int y)> visited) {
        return x >= 0 && x < m && y >= 0 && y < n && !visited.Contains((x, y));
    }
}