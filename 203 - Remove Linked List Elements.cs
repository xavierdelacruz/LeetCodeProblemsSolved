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
public class Solution {
    public ListNode RemoveElements(ListNode head, int val) {
        
        if (head == null) {
            return null;    
        }
               
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode prev = dummy;
        
        while (head != null) {
            if (head.val == val) {
                var tmp = head.next;                
                // Make head's next to null.
                head.next = null;
                prev.next = tmp;                
                head = tmp;
            } else {
                prev = head;
                head = head.next;
            }
        }
        
        return dummy.next;
    }
}