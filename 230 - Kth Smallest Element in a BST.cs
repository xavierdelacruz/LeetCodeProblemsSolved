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
    public int KthSmallest(TreeNode root, int k) {
        if (root == null) {
            return 0;
        }
        
        var i = 0;   
        var stack = new Stack<TreeNode>();
        var curr = root;       
        while (stack.Count != 0 || curr != null) {        
            while (curr != null) {
                stack.Push(curr);
                curr = curr.left;
            }
            
            curr = stack.Pop();
            if (i == k-1) {                
                return curr.val;
            }
            
            i++;
            curr = curr.right;
        }       
        return 0;
    }
}