public class LRUCache {

    // Extension of the val property of Dictionary
    // This will act like a doubly linked list
    // Why? Because the last object is the most recently used
    // The first object is the least recently used
    // I Could also totally use LinkedListNode class in C#
    // But eh, good practice for custom doubly linked list stuff
    private class CachedObject {
        public int key {get; set;}
        public int val {get; set;}
        public CachedObject next {get; set;}
        public CachedObject prev {get; set;}
    }
    
    // The actual cache structure
    private Dictionary<int, CachedObject> cache;
    
    // Keep track of actual cache capacity
    private int cap;
    
    // Keep track least recently and most recently used cache objects
    CachedObject lruPointer;
    CachedObject mruPointer;
    
    public LRUCache(int capacity) {
        
        if (capacity <= 0) {
            throw new Exception("Bad capacity provided");
        }
        cache = new Dictionary<int, CachedObject>();
        cap = capacity;
    }
    
    public int Get(int key) {
        if (!cache.ContainsKey(key)) {
            return -1;
        } else {
            UpdateUsageState(cache[key]);         
            return cache[key].val; 
        }
    }
    
    public void Put(int key, int val) {
        if (cache.Count >= cap) {
            var deleteKey = lruPointer.key;            
            var cachedObject = new CachedObject {
                key = key,
                val = val,
                next = null,
                prev = mruPointer
            };
            
            // If the new object does not exist, remove the least recently used
            if (!cache.ContainsKey(key)) {
                var tmp = lruPointer.next;         
                lruPointer.prev = null;
                lruPointer.next = null;
                lruPointer.key = 0;
                lruPointer = tmp;
                cache.Remove(deleteKey);
                cache.Add(key, cachedObject);
       
                // Set the pointers to the incoming object
                mruPointer.next = cachedObject;
                mruPointer = cachedObject;
                
            } else {
                UpdateUsageState(cache[key]);
                cache[key].val = val;    
            }
        } else if (cache.Count == 0) {
            var cachedObject = new CachedObject {
                key = key,
                val = val,
                next = null,
                prev = null
            };
            
            cache.Add(key, cachedObject);
            mruPointer = cachedObject;
            lruPointer = cachedObject;
            
        } else {
            var cachedObject = new CachedObject {
                key = key,
                val = val,
                next = null,
                prev = mruPointer
            };
            
            if (!cache.ContainsKey(key)) {
                cache.Add(key, cachedObject);
                mruPointer.next = cachedObject;
                mruPointer = cachedObject;
            } else {
                UpdateUsageState(cache[key]);         
            }
            
            cache[key].val = val;      
        }
    }
    
    private void UpdateUsageState(CachedObject cacheObject) {
        if (cacheObject.Equals(lruPointer) && cache.Count > 1) {
            // If we are dealing with the LRU, then we place it at the back
            // First set the LRU pointer the next object
            lruPointer = cacheObject.next;
            
            // With that object being updated, it will now have next to null (since its at the end)
            cacheObject.next = null;
            
            // Let the new object at the end point prev to the mruPointer
            cacheObject.prev = mruPointer;
            
            // now let that mruPointer next point to the new object at the end
            mruPointer.next = cacheObject;
            
            // now update the MRU pointer to point to the new cache object
            mruPointer = cacheObject;
            
        } else if (!cacheObject.Equals(lruPointer) && cache.Count > 1 && !cacheObject.Equals(mruPointer)) {
            
            // Set next pointer of previous node to cacheObjext.next
            cacheObject.prev.next = cacheObject.next;
             
            // Set prev pointer of next node to cacheObject.prev
            cacheObject.next.prev = cacheObject.prev;
            
            // With that object being updated, it will now have next to null (since its at the end)
            cacheObject.next = null;
            
            // Let the new object at the end point prev to the mruPointer
            cacheObject.prev = mruPointer;
            
            // Now let that mruPointer next point to the new object at the end
            mruPointer.next = cacheObject;
            
            // Now update the MRU pointer to point to the new cache object
            mruPointer = cacheObject;      
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */