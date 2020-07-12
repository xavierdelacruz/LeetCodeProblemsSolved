public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
          
        // BASE CASE 1: If n <= 0, return an empty list.
        var result = new List<int>(); 
        if (n <= 0) {
            return result;
        }
        
        // BASE CASE 2: If no edges, and n > 2, return an empty list.
        if (n > 2 && edges.Length == 0) {
            return result;
        }
        
        // BASE CASE 2: If no edges, and 1 <= n <= 2, return one or two nodes.
        // I honestly find this odd. It should just be empty based on the criteria.
        if (n <= 2 && edges.Length == 0) {
            result.Add(0);
            if (n == 2) {
                result.Add(1);
            }         
            return result;
        }
        
        // This will represent mappings of each vertex to a set of all adjacent nodes.
        // O(n) entries, with O(n) traversals, technically.
        // This graph info will contain the indegrees (the number of nodes pointing to it).
        // Since this graph is undirected, then it will be the number of children.
        var graph = new Dictionary<int, HashSet<int>>();
        CreateGraph(graph, edges);
        for (int i = 0; i < n; i++) {
            if (graph.ContainsKey(i) && graph[i].Count == 1) {
                result.Add(i);
            }
        }
        
        // Strategy is to use BFS to slowly prune the leaves. This will create new leaves.
        // When we have 2 or less nodes to visit, then we return those.
        var center = n;
        while (true) {
            
            // We found our qualifying centers, 1 if there are odd centers
            // 2 if there are even centers.
            if (center <= 2) {
                break;
            }
            var leafCount = result.Count;    
            center -= leafCount;

            var nextResult = new List<int>();
            foreach (var leaf in result) {
                leafCount--;
                
                // Each leaf has a single neighbor, hence why they are leaves.
                var neighbor = graph[leaf].First();
                
                // Now, we take that neighbor and lookup the graph dict to remove our current leaf
                // from its set - which we are guaranteed to be part of, since we have visited it already.
                var neighbors = graph[neighbor];
                neighbors.Remove(leaf);
                
                if (graph[neighbor].Count == 1)  {
                    nextResult.Add(neighbor);
                }
                
                // Since lists cannot be mutated (ie. We cannot remove what we have visited)
                result = nextResult;
            }
        }
        // The result would be the most central node / nodes, as they would be the most minimal in terms of distance.
        return result;
    }
    
    private void CreateGraph(Dictionary<int, HashSet<int>> graph, int[][] edges) {
        for (int i = 0; i < edges.Length; i++) {
            var vertex1 = edges[i][0];
            var vertex2 = edges[i][1];
            if (!graph.ContainsKey(vertex1)) {
                graph.Add(vertex1, new HashSet<int>() {vertex2});
            } else {
                graph[vertex1].Add(vertex2);
            }
            
            if (!graph.ContainsKey(vertex2)) {
                graph.Add(vertex2, new HashSet<int>() {vertex1});
            } else {
                graph[vertex2].Add(vertex1);
            }
        }
    }
}