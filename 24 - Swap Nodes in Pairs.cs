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
    public ListNode SwapPairs(ListNode head) {
     
        if (head == null) {
            return null;
        }
    
        // 3 pointers needed
        var nextHead = head.next;
        var currHead = head;
        var prev = new ListNode(Int32.MinValue);
        
        // Handles the case where there is either one or two nodes only.
        var dummyHead = currHead;        
        if (nextHead != null) {
            dummyHead = nextHead;
        }
        
        // Non-trivial case
        while (currHead != null && nextHead != null) {

            // Swamp pointers and reassign the next values
            var tmpNext = nextHead;
            var nextTmp = nextHead.next;
            nextHead = currHead;     
            currHead = tmpNext;
            nextHead.next = nextTmp;
            currHead.next = nextHead;   
            prev.next = currHead;
            
            // Iterate and move to the next;
            nextHead = nextHead.next;
            currHead = currHead.next;
            prev = prev.next;
            
            // Iterate one more time.
            if (nextHead != null) {
                nextHead = nextHead.next;
            }
            currHead = currHead.next;
            prev = prev.next;           
        }      
        return dummyHead;
    }
}