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
    public IList<int> PostorderTraversal(TreeNode root) {
        var res = new List<int>();
        
        if (root == null) {
            return res;
        }
        
        PostOrderHelper(root, res);
        return res;
    }
    
    private void PostOrderHelper(TreeNode root, IList<int> res) {
        if (root == null) {
            return;
        }
        
        PostOrderHelper(root.left, res);
        PostOrderHelper(root.right, res);
        
        res.Add(root.val);
        return;
    }
}