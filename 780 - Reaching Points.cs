public class Solution {
    public bool ReachingPoints(int sx, int sy, int tx, int ty) {

        // BFS solution. Search space is reduced by doing Euclidean division
        // Because we are looking at the greatest common denominators here (GCDs).
        // Starting from the target and subtrating can also work. 
        // This is the subtraction version of Euclidean division, but will result in TLE for edge cases.
        // Hence, we will use, which uses division: https://en.wikipedia.org/wiki/Euclidean_algorithm       
        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((tx, ty));
        
        while (queue.Count != 0) {
            var curr = queue.Dequeue();
            if (curr.y < sy || curr.x < sx) {
                break;
            }
            // The second check has to be done on edge cases where the mod result is 0.
            // This applies for edge cases such as tx = 1, and ty = 10^9 (TLE commonly happens)
            if (curr.y == sy && (curr.x - sx) % curr.y == 0) {
                return true;
            }
            
            if (curr.x == sx && (curr.y - sy) % curr.x == 0) {
                return true;
            } 
                
            // We always want to apply the mod to the largest numbert with the smaller one
            if (curr.x > curr.y) {
                curr.x = curr.x % curr.y;
                queue.Enqueue((curr.x, curr.y));
 
            } else {
                curr.y = curr.y % curr.x;
                queue.Enqueue((curr.x, curr.y));
            }
        }
        return false;
    }
}