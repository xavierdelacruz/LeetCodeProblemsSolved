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
        if (root == null)
        {
            return 0;
        }
        
        // O(n) Space
        var sortedVals = new SortedSet<int>();
        
        // O(n) traversals.
        TraverseTree(root, sortedVals);
        
        var i = 0;
        foreach (var item in sortedVals) {
            if (i == k-1) {
                return item;
            }
            i++;
        }
        return 0;
    }
    
    private void TraverseTree(TreeNode root, SortedSet<int> sorted) {       
        var queue = new Queue<TreeNode>();       
        queue.Enqueue(root);
        
        while (queue.Count != 0) {
            var curr = queue.Dequeue();           
            sorted.Add(curr.val);
            
            if (curr.right != null) {
                queue.Enqueue(curr.right);
            }
            
            if (curr.left != null) {
                queue.Enqueue(curr.left);
            }
        }        
        return;
    }
}