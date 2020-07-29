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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        
        if (l1 == null && l2 == null) {
            return null;
        }
        
        if (l1 == null) {
            return l2;
        }
        
        if (l2 == null) {
            return l1;
        }
        
        var revL1 = ReverseList(l1);
        var revL2 = ReverseList(l2);
        
        var carry = 0;
        var curr = new ListNode(0);
        var headRef = curr;
        while (revL1 != null || revL2 != null) {
            var curr1 = 0;
            if (revL1 != null) {
                curr1 = revL1.val;
            }
            
            var curr2 = 0;
            if (revL2 != null) {
                curr2 = revL2.val;
            }
            
            var sum = curr1 + curr2 + carry;
            carry = sum/10;
            var currDigit = sum%10;
            curr.next = new ListNode(currDigit);
            
            curr = curr.next;
            if (revL1 != null) {
                revL1 = revL1.next;
            }
            
            if (revL2 != null) {
                revL2 = revL2.next;
            }
        }
        
        if (carry > 0) {
            curr.next = new ListNode(carry);
        }
        
        return ReverseList(headRef.next);
                    
    }
    
    private ListNode ReverseList(ListNode l1) {     
        ListNode prev = null;
        ListNode curr = l1;
        
        while (curr != null) {
            var next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;           
        }
        
        return prev;
    }
}