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
    public bool IsSubtree(TreeNode s, TreeNode t) {
        // Ideally is to see if its the same tree once we find the same subnodes.
        
        if (s == null && t == null) {
            return true;
        }
        
        if (s == null || t == null) {
            return false;
        }
        
        // At each moment it is equal to some node, check if its the same tree. If so, return true
        // The result bubbles up the recursion stack. This will handle edge cases
        // with a long chain of 'start points', and arrive to a correct conclusion.
        return false || IsSubtree(s.left, t) || IsSubtree(s.right, t) || IsSameTree(s, t);
    }
    
    private bool IsSameTree(TreeNode s, TreeNode t) {
        
        if (s == null && t == null) {
            return true;
        }
        
        if (s == null || t == null) {
            return false;
        }
        
        if (s.val != t.val) {
            return false;
        }
        
        return true && IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right);
    }
}