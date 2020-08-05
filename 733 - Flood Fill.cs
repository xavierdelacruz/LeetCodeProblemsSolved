public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
        // BASE CASE 1: Invalid inputs for colour and image
        if (newColor < 0 || newColor > 65535 || image.Length == 0) {
            return image;          
        }
        
        // BASE CASE 2: Invalid start point
        if (sr < 0 || sr >= image.Length || sc < 0 || sc >= image[0].Length) {
            return image;
        }

        // If the start and endpoint are the same, no flooding will occur. 
        if (image[sr][sc] == newColor) {
            return image;
        }
        
        BFS(image, sr, sc, newColor);
        
        return image;
        
    }
    
    private void BFS(int[][] image, int x, int y, int newColour) {
        // Can also use List with implicit object of (x, y) directions.
        var rows = new int[] { 1, 0, -1, 0};
        var cols = new int[] { 0, 1, 0, -1};
        
        var currColour = image[x][y];
        image[x][y] = newColour;
        var q = new Queue<(int x, int y)>();
        q.Enqueue((x, y));
        
        while (q.Count != 0) {
            var curr = q.Dequeue();
            
            for (int i = 0; i < rows.Length; i++) {               
                var newX = rows[i] + curr.x;
                var newY = cols[i] + curr.y;

                if (IsTraverseable(image, newX, newY, currColour)) {
                    q.Enqueue((newX, newY));
                    image[newX][newY] = newColour;
                }
            }
        }
    }
    
    private bool IsTraverseable(int[][] image, int x, int y, int currColour) {
        if (x < 0 || x >= image.Length || y < 0 || y >= image[0].Length || image[x][y] != currColour) {
            return false;
        }
        return true;
    }
}