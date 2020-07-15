public class Solution {
    // The idea is to perform binary search on each array element
    // We want to count how many elements we have smaller than k
    // For example, 1, 5, 9, 10, 11, 12, 13, 13, 15, where k = 8
    // Then we expect 13 to be the smallest element if we flatten the matrix.
    // Our answer would be when we have count == k, such that it visits those elements.
    // We keep doing binary search until we find such elements, changing the midpoint every time to narrow the search space.
    // For example, if the number of elements less than our midpoint < k, then we can set our left (lo) to mid+1, since we need MORE elements to find k counts.
    // Otherwise, we decrease our mid.
    public int KthSmallest(int[][] matrix, int k) {

        // BASE CASE 1: matrix is Empty. Return 0.
        if (matrix.Length == 0) {
            return 0;
        }
        
        // BASE CASE 2: k is invalid, and is less or equal to 1. Return first element.
        if (k <= 1) {
            return matrix[0][0];
        }
        
        // BASE CASE 3: If we are lookign for largest element, just access it directly and return the last elem of the matrix.
        if (k == matrix.Length-1*matrix[0].Length-1) {
            return matrix[matrix.Length-1][matrix[0].Length-1];
        }
        
        // Imagine the array being flattened. The first and last element will be the smallest and largest, respectively.
        var lo = matrix[0][0];
        var hi = matrix[matrix.Length-1][matrix[0].Length-1];
        
        // START BINARY SEARCH HERE. 
        // This is the regular template. The helper function will depend on the search criteria we are using.
        // In this case, we will be using elements that are of that count.
        while (lo < hi) {         
            // Typical Binary Search midpoint calculation.
            var mid = lo + (int) hi >> 1;
            
            // Note that we'll keep adjusting the midpoint until we find the kth element, and we'll count that.
            if (ElementLessThanOrEqualtoK(matrix, mid) < k) {
                // Because we have less elements given the midpoint (AND K), we want to set lo to mid+1
                // since it is definitely going to include the previous mid itself.
                lo = mid+1;
            } else {
                // Otherwise, if we have elements that are more than or equal to k, then just set hi to mid.
                // If mid is equal to k, then we will likely find the answer at that point.
                hi = mid;
            }
        }
        
        return lo;
    }
    
    private int ElementLessThanOrEqualtoK(int[][] m, int k) {
        // We are starting at the top right.
        var j = m[0].Length-1;
        var i = 0;
        // This the the return value, or the number of elements less than or equal to k
        // Note that our mid will eventually hit k.
        var elemCount = 0;
        
        // While we are withing the bounds of the array, keep searching
        while (i < m.Length && j >= 0) {
            if (m[i][j] > k) {
                j--;
            } else {
                // Due to the array's sorted nature, if we see an element less than our midpoint, we can stop there.
                // It's index + 1 wil be the number of elements to the left of it.
                // For example, if j = 2, then there are 3 elements in total (including itself).
                elemCount += (j+1);
                i++;
            }
        }        
        return elemCount;
    }
}