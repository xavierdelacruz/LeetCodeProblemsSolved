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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        
        // If both are null, return true
        if (p == null && q == null) {
            return true;
        }
        
        // If either are null, return false.
        if (p == null || q == null) {
            return false;
        }
        
        var q1 = new Queue<TreeNode>();
        var q2 = new Queue<TreeNode>();        
        q1.Enqueue(p);
        q2.Enqueue(q);
        
        while (q1.Count != 0 && q2.Count != 0) {
            
            var curr1 = q1.Dequeue();
            var curr2 = q2.Dequeue();
            
            if (curr1.val != curr2.val) {
                return false;
            }
            
            if (curr1.right != null && curr2.right != null) {                
                q1.Enqueue(curr1.right);
                q2.Enqueue(curr2.right);
            } else if ((curr1.right == null && curr2.right != null) || (curr1.right != null && curr2.right == null)) {
                return false;
            }
            
            if (curr1.left != null && curr2.left != null) {                
                q1.Enqueue(curr1.left);
                q2.Enqueue(curr2.left);
            } else if ((curr1.left == null && curr2.left != null) || (curr1.left != null && curr2.left == null)) {
                return false;
            }
        }      
        return true;
    }

    public bool IsSameTreeRecursive(TreeNode p, TreeNode q) {
        if (p == null && q == null) {
            return true;
        }
        
        if (p == null || q == null) {
            return false;
        }
        
        if (p.val != q.val) {
            return false;
        }
        
        return true && IsSameTreeRecursive(p.right, q.right) && IsSameTreeRecursive(p.left, q.left);
    }
}