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
    public int DistributeCoins(TreeNode root) {
        
        if (root == null) {
            return 0;
        }
        
        if (root.left == null && root.right == null) {
            return Math.Abs(root.val-1);
        }

        var moves = 0;
        DFSMoves(root, null, ref moves);
        return moves;
    }
    
    private void DFSMoves(TreeNode root, TreeNode parent, ref int moves) {
        if (root == null) {
            return;
        }
        
        // Go all the way down to the leftmost node.      
        DFSMoves(root.left, root, ref moves);       
        DFSMoves(root.right, root, ref moves);
        
        // CASE 1: Put excess to parent. Moves incurred would be the number of excess coins
        if (root.val > 1) {      
            var extra = Math.Abs(root.val - 1);
            if (parent != null) {
                parent.val += extra;
            }
            root.val = 1;
            moves += extra;
        // CASE 2: Borrow deficit fromt parent. Moves incurred would be the number of borrowed coins
        } else if (root.val < 1) {
            var diff = Math.Abs(root.val - 1);        
            if (parent != null) {
                parent.val -= diff;
            }
            root.val = 1;
            moves += diff;
        }
    }
}