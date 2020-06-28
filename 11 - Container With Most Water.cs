public class Solution {
    public int MaxArea(int[] height) {
        // Base Case 1: If no eight exists, or only one. This means there is no area.
        if (height.Length == 0 || height.Length == 1) {
            return 0;
        }
        
        // Base Case 2: If if only 2 exists, then index is just 0 and 1, which is a base of 1.
        // Take the minimum height, and find the area from there.
        if (height.Length == 2) {
            return Math.Min(height[0], height[1]);    
        }
        
        // Non-trivial Case: Using shinking window, where we have max width.
        // O(n) at most.
        var maxSoFar = Int32.MinValue;   
        var i = 0;
        var j = height.Length -1;
        while (i < j) {
            var area = Math.Min(height[i], height[j]) * Math.Abs(j-i);
            if (height[i] > height [j]) {
                maxSoFar = Math.Max(area, maxSoFar);
                j--;
            } else {
                maxSoFar = Math.Max(area, maxSoFar);
                i++;
            }
        }
        return maxSoFar;
    }
}