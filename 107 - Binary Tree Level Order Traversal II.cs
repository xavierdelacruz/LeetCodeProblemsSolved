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
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        
        var res = new List<IList<int>>();
        var currList = new List<int>();
        
        if (root == null) {
            return res;
        }
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count != 0) {           
            var qCount = queue.Count;       
            while (qCount > 0) {
                var curr = queue.Dequeue();
                currList.Add(curr.val);
                qCount--;
                
                if (curr.left != null) {
                    queue.Enqueue(curr.left);
                }
                
                if (curr.right != null) {
                    queue.Enqueue(curr.right);
                }  
            }         
            res.Add(currList);
            currList = new List<int>();
        }        
        // Reversal takes O(h)
        res.Reverse();
        return res;        
    }
}