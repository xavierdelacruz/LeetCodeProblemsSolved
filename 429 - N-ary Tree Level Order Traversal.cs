/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        var res = new List<IList<int>>();
        
        if (root == null) {
            return res;
        }
        
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        
        while (queue.Count != 0) {
            var qCount = queue.Count;     
            var list = new List<int>();           
            while (qCount > 0) {
                var curr = queue.Dequeue();
                qCount--;
                list.Add(curr.val);
                foreach (var child in curr.children) {
                    queue.Enqueue(child);
                }
            }
            res.Add(list);
        }
        
        return res;
    }
}