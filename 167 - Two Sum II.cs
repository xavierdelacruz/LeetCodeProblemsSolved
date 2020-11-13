public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        if (numbers.Length <= 0) {
            return new int[2];
        }
        
        int l = 0;
        int r = numbers.Length - 1;
        while (l < r) {
            
            // Case 1: if nums[r]+nums[l] < 0 then go smaller for nums[i]
            if (numbers[l] + numbers[r] > target) {
                r--;
            
            // Case 2: if nums[r]+nums[ll > 0 then go bigger for nums[i]
            } else if (numbers[l] + numbers[r] < target) {
                l++;
                
            // Case 3: if nums[r]+nums[l] == 0 then you found your answer
            } else {
                return new int[] { l+1, r+1 };
            }
        }
        
        return new int[2];
    }
}