/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        
        if (root == null) {
            return root;
        }
        
        // If we find that root is either one of the bounds
        // Then we found our answer.
        if (root == p || root == q) {
            return root;
        }
        
        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);
        
        // If we find BOTH nodes from a given root, then this is the LCA.
        // Otherwise, if we only find one, just return that one and bubble it up
        // This lets the call stack know that we found something.
        if (left != null && right == null) {
            return left;
        } else if (left == null && right != null) {
            return right;
        } else if (left != null && right != null) {
            return root;
        }
        return null;
    }  
}