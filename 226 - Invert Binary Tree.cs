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
    public TreeNode InvertTree(TreeNode root) {
        
        // BASE CASE 1: Root does not exist. Return null or root.
        if (root == null) {
            return root;
        }
        
        // Use helper to now investigate subtrees.
        // Go all the way down and bubble the changes.
        // Post Order traversal, which starts at the bottom, and bubbles the changes up.
        var left = InvertTree(root.left);
        var right = InvertTree(root.right);
        
        root.right = left;
        root.left = right;
        
        return root;  
    }   
}