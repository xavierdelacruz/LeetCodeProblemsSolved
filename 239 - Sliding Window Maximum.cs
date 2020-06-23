public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        
        // Implement a monotonic linked list, in decreasing format
        // Such that the max value is awlays at the front   
        var linkedList = new LinkedList<int>();       
        var result = new List<int>();
        
        for (int i = 0; i < nums.Length; i++) {
            
            // If the last item in the linked list is smaller, pop it off
            // Keep doing so until it is clear of smaller values than the current one
            // This way, we can ensure that we always have the MAX listed first
            while (linkedList.Count != 0 && nums[i] > linkedList.Last.Value) {
                linkedList.RemoveLast();
            }
            linkedList.AddLast(nums[i]);
            
            // Our index has covered the distance of the window, k
            // Start removing such elements at the beginning, as each iteration will
            // also start covering previously covered values from the previous window
            // For example, at k = 3, then at i = 2, means we have covered the window.
            // For the next iterations after i = 2, we will have answers at each iteration
            // since the previous elements have shown us what value they are in the queue
            if (i >= k-1) {
                result.Add(linkedList.First.Value);
                
                // Check if the current max in the linked list is still WITHIN when we shift
                // Note that if i were the pointer at the beginning of the window, 
                // the last element would be k+i-1, and the first element is i.
                // However, if the pointer were at the end of the window,
                // the last element would be i, and the first element of the window would be i-(k-1)
                if (nums[i-(k-1)] == linkedList.First.Value) {
                    linkedList.RemoveFirst();
                }
            }
        }   
        return result.ToArray();
    }
}