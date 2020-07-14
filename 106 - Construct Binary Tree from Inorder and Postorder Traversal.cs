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
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        
        if (inorder.Length == 0 || postorder.Length == 0) {
            return null;
        }
        var inoDict = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++) {
            if (!inoDict.ContainsKey(inorder[i])) {
                inoDict.Add(inorder[i], i);
            }
        }
        var postIdx = postorder.Length-1;
        return BuildTreeHelper(inorder, postorder, ref postIdx, 0, inorder.Length-1, inoDict);
    }
    
    private TreeNode BuildTreeHelper(int[] ino, int[] post, ref int postIdx, int inoStart, int inoEnd, Dictionary<int, int> inoDict) {
        
        if (inoStart > inoEnd) {
            return null;
        }
        
        if (postIdx < 0) {
            return null;
        }
        
        var root = new TreeNode(post[postIdx]);     
        var rootIdx = inoDict[root.val];
        
        // Similar to the in-order and pre-order, the right side comes first.
        // Very important to note that the index of post never changes due to recursion.
        // When traversing the postorder array, the next node is always the RIGHT node.
        postIdx--;
        root.right = BuildTreeHelper(ino, post, ref postIdx, rootIdx+1, inoEnd, inoDict);
        root.left = BuildTreeHelper(ino, post, ref postIdx, inoStart, rootIdx-1, inoDict);
        return root;
    }
}