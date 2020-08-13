public class Solution {
    public int[] SortArrayByParity(int[] A) {
        if (A.Length <= 1) {
            return A;
        }
        
        var even = new Queue<int>();
        var odd = new Queue<int>();
        foreach (var item in A) {
            if (item % 2 == 0) {
                even.Enqueue(item);
            } else {
                odd.Enqueue(item);
            }
        }
        
        for (int i = 0; i < A.Length; i++) {
            if (even.Count != 0) {
                A[i] = even.Dequeue();
            } else {
                A[i] = odd.Dequeue();
            }
        }
        return A;
    }
}