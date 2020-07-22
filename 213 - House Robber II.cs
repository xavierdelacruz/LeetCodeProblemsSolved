public class Solution {
    public int Rob(int[] nums) {
        
        if (nums.Length == 0) {
            return 0;
        }
        
        if (nums.Length == 1) {
            return nums[0];
        }
        
        if (nums.Length == 2) {
            return Math.Max(nums[0], nums[1]);
        }
        // Do the same Rob problem, but this time, find the best when either start or end are excluded.
        var noStart = DP(nums, 0, nums.Length-2);
        var noEnd = DP(nums, 1, nums.Length-1);        
        return Math.Max(noStart, noEnd);
        
    }
    
    private int DP(int[] nums, int startIdx, int endIdx) {
        var len = endIdx-startIdx+1;
        var soln = new int[len];              
        soln[0] = nums[startIdx];      
        soln[1] = Math.Max(nums[startIdx + 1], soln[0]);

        for (int i = startIdx + 2, j = 2; j < soln.Length; i++, j++) {  
            soln[j] = Math.Max(soln[j-2]+nums[i], soln[j-1]);
        }
        return soln[soln.Length-1];
    }
}