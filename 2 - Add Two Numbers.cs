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
                
        var head = l1;
        var carry = 0;
        var prev = l1;
        
        if (l1 == null && l2 != null) {
            Console.WriteLine(l2.val);
            return l2;
        } if (l1 != null && l2 == null) {
            Console.WriteLine(l1.val);
            return l1;
        } else {
            var remainder = 0;
            while (l1 !=null || l2 != null || carry != 0) {                
                if (l1 != null && l2 !=null) {
                    var sum = l1.val + l2.val + carry;
                    Console.WriteLine("Case 1 " + sum);
                    carry = 0;
                    remainder = sum % 10;
                    if (sum >= 10) {                          
                        carry = 1;
                        Console.WriteLine("Carry is " + carry);
                    }            
                    l1.val = remainder;
                    prev = l1;
                    l1 = l1.next;
                    l2 = l2.next;
                } else if (l1 != null && l2 == null) {
                    var sum = l1.val + 0 + carry;
                    Console.WriteLine("Case 2 " + sum);
                    carry = 0;
                    remainder = sum % 10;
                    if (sum >= 10) {                       
                        carry = 1;
                        Console.WriteLine("Carry is " + carry);
                    }             
                    l1.val = remainder;
                    prev = l1;
                    l1 = l1.next;
                } else if (l1 == null && l2 != null) {
                    var sum = 0 + l2.val + carry;
                    Console.WriteLine("Case 3 " + sum);
                    carry = 0;
                    remainder = sum % 10;
                    if (sum >= 10) {                        
                        carry = 1;
                        Console.WriteLine("Carry is " + carry);
                    }
                    l1 = new ListNode(remainder);
                    prev.next = l1;
                    prev = l1;
                    l1 = l1.next;
                    l2 = l2.next;
                } else {
                    prev.next = new ListNode(carry);
                    break;
                }
            }         
        }
        return head;            
    }
}