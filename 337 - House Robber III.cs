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
    public int Rob(TreeNode root) {
        if (root == null) {
            return 0;
        }
        
        var result = PostOrderDFS(root);
        
        // Finally, return the best result from either the value counting the root, or the total of the grand children subtrees.
        return Math.Max(result.subTreeChildrenTotal, result.subTreegrandchildrenTotal);
    }
    
    // Approach: Post-Order bubbling up
    // Find the max between the root + grandchilren subtree totals, or the direct children and their own totals.
    private (int subTreeChildrenTotal, int subTreegrandchildrenTotal) PostOrderDFS(TreeNode root) {
        if (root == null) {
            return (0, 0);
        }
        
        var left = PostOrderDFS(root.left);
        var right = PostOrderDFS(root.right);
        
        // This represents the adjacent children total. This represents soln[i] + soln[i-2] in DP.
        var childrenRes = root.val + left.subTreegrandchildrenTotal + right.subTreegrandchildrenTotal;
        
        // Find the best result from either, and it will be the new subtree child total that will bubble up.
        // This represents soln[i-1] in DP
        var grandchildrenRes = left.subTreeChildrenTotal + right.subTreeChildrenTotal;
        
        // This is the same as taking Math.Max(soln[i-1], root.val + soln[i-2]);
        var bestTotal = Math.Max(childrenRes, grandchildrenRes);
        
        // Return both the best total, and the grandchilren below it for the next evaluation
        return (bestTotal, grandchildrenRes);
    }
}