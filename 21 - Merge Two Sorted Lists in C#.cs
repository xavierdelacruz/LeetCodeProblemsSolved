/**Kris de la Cruz
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        
        if (l1 == null && l2 == null) {
            return l1;
        }
        
        if (l1 == null && l2 != null) {
            return l2;
        }
        
        if (l1 != null && l2 == null) {
            return l1;
        }
        
        var prev = new ListNode(0);
        var head = prev;
        
        while (l1 != null && l2 != null) {    
            if (l1.val <= l2.val) {
                prev.next = l1;
                var tmp = l1.next;
                l1.next = l2;
                prev = prev.next;
                l1 = tmp;
                
            } else {
                prev.next = l2;
                var tmp = l2.next;
                l2.next = l1;
                prev = prev.next;
                l2 = tmp;
            }
        }
        return head.next;
    }
}
    


