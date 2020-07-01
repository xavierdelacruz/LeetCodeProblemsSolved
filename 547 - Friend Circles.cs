public class Solution {
    public int FindCircleNum(int[][] M) {
        
        // Assuming a valid input is always given.
        var length = M.Length;
        
        // Important to keep track of visited friends.
        var visited = new bool[length];
        
        // Tracks the number of netowrks
        var network = 0;
        
        // For each friend, visited each of their friends  by adding them to the queue if they have NOT been visited.
        for (int i = 0; i < length; i++) {          
            // We have already visited this person
            if (visited[i]) {  
                continue;
            }
            
            // Otherwise, we have not, and it is a new friend circle.            
            network++;
            // This is where the BFS algorithm starts.
            // Queue of the friend indexes
            var queue = new Queue<int>();
            queue.Enqueue(i);
            while (queue.Count != 0) {
                
                // Dequeue the current node and mark it as visited
                var curr = queue.Dequeue();
                visited[curr] = true;
                
                // Visit all friends, except itself.
                for (int j = 0; j < length; j++) {
                    if (!visited[j] && M[curr][j] == 1) {
                        // Queue that friend up to visit them
                        // We have to visit friends so we know if they other friends that can be indirect.
                        queue.Enqueue(j);
                    }                 
                }
            }  
        }        
        return network;
    }
}








