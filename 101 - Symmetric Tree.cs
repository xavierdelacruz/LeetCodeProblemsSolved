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
    public bool IsSymmetric(TreeNode root) {
        if (root == null) {
            return true;
        }
        
        // Explore the right and right subtrees from here on.
        return IsSymmetricHelper(root.left, root.right);
    }
    
    // This ensures that the two nodes that are mirrored are equal in value
    // at each level.
    private bool IsSymmetricHelper(TreeNode left, TreeNode right) {   
        // Both are null. Return true.
        if (right == null && left == null) {
            return true;
        }
        
        // One of them is null. Return false
        if (right == null || left == null) {
            return false;
        }
        
        // Values are do not match. Return false
        if (right.val != left.val) {
            return false;
        }
        
        // Now check matching substrees that should mirror each other.
        return IsSymmetricHelper(left.left, right.right)
            && IsSymmetricHelper(left.right, right.left);
    }
}