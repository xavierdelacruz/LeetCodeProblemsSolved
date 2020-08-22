public class Solution {
    public void SortColors(int[] nums) {
        
        if (nums.Length <= 1) {
            return;
        }
        // Counting sort       
        var dict = new Dictionary<int, int>();      
        for (int i = 0; i < nums.Length; i++) {
            if (!dict.ContainsKey(nums[i])) {
                switch (nums[i]) {
                    case 0:
                        dict.Add(0, 1);
                        break;
                    case 1:
                        dict.Add(1, 1);
                        break;
                    case 2:
                        dict.Add(2, 1);
                        break;
                }
            } else {
                dict[nums[i]]++;
            }
        }
        
        for (int j = 0; j < nums.Length; j++) {
            if (dict.ContainsKey(0) && dict[0] > 0) {
                nums[j] = 0;
                dict[0]--;
            } else if (dict.ContainsKey(1) && dict[1] > 0) {
                nums[j] = 1;
                dict[1]--;
            } else if (dict.ContainsKey(2) && dict[2] > 0) {
                nums[j] = 2;
                dict[2]--;
            }
        }
        
        return;
    }
}