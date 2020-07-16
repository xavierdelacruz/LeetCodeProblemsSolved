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
        
        if (root == null) {
            return 0;
        }        
        var maxSum = Int32.MinValue;
        FindSum(root, ref maxSum);            
        return maxSum;
    }
    
    // Using post order traversal.
    // Calculate the rest on-the-go as we traverse the tree.
    private int FindSum(TreeNode root, ref int sum) {
        if (root == null) {
            return 0;
        }  
        var left = FindSum(root.left, ref sum);
        var right = FindSum(root.right, ref sum);
        
        // CASE 1: Both left and right are positive.
        // Update the global sum to the total global result.
        // Finally, return just one path with the larger subtree
        if (left > 0 && right > 0) {      
            // Check if the this global path result is the best so far that we've encountered.
            sum = Math.Max(sum, left + right + root.val);
            return Math.Max(left, right) + root.val;
        } 
        
        // CASE 2: One or the other child is valid. Update global sum.
        // Return the largest branch for further calculations.
        if (left > 0 || right > 0) {
            // Check if the this path result is the best so far that we've encountered.
            sum = Math.Max(sum, Math.Max(left, right) + root.val);
            return Math.Max(left, right) + root.val;
        }
        
        // CASE 3: Neither branch are good. Compare the individual node with the best result so far.
        // Just return root.val for future calculations.
        // Finally, just update sum if root.val is the best so far that we've encountered.
        sum = Math.Max(sum, root.val);
        return root.val;     
    }
}