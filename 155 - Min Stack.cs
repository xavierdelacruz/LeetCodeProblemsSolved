
public class MinStack {
    
    private List<int> list;
    private SortedDictionary<int, int> pq;
    private int size;
    /** initialize your data structure here. */
    public MinStack() {
        list = new List<int>();
        pq = new SortedDictionary<int, int>();
        size = 0;
    }
    
    public void Push(int val) {
        list.Add(val);
        size++;
        
        if (!pq.ContainsKey(val)) {
            pq.Add(val, 1);
        } else {
            pq[val]++;
        }
    }
    
    public void Pop() {
        if (size != 0) {
            if (pq.ContainsKey(list[size-1])) {
                if (pq[list[size-1]] > 1) {
                    pq[list[size-1]]--;
                } else {
                    pq.Remove(list[size-1]);
                }
            }
            
            list.RemoveAt(size-1);
            size--;
        }
    }
    
    public int Top() {
        if (size != 0) {
            return list[size-1];
        }
        return 0;
    }
    
    public int GetMin() {
        if (size != 0) {
            return pq.First().Key;
        }
        return int.MaxValue;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */