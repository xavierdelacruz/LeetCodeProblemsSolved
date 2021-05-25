vpublic class MyCircularQueue {

    private int front;
    private int rear;
    private int[] elements;
    private int currSize;
    
    public MyCircularQueue(int k) {
        front = 0;
        rear = -1;
        elements = new int[k];
        currSize = 0;   
    }
    
    public bool EnQueue(int val) {
        if (IsFull()) {
            return false;
        }
        
        // If it's not full, move to the next item, and insert it in there
        rear = (rear + 1) % elements.Length;
        elements[rear] = val;
        currSize++;
        return true;
    }
    
    public bool DeQueue() {
        if (IsEmpty()) {
            return false;
        }
        
        // If it's not empty, move the front pointer.
        front = (front + 1) % elements.Length;
        currSize--;
        return true;
    } 
    
    public int Front() {
        return IsEmpty() ? -1 : elements[front];
    }
    
    public int Rear() {
        return IsEmpty() ? -1 : elements[rear];
    }
    
    public bool IsEmpty() {
        return currSize == 0;
    }
    
    public bool IsFull() {
        return currSize == elements.Length;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */