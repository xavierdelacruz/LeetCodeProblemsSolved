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
    public int FindTilt(TreeNode root) {
        if (root == null) {
            return 0;
        }
        
        var tilt = 0;
        FindTiltHelper(root, ref tilt);
        return tilt;
    }
    
    private int FindTiltHelper(TreeNode root, ref int tilt) {
        if (root == null) {
            return 0;
        }
        
        var left = FindTiltHelper(root.left, ref tilt);
        var right = FindTiltHelper(root.right, ref tilt);
        
        // Update tilt so far.
        tilt = tilt + Math.Abs(right-left);
        
        // Now return the entire weight of the tree
        // This will be recursive since it will go back up along the call stack.
        return root.val + left + right;
    }
}