/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        
        // Base case: If there is a single node, or no nodes - then return false.
        if (head == null || head.next == null) {
            return false;
        }

        // Simplified Floyd's Algorithm.
        var hare = head;
        var tortoise = head;
        
        while (hare != null && hare.next != null) {
            hare = hare.next.next;
            tortoise = tortoise.next;
            
            if (tortoise == hare) {
                return true;
            }
        }      
        return false;
    }
}