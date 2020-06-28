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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
      
        if (head == null) {
            return null;
        }
        
        if (n <= 0) {
            return head;
        }
        // Find length of the entire linked list first.
        // If odd, where fastPtr.next is null, then we do ((slowptr index + 1) * 2) - 1
        // If even, where fastPtr is null, then we do (slowptr index/2 + 1) * 2
        var length = FindLength(head);
        var targetIndex = length - n;
        
        if (targetIndex <= 0) {
            return head.next;
        }
    
        var headRef = head;
        ListNode prev = null;
        var index = 0;
        
        while (index <= targetIndex) {
            if (index == targetIndex) {
                prev.next = headRef.next;
                headRef = null;
                break;
            }
            index++;
            prev = headRef;
            headRef = headRef.next;
            
        }
        return head;      
    }
    
    // Helper function, at most O(n), since we only need to traverse half the list
    // using the fast pointer technique when finding the midpoint.
    // Then do the aforementioned Math to find the length.
    private int FindLength(ListNode head) {
        var slowPtr = head;     
        var fastPtr = head;
        
        int slowNodeVisited = 0;
        while (fastPtr != null && fastPtr.next != null) {
            slowPtr = slowPtr.next;
            fastPtr = fastPtr.next.next;
            slowNodeVisited++;
        }
        
        if (fastPtr == null) {
            return slowNodeVisited * 2;
        } else {
            return ((slowNodeVisited + 1) * 2) - 1;
        }
    }
}