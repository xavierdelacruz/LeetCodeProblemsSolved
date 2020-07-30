/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<int> PostorderTraversal(TreeNode root) {
        
        var res = new List<int>();
        if (root == null) {
            return res;
        }
        
        var stack = new Stack<TreeNode>();
        if (root.right != null) {
            stack.Push(root.right);
        }
        stack.Push(root);
        root = root.left;
        
        while (stack.Count != 0) {
            
            while (root != null) {
                if (root.right != null) {
                    stack.Push(root.right);
                }
                stack.Push(root);
                root = root.left;
            }
            
            root = stack.Pop();
            
            // Check the right child of the currently popped root.
            // If it has one, it is going to be at the top of the stack
            // Put the currentlly pooped root back into the stack.
            // Start visiting all the chilren and subtrees of the right.
            if (root.right != null && stack.Count != 0 && root.right.Equals(stack.Peek())) {          
                var curr = stack.Pop();
                stack.Push(root);
                // Now set root to this, and traverse it all the way.
                root = curr;
            } else {
                res.Add(root.val);
                root = null;
            }
        }
        return res;
    }
}