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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        if (root == null) {
            return new List<IList<int>>();
        }
        
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
         
        var currList = new List<int>();
        var res = new List<IList<int>>();
        // O(n), since it visits every single node once in the queue
        while (q.Count != 0) {
            var qCount = q.Count;          
            while (qCount > 0) {
                var curr = q.Dequeue();
                currList.Add(curr.val);
                qCount--;

                if (curr.left != null) {
                    q.Enqueue(curr.left);
                }
                
                if (curr.right != null) {
                    q.Enqueue(curr.right);
                }
            }            
            res.Add(currList);
            currList = new List<int>();
        }   
        return res;
    }
}