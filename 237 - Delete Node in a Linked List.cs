/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public void DeleteNode(ListNode node) {
        // IDEA: Transfer value of next node to this, assuming it exists.      
        if (node == null) {
            return;
        }
        
        // Not possible, as mentioned in the desc.
        if (node.next == null) {
            return;
        }
        
        ListNode prev = null;        
        while (node.next != null) {
            var next = node.next;
            var nextVal = node.next.val;            
            node.val = nextVal;
            prev = node;
            node = node.next;       
        }        
        prev.next = null;
        return;
    }
}