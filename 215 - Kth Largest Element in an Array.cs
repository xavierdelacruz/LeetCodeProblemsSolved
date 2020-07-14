public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        
        if (nums.Length == 0) {
            return 0;
        }
        
        // O(nlogn) in reverse order using a comparer
        Array.Sort(nums, (x,y) => y.CompareTo(x));
        
        // k iterations
        for (int j = 0; j < nums.Length; j++) {
            if (j+1 == k) {
                // OVerall O(k + nlogn)
                // Could be done at O(n + klogn) with a max heap.
                return nums[j];        
            }
        }
        return -1;
    }
}