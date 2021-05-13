/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        
        if (root == null) {
            return root;
        }
        
        // Perform a BFS traversal.
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);
       
        while (q.Count > 0) {
            
            // keeps track of the number of nodes in the layer.
            int qCount = q.Count;
            Node prev = null;
            
            while (qCount >= 0) {
                
                // If we reach the end of the current level, set the last seen node's next to null
                if (qCount == 0) {
                    prev.next = null;
                    break;
                }
                
                Node curr = q.Dequeue();
                
                // Set the previously dequeued Node to the curr one.
                if (prev != null) {
                    prev.next = curr;
                }
                
                // Then update prev into the current node.
                prev = curr;
                qCount--;

                if (curr.left != null) {
                    q.Enqueue(curr.left);
                }

                if (curr.right != null) {
                    q.Enqueue(curr.right);
                }   
            }    
        }
        return root;
    }
}