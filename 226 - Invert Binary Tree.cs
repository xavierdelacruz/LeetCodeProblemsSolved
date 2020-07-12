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
    public TreeNode InvertTree(TreeNode root) {
        
        // BASE CASE: Root does not exist. Return null or root.
        if (root == null) {
            return root;
        }
        
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while(q.Count != 0) {
            
            var curr = q.Dequeue();
            
            var left = curr.left;
            var right = curr.right;
            
            curr.left = right;
            curr.right = left;
            
            if (curr.left != null) {
                q.Enqueue(curr.left);
            }
            
            if (curr.right != null) {
                q.Enqueue(curr.right);
            }
        }        
        return root;
    }   
}