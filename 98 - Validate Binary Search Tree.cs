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
    public bool IsValidBST(TreeNode root) {       
        if (root == null) {
            return true;
        }
        
        // Perform Inorder DFS traversal - ITERATIVELY.
        // Note that we need to keep track of previous values.
        // We dont need to keep a list because it builds up slowly. The moment we have an issue, it terminates
        // Think of DP, using previous values.
        var stack = new Stack<TreeNode>();
        var prevVal = Int64.MinValue;
        TreeNode curr = root;
        
        // This visits every single node ONCE.
        // Hence O(n)
        while (stack.Count != 0 || root != null) {
            while (root != null) {
                // Keep pushing the left most nodes into the stack until you hit null.
                stack.Push(root);
                root = root.left;
            }
            
            // Start visiting them.
            root = stack.Pop();           
            if (prevVal >= (long) root.val) {
                return false;
            }
            prevVal = (long) root.val;
            
            // If they have right nodes, put them in the stack assuming they are not null.
            root = root.right;
        }   
        return true;  
    }  
}