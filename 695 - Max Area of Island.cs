public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
      // BC1
        if (grid.Length == 0) {
            return 0;
        }

        int maxAreaSoFar = 0; 
        var startPts = FindStartPoints(grid);
      // BFS-visited coordinates.
        var visited = new HashSet<(int x, int y)>();
  
      foreach (var start in startPts) {
        if (!visited.Contains(start)) {
          // BFS
          var count = VisitIsland(grid, visited, start.x, start.y);
          maxAreaSoFar = Math.Max(maxAreaSoFar, count);
        }   
  }
  //for loop in each start point
  // Only perform BFS if (
  return maxAreaSoFar; 
}

private int VisitIsland(int[][] grid, HashSet<(int x, int y)> visited, int x, int y) {
  
  var dirs = new List<(int x, int y)>() { (1, 0), (-1, 0), (0, 1), (0, -1) };
  
  var q = new Queue<(int x, int y)>();
  q.Enqueue((x, y));
  visited.Add((x, y));
  int count = 1;
  while (q.Count != 0) {
  	var curr = q.Dequeue();
    foreach (var dir in dirs) {
    	var newX = curr.x + dir.x;
      var newY = curr.y + dir.y;
      if (IsTraverseable(grid, visited, newX, newY)) {
      	q.Enqueue((newX, newY));
        visited.Add((newX, newY));
        count++;
      }
    }
  }
  return count;
}

private bool IsTraverseable(int[][] grid, HashSet<(int x, int y)> visited, int x, int y) {
	if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length || visited.Contains((x, y)) || grid[x][y] == 0) {
  	return false;
  }
  return true;
}

private HashSet<(int x, int y)> FindStartPoints(int[][] grid) {
  var res = new HashSet<(int x, int y)>();
	for (int i = 0; i < grid.Length; i++) {
  	for (int j = 0; j < grid[i].Length; j++) {
      if (grid[i][j] == 1) {
      	res.Add((i, j));
      }
    }
  }
  return res;
    }
}