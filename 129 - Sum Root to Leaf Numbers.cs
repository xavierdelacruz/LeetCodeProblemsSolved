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
    public int SumNumbers(TreeNode root) {
        if (root == null) {
            return 0;
        }

        // Backtracking with DFS      
        return FindTotalPathSum(root, 0);
    }
    
    private int FindTotalPathSum(TreeNode root, int sum) {
        if (root == null) {
            return 0;
        }
        
        var currSum = sum * 10 + root.val;
        if (root.right == null && root.left == null) {
            sum += currSum;
            return currSum;
        }
        
        var left = FindTotalPathSum(root.left, currSum);              
        var right = FindTotalPathSum(root.right, currSum);       
        return left+right;
    }
}