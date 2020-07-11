public class Solution {
    public int[][] Merge(int[][] intervals) {
        
        if (intervals.Length == 0 || intervals.Length == 1) {
            return intervals;
        }
        
        // Stores list of intervals, since the length can change at any time when they get merged.
        var result = new List<int[]>();
        
        // O(nlogn)
        var sorted = intervals.OrderBy(elem => elem[0]).ToArray();

        // Iterate through all intervals
        // Make comparison with what's currently in the most recent interval that's inside result.
        // O(n) for the number of intervals.
        // O(1) using index access with lists.
        // Overall, O(n)
        for (int i = 0; i < sorted.Length; i++) {
            if (result.Count == 0) {
                result.Add(sorted[i]);
                continue;
            }

            // Get the last item in the list
            var currInterval = result[result.Count-1];
            var nextInterval = sorted[i];
            
            // If there is some form of overlap, change it.
            if (nextInterval[0] <= currInterval[1]) {
                currInterval[1] = Math.Max(nextInterval[1], currInterval[1]);
            } else {
                result.Add(sorted[i]);
            }
        }
        
        // O(n) converting it back to array
        return result.ToArray();
    }
}