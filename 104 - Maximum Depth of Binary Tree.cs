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
public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        var level = 0;

        // O(n) operation - BFS algorithm
        while (q.Count != 0)
        {
            var qCount = q.Count;
            level++;
            while (qCount > 0)
            {
                var curr = q.Dequeue();
                qCount--;
                if (curr.right != null)
                {
                    q.Enqueue(curr.right);
                }
                if (curr.left != null)
                {
                    q.Enqueue(curr.left);
                }
            }
        }
        return level;
    }

    // DFS recursive solution.
    private int FindDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var maxDepth = 1 + Math.Max(FindDepth(root.left), FindDepth(root.right));
        return maxDepth;
    }
}