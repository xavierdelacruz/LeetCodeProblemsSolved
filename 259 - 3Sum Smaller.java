public class Solution {
    /**
     * @param nums:  an array of n integers
     * @param target: a target
     * @return: the number of index triplets satisfy the condition nums[i] + nums[j] + nums[k] < target
     */
    public int threeSumSmaller(int[] nums, int target) {
        
        if (nums.length == 0) {
            return 0;
        }
        
        Arrays.sort(nums);
        int res = 0;
        for (int i = 0; i < nums.length-2; i++) {
            int j = i + 1;
            int k = nums.length-1;
            while (j < k) {
                int sum = nums[i] + nums[j] + nums[k];
                
                if (sum < target) {
                    res += k - j;
                    j++;
                } else {
                    k--;
                }
            }
        }
        return res;
    }
}