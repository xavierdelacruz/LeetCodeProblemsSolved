class Solution {
    public List<List<Integer>> threeSum(int[] nums) {
        
        List<List<Integer>> res = new ArrayList<List<Integer>>();
        if (nums.length < 3) {
            return res;
        }
        
        // Key step
        Arrays.sort(nums);
        
        for (int i = 0; i < nums.length-2; i++) {

            int j = i + 1;
            int k = nums.length-1;
            
            if (i > 0 && nums[i-1] == nums[i]) {
                continue;
            }
            
            while (j < k) {
                if (nums[j-1] == nums[j] && j > i + 1) {
                    j++;
                    continue;
                }
                var sum = nums[i] + nums[j] + nums[k];
                if (sum == 0) {
                    List<Integer> triplet = new ArrayList<Integer>();
                    triplet.add(nums[i]);
                    triplet.add(nums[j]);
                    triplet.add(nums[k]);
                    res.add(triplet);
                    j++;
                    
                } else if (sum > 0) {
                    k--;
                    continue;
                } else {
                    j++;
                    continue;
                }
            }
        }
        
        return res;
    }
}