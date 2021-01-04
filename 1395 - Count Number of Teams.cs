public class Solution {
    public int NumTeams(int[] rating) {
        
        if (rating.Length < 3) {
            return 0;
        }
        
        int count = 0;
        for (int i = 0; i < rating.Length-2; i++) {
            for (int j = i+1; j < rating.Length-1; j++) {
                for (int k = j+1; k < rating.Length; k++) {
                    // Transitive properties.
                    if ((rating[i] < rating[j] && rating[j] < rating[k]) || (rating[i] > rating[j] && rating[j] > rating[k])) {
                        count++;
                    }
                }
            }
        } 
        return count;
    }
}
    