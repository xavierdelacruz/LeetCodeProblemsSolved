public class Solution {
    public int NumTrees(int n) {
        
        // Catalan Numbers
        var soln = new int[n+1];
        soln[0] = 1;
        soln[1] = 1;
        for (int i = 2; i <= n; i++) {
            for (int j = 0; j < i; j++) {
                soln[i] += soln[j]*soln[i-j-1];
            }   
        }        
        return soln[n];        
    }
}