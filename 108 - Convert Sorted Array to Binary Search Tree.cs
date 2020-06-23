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
    public TreeNode SortedArrayToBST(int[] nums) {
        if (nums.Length == 0) {
            return null;
        }

        if (nums.Length == 1) {
            return new TreeNode(nums[0], null, null);
        }

        return BuildBST(nums, 0, nums.Length-1);
        // Find the midpoint of the current array
        // var mid = nums.Length/2;
        
        // Using LINQ with Take, which means it will take up to, but not including the midpoint
        // Using LINQ with Skip, which means it will the element after mid, up to the end.
        // var firstHalf = nums.Take(mid).ToArray();
        // var secondHalf = nums.Skip(mid+1).ToArray();
        
        // return new TreeNode(nums[mid], SortedArrayToBST(firstHalf), SortedArrayToBST(secondHalf));                
    }
    
    // Classic Divide and Conquer algorithm
    private TreeNode BuildBST(int[] nums, int start, int end) {
        var mid = (start + end)/2;
        
        var root = new TreeNode(nums[mid], null, null);
        
        if (start < mid) {
            root.left = BuildBST(nums, start, mid-1);
        }
        
        if (end > mid) {
            root.right = BuildBST(nums, mid+1, end);
        }
        
        return root;   
    }
    
}