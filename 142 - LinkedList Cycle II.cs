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
    public ListNode DetectCycle(ListNode head) {
        
        // Base case 1: head is null.
        if (head == null) {
            return null;
        }
        
        // Hare
        var fast = head;
        
        // Tortoise
        var slow = head;
        
        // boolean flag to indicate there is a cycle.
        var hasCycle = false;
      
        // Do-while loop similar to find duplicate.
        while (fast != null && fast.next != null) {
            fast = fast.next.next;
            slow = slow.next;
            
            // This has to be placed after first call, since they both start at the head.
            if (slow == fast) {
                hasCycle = true;
                break;
            }
        }
        
        // There is no cycle.
        if (!hasCycle) {
            return null;
        }
        
        // Start tortoise back to head.
        slow = head;       
        while (slow != fast) {
            slow = slow.next;
            fast = fast.next;
        }
        
        // An intersection has occured.
        // Cycle detected.
        return fast;
               
    }
}