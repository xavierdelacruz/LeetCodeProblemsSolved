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
    public TreeNode ConstructFromPrePost(int[] pre, int[] post) {
        
        if (pre.Length == 0 || post.Length == 0) {
            return null;
        }
        
        if (pre.Length == 1 || post.Length == 1) {
            return new TreeNode(pre[0], null, null);
        }
        
        var postDict = new Dictionary<int, int>();
        var soln = new TreeNode[post.Length];
        
        for (int k = 0; k < post.Length; k++) {
            if (!postDict.ContainsKey(post[k])) {
                postDict.Add(post[k], k);
                soln[k] = new TreeNode(post[k]);
            }
        }
        
        int i = 0;
        TreeNode prev = null;
        
        while (i < pre.Length-1) {
            var currIdx = postDict[pre[i]];
            var afterIdx = postDict[pre[i+1]];
            
            // CASE 1: If the curr's index is larger than after's, then curr.left = after
            if (currIdx > afterIdx) {
                prev = soln[currIdx];
                soln[currIdx].left = soln[afterIdx];
            } else {
                var prevIdx = postDict[prev.val];
                // CASE 2: If the curr's index is smaller than after, then we need to check previous.
                // Hence, the parent's index is larger than after's, then it must be to the right of the parent.
                // This makes sense in post order because right subtrees are more likely positioned to the right.
                if (afterIdx < prevIdx) {
                    soln[prevIdx].right = soln[afterIdx];
                // CASE 3: SPECIAL CASE! If curr's index is smaller than after, and also larger than the recent parent.
                // This implies that we need to check the grandparent node, since its larger than the recent parent.
                // This makes sense in post order because right subtrees are more likely positioned to the right.
                } else if (afterIdx + 1 <= soln.Length) {
                    soln[afterIdx + 1].right = soln[afterIdx];
                    prev = soln[afterIdx + 1];
                }
            }
            i++;
        }
        
        return soln[soln.Length-1];
    }
}