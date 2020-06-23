public class Solution {
    public string Convert(string s, int numRows) {
        
        // NOTE: THIS WILL BE REDONE. This is not my best solutionf or this problem.
        if (numRows == 0 || s == null) {
            return "";
        }
        
        if (numRows == 1 || numRows >= s.Length || numRows < 0) {
            return s;
        }
         
        var c = s.ToCharArray();
        var result = new char[s.Length];
        
        int i = 0;
        int scan = 0;
        int iter = 0;
        int row = 0;
        bool isIncreasing = true;
        
        while (iter < numRows) {         
            if (row == iter && i < c.Length) {
                result[i] = c[scan];
                i++;
            }
            scan++;
                   
            if (row < numRows-1 && isIncreasing) {
                row++;
            } else if (row == numRows-1 && isIncreasing) {
                row--;
                isIncreasing = false;
            } else if (row == 0 && !isIncreasing) {
                row++;
                isIncreasing = true;
            } else {
                row--;
            }
                     
            if (scan == s.Length) {
                iter++;
                row = 0;
                scan = 0;
            }
        }
        
        return new String(result);
    }
}