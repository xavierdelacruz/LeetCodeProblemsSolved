public class Solution {
    public int[] SortArrayByParityII(int[] A) {
        
        if (A.Length <= 1) {
            return A;
        }
        
        var even = new List<int>();
        var odd = new List<int>();
        
        // O(n)
        foreach (var item in A) {
            if (item % 2 == 0) {
                even.Add(item);
            } else {
                odd.Add(item);
            }
        }
        
        int[] res = new int[A.Length];
        var evenIdx = 0;
        var oddIdx = 0;
        
        // O(n)
        for (int i = 0; i < res.Length; i++) {           
            if (i % 2 == 0 && even.Count != 0) {
                res[i] = even[evenIdx];
                evenIdx++;
            } else if (i % 2 != 0 && odd.Count != 0) {
                res[i] = odd[oddIdx];
                oddIdx++;
            }  
        }
        
        return res;
    }
}