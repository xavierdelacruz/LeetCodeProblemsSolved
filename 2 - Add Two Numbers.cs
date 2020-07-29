/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
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
              
        var carry = 0;
        ListNode curr = new ListNode(0);
        ListNode headRef = curr;
        while (l1 != null || l2 != null || carry > 0) {
            var curr1 = 0;            
            if (l1 != null) {
                curr1 = l1.val;
            }
            
            var curr2 = 0;            
            if (l2 != null) {
                curr2 = l2.val;
            }
            
            var sum = curr1 + curr2 + carry;
            carry = sum/10;
            var currDigit = sum%10;
            curr.next = new ListNode(currDigit);
            
            curr = curr.next;
            if (l1 != null) {
                l1 = l1.next;
            }
            
            if (l2 != null) {
                l2 = l2.next;  
            }
                
        }
        return headRef.next;
    }
}