public class MedianFinder {

    BinaryHeap minHeap;
    BinaryHeap maxHeap;
    /** initialize your data structure here. */
    public MedianFinder() {
        minHeap = new BinaryHeap(BinaryHeap.HeapType.MIN, 100);
        maxHeap = new BinaryHeap(BinaryHeap.HeapType.MAX, 100);
    }
    
    // If this is a new list that is growing, it is logn as you keep adding things.
    // If you add n things, it will be O(n*logn)
    public void AddNum(int num) {
        // First, insert to minHeap
        minHeap.Insert(num);
        
        
        // Otherwise, let's Pop() the minheap, and push it into the maxheap.
        maxHeap.Insert(minHeap.Pop());
        
        if (minHeap.HeapSize < maxHeap.HeapSize) {
            minHeap.Insert(maxHeap.Pop());
        }
    }
    
    // O(1)
    public double FindMedian() {
        if (minHeap.HeapSize > maxHeap.HeapSize) {
            return (double) minHeap.Peek();
        } else {
            return  (double) ((minHeap.Peek() + maxHeap.Peek())/2.0);
        }
    }
}

public class BinaryHeap {
    
    public enum HeapType
    {
        MIN,
        MAX
    }
    
    private HeapType Type;
    private int[] Heap;
    public int HeapSize;
    
    // For a binary heap, given an index i, its children will be in index 2*i + 1, and 2*i + 2
    // Balancing a heap requires calling bubbling up or bubbling down.
    // An insertion is usually done by adding the element at the end of the array (internal ds)
    // KEY METHODS:
    // - BubbleUp, BubbleDown, Insert, Pop, Swap, Resize (if using an array), Peek
    public BinaryHeap(HeapType type, int size) {
        Type = type;
        HeapSize = 0;
        Heap = new int[size];
    }
    
    // Recopies the heap to a new array to resize it
    // Double the size od the heap.
    private void ResizeHeap() {
        int[] newHeap = new int [Heap.Length * 2];
        Array.Copy(Heap, newHeap, HeapSize); 
        Heap = newHeap;
    }
    
    // When inserting a number, we need to resize it
    public void Insert(int number) {
        // This is done because we want to make sure that we are able to calculate the index of the child later, 
        // This will help us find our node later on.
        if (HeapSize * 2 + 2 >= Heap.Length) {
            ResizeHeap();
        }
        Heap[HeapSize] = number;
        BubbleUp(HeapSize);
        HeapSize++;
    }
    
    // Gets the value of the top of the heap
    public int Peek() {
        if (HeapSize > 0) {
            return Heap[0];
        }
        return int.MinValue;
    }
    
    // Takes the top of the heap.
    public int Pop() {
        if (HeapSize > 0) {
            int result = Heap[0];
            
            // Swap the root with the last element of the array, and bubble down.
            Heap[0] = Heap[HeapSize-1];
            HeapSize--;
            
            BubbleDown(0);
            return result;
        }
        
        return int.MinValue;
    }
    
    // Swaps values between given positions in the Heap DS
    private void Swap(int pos1, int pos2) {
        int temp = Heap[pos1];
        Heap[pos1] = Heap[pos2];
        Heap[pos2] = temp;
    }
    
    // Important function that rearranges the heap AS WE CONSTRUCT THE Tree. Usually when we insert.
    // This is recursive, since it bubbles up as we do swaps.
    private void BubbleUp(int idx) {
        // We are at the root
        if (idx == 0) {
            return;
        }
        
        // This checks if the offset from our parent is 1 or 2 (1 if its the left child, 2 for the right)
        // Again, this uses the property where we have 2*idx + 2 as the right, and 2*idx + 1 as the left.
        // In this case, we want to find the parent so that we could bubble up (aka, we need to find our parent nodes)
        /// Mathematically, if the idx is even, then it is the right node, and we will need to substract 2, otherwise, 1.
        int parentIdx = idx % 2 == 0 ? (idx - 2)/2 : (idx - 1)/2; 
        int parent = Heap[parentIdx];
        int current = Heap[idx];
        
        // If we have a Max Heap, we will only swap if and only if our current index is GREATER than its parent
        // OR we have a Min Heap,  we will only swap if and only our current idx is LESS than its parent
        if ((Type == HeapType.MAX && current > parent) || (Type == HeapType.MIN && current < parent)) {
            Swap(parentIdx, idx);
            BubbleUp(parentIdx);
        }
    }
    
    // Important function that rearranges the heap AFTER things have been constructed. Usually when we remove.
    // This is recursive, since it bubbles down as we do swaps.
    private void BubbleDown(int idx) {
        //We are at the bottom
        if (idx >= HeapSize-1) {
            return;
        }
        
        // Whenever we pop the heap, we need to redistribute the values by bubbling down.
        int rightChildIdx = 2 * idx + 2;
        int leftChildIdx = 2 * idx + 1;
        
        // If we have a Max Heap, we will only swap if and only if our current index is GREATER than its parent
        // OR we have a Min Heap,  we will only swap if and only our current idx is LESS than its parent
        // WE COULD check the children nodes and determine the min or max, then check with the parents.    
        if (Type == HeapType.MAX) {
            // This means that the right child is bigger than the parent node. Swap!
            if (rightChildIdx < HeapSize && Heap[idx] < Heap[rightChildIdx]) {
                Swap(rightChildIdx, idx);
                BubbleDown(rightChildIdx);
            }
            
            // This means that the left child is bigger than the parent node.
            if (leftChildIdx < HeapSize && Heap[idx] < Heap[leftChildIdx]) {
                Swap(leftChildIdx, idx);
                BubbleDown(leftChildIdx);
            }       
        } else if (Type == HeapType.MIN) {
            // This means that the right child is smaller than the parent node. Swap!
            if (rightChildIdx < HeapSize && Heap[idx] > Heap[rightChildIdx]) {
                Swap(rightChildIdx, idx);
                BubbleDown(rightChildIdx);
            }          
            // This means that the left child is smaller than the parent node.
            if (leftChildIdx < HeapSize && Heap[idx] > Heap[leftChildIdx]) {
                Swap(leftChildIdx, idx);
                BubbleDown(leftChildIdx);
            }       
        }  
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */