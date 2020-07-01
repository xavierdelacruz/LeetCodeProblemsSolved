public class Solution {
    public int FindPairs(int[] nums, int k) {
        
        // Base case. No pair is generated.
        if (nums.Length < 2 || k < 0) {
            return 0;
        }
        
        // O(nlogn), since we need to sort.
        Array.Sort(nums);
        
        int i = 0;
        int j = i+1;

        // C# implicit typing. We are storing coordinates.
        var pairs = new HashSet<(int x, int y)>();
        
        while (i < nums.Length && j < nums.Length) {
            var diff = Math.Abs(nums[j]-nums[i]);
            
            // This ensures that j stays ahead of i.
            if (i == j) {
                j++;
                continue;
            }
            
            // CASE 1: This means that we found a target. We increment the pair counter.
            // We also advance both pointers.
            if (diff == k && i != j) {
                pairs.Add((nums[i], nums[j]));
                i++;
                j++;
            } 
            
            // CASE 2: This means that the diff is larger than the target.
            // We will need to make the diff smaller by incrementing i (going closer to j).
            if (diff > k) {
                i++;
            }
            
            // CASE 3: This means that the diff is smaller than the target
            // We will need to make the diff larger by incrementing j (farther from i).
            if (diff < k) {
                j++;
            }
        }
        
        return pairs.Count;
        
    }
}