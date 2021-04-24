public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        
        if (nums1.Length == 0 && nums2.Length == 0) {
            return 0;
        }
        
        int[] mergedArray = MergeSortedArrays(nums1, nums2);

        if (mergedArray.Length % 2 == 0) {
            return (double) (mergedArray[mergedArray.Length/2] + mergedArray[(mergedArray.Length/2)-1]) / 2;
        } else {
            return (double) mergedArray[mergedArray.Length/2];
        }
        
    }
    
    // O(n) - could use binary search.
    public int[] MergeSortedArrays(int[] nums1, int[] nums2) {
        
        int[] result = new int[nums1.Length + nums2.Length];
        
        // result pointer
        int i = 0;
        
        //nums1 & nums2 pointers
        int j = 0;
        int k = 0;
        while (i < result.Length) {
            
            // nums1 is done but nums2 is not.
            if (j >= nums1.Length && k < nums2.Length) {
                result[i] = nums2[k];
                k++;
            }
            
            // nums2 is done, but nums1 is not
            if (j < nums1.Length && k >= nums2.Length) {
                result[i] = nums1[j];
                j++;
            }
            
            if (j < nums1.Length && k < nums2.Length) {        
                // nums1 is larger than nums2
                if (nums1[j] <= nums2[k]) {
                    result[i] = nums1[j];
                    j++;
                } else {
                    // otherwise, k is larger
                    result[i] = nums2[k];
                    k++;
                }
            }
                        
            i++;
            
        }
        
        return result;
    }
}