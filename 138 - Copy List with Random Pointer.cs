/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {      
        if (head == null) {
            return head;
        }
        
        // Get dummy head first. Set it to the new node being created.
        Node dummyHead = new Node(-1);      
        // This is the new node.
        Node newHead = new Node(head.val);      
        // Point these dummies at the new node
        dummyHead.next = newHead;
        
        Node curr = head;   
        curr = curr.next;
        
        // Dictionary maps the original and the new linked list
        Dictionary<Node, Node> map = new Dictionary<Node, Node>();
        map.Add(head, newHead);
        
        // First pass is copying next pointers
        while (curr != null) {
            newHead.next = new Node(curr.val);
            map.Add(curr, newHead.next);
            curr = curr.next;
            newHead = newHead.next;
            
        }
        
        curr = head;
        while (curr != null) {
            if (curr.random != null && map.ContainsKey(curr.random)) {
                // If the map contains what the current (original list's) random next node, get the corresponding new List node, 
                // Assign its random pointer with the a value (new list nodes) that exists.
                map[curr].random = map[curr.random];              
            } 
            curr = curr.next;
        }
                
        return dummyHead.next;      
    }
}