class Solution {
    public int Trap(int[] height) {
        
        // This is the case where
        if (height.Length <= 2) {
            return 0;
        }
        
        int i = 0;
        int j = height.Length-1;
        
        // Keeps track of the largest i and j we've seen so far.
        // This is essentially our boundaries.
        int i_max = Int32.MinValue;
        int j_max = Int32.MinValue;
        
        int totalRain = 0;
        
        // O(n) iteration using 2 pointer method due to conditional and termination when i and j are equal.
        while (i < j) {
            i_max = Math.Max(height[i], i_max);
            j_max = Math.Max(height[j], j_max);
            
            // If the left side is larger, then we need to update our total by checking if our current i is smaller vs iM-ax (max boundary seen so far)
            // If its smaller, then we would account for the new unit water by adding its difference to our answer.
            // If not, it just becomes 0 (we add nothing)
            if (height[i] < height[j]) {
                
                int diff = i_max - height[i]; 
                totalRain += diff;       
                i++;
            } else {
                // Similar story here. If the right side is larger, then we check if our current j is smaller vs j_max (max boundary seen so far)
                // If it's smaller, then we would account for the new unit of water by adding its difference to our answer.
                // If not, it just becomes 0 (we add nothing)
                int diff = j_max - height[j]; 
                totalRain += diff;
                j--;
            }
        }
        
        
        return totalRain;
    }
}