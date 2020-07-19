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
    public IList<IList<int>> PathSum(TreeNode root, int sum) {
        
        var result = new List<IList<int>>();
        var list = new List<int>();
        if (root == null) {
            return result;
        }
        
        DFS(root, result, list, sum);
        return result;
    }
    
    private void DFS(TreeNode root, List<IList<int>> pathways, List<int> path, int sum) {
        
        if (root == null) {
            return;
        }
        
        path.Add(root.val);
        
        if (sum-root.val == 0 && root.left == null && root.right == null) {
            pathways.Add(new List<int>(path));
        }
           
        DFS(root.left, pathways, path, sum-root.val);
        DFS(root.right, pathways, path, sum-root.val);       
        path.RemoveAt(path.Count-1);
        
        return;
    }
}