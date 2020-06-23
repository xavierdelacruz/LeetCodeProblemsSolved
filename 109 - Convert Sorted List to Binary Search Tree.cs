/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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
    public TreeNode SortedListToBST(ListNode head) {
        // Approach: 
        // Divide and Conquer
        // 1. Everything to the left of the middle elem is less than.
        // 2. Otherwise right for greater than
        if (head == null) {
            return null;
        }
        
        if (head.next == null) {
            return new TreeNode(head.val, null, null);
        }
        
        // Passing on prev will modify it, since it is pass-by-reference for objects
        // Pass by value for primitives.
        var midResult = FindMiddleOfLinkedList(head);
        
        // Important that if the resulting midpoint value is the same as the current head
        // then set it to null, since it is now the new node being made (usually when the list is a single element)
        if (midResult.midValue == head.val) {
            head = null;
        }

        // Return the new BST, while doing an internal recursive approach for the left and right subtrees
        return new TreeNode(midResult.midValue, SortedListToBST(head), SortedListToBST(midResult.otherHalf));
    }

    // Returns a tuple, implicitly
    private (int midValue, ListNode otherHalf) FindMiddleOfLinkedList(ListNode head) {
        var fastPtr = head.next;
        var slowPtr = head;
        var prev = head;
        
        while (fastPtr != null && fastPtr.next != null) {
            fastPtr = fastPtr.next.next;
            prev = slowPtr;
            slowPtr = slowPtr.next;
        }
        
        // slowPtr is now pointing at the middle for an odd numbered node list
        // slowPtr is now pointing at the element before the 'middle' for even.
        // regardless, we will divide it, and return the second linked list generated
        // The last node in head will be the midpoint, or root value.
        var halfPtr = slowPtr.next;
        var midPointVal = slowPtr.val;
        prev.next = null;
        return (midPointVal, halfPtr);
    }
}