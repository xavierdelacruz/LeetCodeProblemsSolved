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
    public int MaxPathSum(TreeNode root) {
        
        // No paths, since there are no nodes.
        if (root == null) {
            return 0;
        }
        
        // Only one path possible.
        if (root.left == null && root.right == null) {
            return root.val;
        }
        
        // This handles the case if all nodes had negative values.
        var max = Int32.MinValue;
        
        // There is no need to visit all nodes, since we bubble up with Post order.
        // This means that we are generating results of smaller subtrees as we go up.
        MaxPath(root, ref max);     
        return max;
        
    }
    
    private int MaxPath(TreeNode root, ref int max) {
        if (root == null) {
            return 0;
        }
        
        var left = MaxPath(root.left, ref max);
        var right = MaxPath(root.right, ref max);
        
        if (left > 0 && right > 0) {
            // Update max with the best possible left and right subtree paths, which pass through the current root.
            // Then return the best branch from this so far.
            max = Math.Max(max, root.val + left + right); 
            return Math.Max(root.val + right, root.val + left);
        } else if (left > 0 || right > 0) {     
            // Update max with the best possible subranch that exists with root
            // Then return the best branch so far
            max = Math.Max(max, Math.Max(root.val + right, root.val + left));
            return Math.Max(root.val + right, root.val + left);
        } else {
            // Otherwise, update max if the current root is better than what we've seen so far
            // Then return the value of root.
            max = Math.Max(root.val, max);            
            return root.val; 
        }           
    }
}