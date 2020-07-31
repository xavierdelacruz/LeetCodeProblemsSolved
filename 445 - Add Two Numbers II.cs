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
        
        var stack1 = MakeStack(l1);
        var stack2 = MakeStack(l2);
        
        var curr = new ListNode(0);
        var headRef = curr;
        var carry = 0;
        var stackSum = new Stack<int>();
        while (stack1.Count > 0 || stack2.Count > 0 || carry > 0) {
            var curr1 = 0;
            if (stack1.Count > 0) {
                curr1 = stack1.Pop();
            }
            
            var curr2 = 0;
            if (stack2.Count > 0) {
                curr2 = stack2.Pop();
            }
            
            var sum = curr1 + curr2 + carry;
            carry = sum/10;
            var currDigit = sum%10;
            
            stackSum.Push(currDigit);
        }
        
        return MakeList(stackSum);
               
    }
    
    private ListNode MakeList(Stack<int> stack) {      
        var curr = new ListNode(stack.Pop());     
        var headRef = curr;
        while (stack.Count > 0) {
            curr.next = new ListNode(stack.Pop());
            curr = curr.next;
        }
        
        return headRef;
    
    }
    
    private Stack<int> MakeStack(ListNode list) {
        var stack = new Stack<int>();
        
        while (list != null) {
            var curr = list.val;
            stack.Push(curr);
            list = list.next;
        }
        return stack;
    } 
}