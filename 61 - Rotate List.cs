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
    public ListNode RotateRight(ListNode head, int k) {
        
        if (head == null) {
            return null;
        }
        
        if (k == 0 || head.next == null) {
            return head;
        }
        
        // Pass 1: Find the very end, because k > 0.
        // We will need to assign the end to head.
        ListNode endPtr = head;
        int length = 0;
        while (endPtr != null) {
            length++;
            
            if (endPtr.next == null) {                
                if (k == length || k % length == 0) {
                    return head;
                } else {
                   endPtr.next = head;
                break; 
                }               
            }
            
            endPtr = endPtr.next;
        }
        
        
        // Pass 2: We now know the length.
        // We want to move head length-k times.
        // Right behind head, is prev. When we reach length-k moves, we will set prev.next = null;
        // Finally, return head.        
        if (k > length) {
            k = k % length;
        }
        
        int moves = 0;
        int limit = length-k;
        ListNode prev = null;
        while (moves < limit) {
            moves++;
            prev = head;
            head = head.next;
        }
        prev.next = null;
        return head;
    }
}