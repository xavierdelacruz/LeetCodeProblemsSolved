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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if (preorder.Length == 0 || inorder.Length == 0) {
            return null;
        }
        
        var inoDict = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++) {
            if (!inoDict.ContainsKey(inorder[i])) {
                inoDict.Add(inorder[i], i);
            }
        }
        var preIdx = 0;
        return BuildTreeHelper(preorder, inorder, ref preIdx, 0, inorder.Length-1, inoDict);
    }
        
    private TreeNode BuildTreeHelper(int[] pre, int[] ino, ref int preIdx, int inoStart, int inoEnd, Dictionary<int, int> inoDict) {
        
        // This corresponds to 0 elements being observed.
        if (inoStart > inoEnd) {
            return null;
        }
        
        if (preIdx >= pre.Length) {
            return null;
        }
        
        // Creates the node
        var root = new TreeNode(pre[preIdx]);
        
        // Finds the index of the current item using the inorder dict (look up is O(1))
        var rootIdx = inoDict[root.val];      
        
        preIdx++;
        
        // Look into the left partition of the in-order array
        root.left = BuildTreeHelper(pre, ino, ref preIdx, inoStart, rootIdx-1, inoDict);
        
        // Look into the right partition of the in-order array
        root.right = BuildTreeHelper(pre, ino, ref preIdx, rootIdx+1, inoEnd, inoDict);
        
        return root;    
    }
    
    // NOTE: THIS IS THE OTHER WAY OF DOING IT. It is O(n^2)
    // public TreeNode BuildTree(int[] preorder, int[] inorder) {
    //     if (preorder.Length == 0 || inorder.Length == 0) {
    //         return null;
    //     }
        
    //     var preIdx = 0;
    //     return BuildTreeHelper(preorder, inorder, ref preIdx);
    // }
        
    // private TreeNode BuildTreeHelper(int[] pre, int[] ino, ref int preIdx) {
        
    //     // This corresponds to 0 elements being observed.
    //     if (ino.Length == 0) {
    //         return null;
    //     }
        
    //     if (preIdx >= pre.Length) {
    //         return null;
    //     }
        
    //     // Creates the node
    //     var root = new TreeNode(pre[preIdx]);
        
    //     // Finds the index of the current item using the inorder dict (look up is O(1))
    //     var rootIdx = Array.IndexOf(ino, root.val);      
        
    //     preIdx++;
        
    //     var left = ino.Take(rootIdx).ToArray();
    //     var right = ino.Skip(rootIdx+1).ToArray();
        
    //     // Look into the left partition of the in-order array
    //     root.left = BuildTreeHelper(pre, left, ref preIdx);
        
    //     // Look into the right partition of the in-order array
    //     root.right = BuildTreeHelper(pre, right, ref preIdx);
        
    //     return root;    
    // }

}