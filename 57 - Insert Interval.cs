public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        if (intervals.Length == 0) {
            return new int[][] { newInterval };
        }
        
        // O(n) space usage
        var result = new List<int[]>();
        var hasMerged = false;
        
        var i = 0;
        // Single pass execution: O(n) overall.
        while (i < intervals.Length) {         
            // CASE 0: Settle the beginning of the entire iteration.
            if (result.Count == 0) {
                SettleStart(result, intervals, newInterval, i, ref hasMerged);
                i++;
                continue;
            }
            
            var currInterval = result[result.Count-1];
            var nextInterval = intervals[i];

            // CASE 1: New interval has NOT been merged
            if (!hasMerged) {            
                // 1.1 Special case where the current interval is EQUAL to another interval
                if (newInterval[0] == nextInterval[0] && newInterval[1] == nextInterval[1]) {
                    hasMerged = true;
                    result.Add(nextInterval);
                    i++;
                    continue;
                } else if (newInterval[0] <= currInterval[1]) {
                    // 1.2 If there is overlap with the most recently added interval, update both ends.
                    currInterval[0] = Math.Min(newInterval[0], currInterval[0]);
                    currInterval[1] = Math.Max(newInterval[1], currInterval[1]);
                    hasMerged = true;
                    continue;           
                } else if (newInterval[0] < nextInterval[0]) {
                    // 1.3 Otherwise, check the incoming interval, if the start is smaller for the new interval, add it to the result
                    result.Add(newInterval);
                    hasMerged = true;
                    continue;
                } else {
                    // 1.4 Otherwise, just add that incoming interval
                    result.Add(nextInterval);
                    i++;
                }
            }
                      
            // CASE 2: If the new interval has been already merged, then continue with regular execution.
            if (hasMerged) {  
                SettleOverlaps(result, nextInterval);
                i++;
            }  
        }
        
        // At the end, if it still has not merged, then add it, depending on the condition.
        if (!hasMerged) {
            SettleOverlaps(result, newInterval);
        }
        
        return result.ToArray();
    }
    
    // Helper function that checks for overlaps, and settles them if there are any.
    private void SettleOverlaps(List<int[]> result, int[] i1) {
        var currInterval = result[result.Count-1];
        if (i1[0] <= currInterval[1]) {
            currInterval[1] = Math.Max(i1[1], currInterval[1]);
        } else {
            result.Add(i1);
        }
    }
    
    // Helper function that settles the beginning, checks for duplicate intervals, and positioning
    private void SettleStart(List<int[]> result, int[][] intervals, int[] newInterval, int i, ref bool hasMerged) {
        if (newInterval[0] == intervals[i][0] && newInterval[1] == intervals[i][1]) {
            hasMerged = true;    
            result.Add(newInterval);
        } else if (newInterval[0] < intervals[i][0]) {
            result.Add(newInterval);
            SettleOverlaps(result, intervals[i]);
            hasMerged = true;
        } else {
            result.Add(intervals[i]);
        }
    }
}