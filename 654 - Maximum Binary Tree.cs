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
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
        // Base case 1: Array is empty. Return null.
        if (nums.Length == 0) {
            return null;
        }
        
        // Base Case 2: Array length is just 1. Return that node.
        if (nums.Length == 1) {
            return new TreeNode(nums[0]);
        }
        
        var max = FindMax(nums);
        var index = Array.IndexOf(nums, max);
        
        return ConstructMaxBTHelper(max, index, nums);
    }
    
    private TreeNode ConstructMaxBTHelper(int max, int index, int[] nums) {
        
        if (nums.Length == 0) {
            return null;
        }
        
        // I really love LINQ because of this.
        var left = nums.Take(index).ToArray();
        var right = nums.Skip(index + 1).ToArray();
        
        var leftMax = FindMax(left);          
        var leftIndex = Array.IndexOf(left, leftMax);
        
        var rightMax = FindMax(right);
        var rightIndex = Array.IndexOf(right, rightMax);
        
        var root = new TreeNode(max, ConstructMaxBTHelper(leftMax, leftIndex, left), ConstructMaxBTHelper(rightMax, rightIndex, right));
        return root;
    }
    
    // Assumption that there are no duplicates.
    private int FindMax(int[] arr) {
        int maxSoFar = Int32.MinValue;
        
        for (int i = 0; i < arr.Length; i++) {
            maxSoFar = Math.Max(maxSoFar, arr[i]);
        }       
        return maxSoFar;
    }  
}