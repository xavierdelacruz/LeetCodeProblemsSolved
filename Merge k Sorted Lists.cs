/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {

        // Overall, O(nlogn), since this is an implementation of Merge Sort     
        if (lists == null || lists.Length == 0) {
            return null;
        }
        
        if (lists.Length == 1) {
            return lists[0];
        }
        
        // In even length lists, mid wil be second half
        // In odd length lists, it will be the exact middle
        int mid = lists.Length/2;
        
        // The amazing LINQ library
        // Take(x) takes the first x elements of the collection
        // Skip(x) takes the elements after the first x of a collection
        var firstCall = MergeKLists(lists.Take(mid).ToArray());
        var secondCall = MergeKLists(lists.Skip(mid).ToArray());
        
        // Recursively call this.
        // This is very similar to Merge Sort.
        return MergeSortedLists(firstCall, secondCall);
    }
    
    private ListNode MergeSortedLists(ListNode l1, ListNode l2) {  
        if (l1 == null && l2 == null) {
            return null;
        }
        
        if (l1 != null && l2 == null) {
            return l1;
        }
        
        if (l1 == null && l2 != null) {
            return l2;
        }
        
        var prev = new ListNode(0);
        var head = prev;
        
        while(l1 != null && l2 != null) {
            if (l1.val >= l2.val) {
                prev.next = l2;
                var tmp = l2.next;
                prev = prev.next;
                l2.next = l1;
                l2 = tmp;
            } else {
                prev.next = l1;
                var tmp = l1.next;
                prev = prev.next;
                l1.next = l2;
                l1 = tmp;
            }
        }      
        return head.next;
    }
}