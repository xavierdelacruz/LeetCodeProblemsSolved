public class LRUCache {

    // Keeps tracks of the actual value in the cache
    private Dictionary<int, int> keyVal = new Dictionary<int,int>();
    
    // Keeps tracks of all nodes that correspond to the key
    private Dictionary<int, LinkedListNode<int>> keyNode = new Dictionary<int, LinkedListNode<int>>();
    
    // Keeps track of the least recently used (first node)
    private LinkedList<int> linkedList = new LinkedList<int>();
    
    private int capacity;
    
    public LRUCache(int capacity) {
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        if (!keyVal.ContainsKey(key)) {
            return -1;
        }
        
        // retrieve the result
        int res = keyVal[key];
        
        // retrieve the node
        LinkedListNode<int> node = keyNode[key];
        
        // Remove that current node's location
        linkedList.Remove(node);
        
        // Re-add that node at the front of the linked list. Last item is the least recently used.
        linkedList.AddFirst(node);
        
        return res; 
    }
    
    public void Put(int key, int val) {
        if (!keyVal.ContainsKey(key)) {
            // New entry being added but linked list is full
            // Evict
            if (capacity == linkedList.Count) {
                // Keep track of the item being evicted
                LinkedListNode<int> last = linkedList.Last;
                
                // Remove the last item in the LL, since it is the LRU
                linkedList.RemoveLast();
                
                // Update dictionary trackers
                keyVal.Remove(last.Value);
                keyNode.Remove(last.Value);
            }
            
            // Finally, add the new item in the LL
            linkedList.AddFirst(key);
            
            // Finally, update the dictionary contents.
            keyVal[key] = val;
            keyNode[key] = linkedList.First;
                      
        } else {
            // Otherwise, cache is not full, and update the value
            keyVal[key] = val;
            
            // Find the node of interest
            // And update the linkedList. Node, last node is the LRU.
            // Always add new ones to the front of the LinkedList
            LinkedListNode<int> node = keyNode[key];
            linkedList.Remove(node);
            linkedList.AddFirst(node);
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */