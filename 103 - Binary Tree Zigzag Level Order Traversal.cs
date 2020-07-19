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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        
        var result = new List<IList<int>>();
        var list = new List<int>();
        
        if (root == null) {
            return result;
        }
        
        var level = 1;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while (q.Count != 0) {
            var qCount = q.Count;
            level++;
            
            while (qCount > 0) {
                var curr = q.Dequeue();
                list.Add(curr.val);
                qCount--;
                
                if (curr.right != null) {
                    q.Enqueue(curr.right);
                }
                
                if (curr.left != null) {
                    q.Enqueue(curr.left);
                }
            }
            
            if (level % 2 == 0){
                list.Reverse();
            }
            
            result.Add(list);
            list = new List<int>();
        }
        
        return result;
    }   
}