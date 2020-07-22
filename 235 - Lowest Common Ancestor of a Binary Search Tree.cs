/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null) {
            return root;
        }
        
        // If the current root is larger than p (left, valid), but larger than q
        // then we have to search more leftwards to reduce root's value to go within q.
        if (root.val > p.val && root.val > q.val) {
            return LowestCommonAncestor(root.left, p, q);
        } else if (root.val < p.val && root.val < q.val) {
        // Otherwise, search more rightwards.
            return LowestCommonAncestor(root.right, p, q);
        }
        
        // Otherwise, it falls within the criteria, and this is our answer.
        return root;
    }
}