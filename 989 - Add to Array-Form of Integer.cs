public class Solution {
    public IList<int> AddToArrayForm(int[] A, int K) {        
        if (A.Length == 0) {
            return A.ToList();
        }
        var carry = 0;
        var i = A.Length-1;
        while (i >= 0) {
            var currDigit = K % 10;
            var sum = currDigit + A[i] + carry;
            A[i] = sum % 10;
            carry = sum/10;
            K = K/10;
            i--;
        }
        var res = HandleExceptionalCases(A, carry, K);
        return res.Count > 0? res : A.ToList();
    }
    
    private List<int> HandleExceptionalCases(int[] A, int carry, int K) {
        var result = new List<int>();
        if (K > 0) {  
            var numDigits = (int) Math.Floor(Math.Log10(K) + 1);
            var temp = new int[numDigits];
            while (numDigits > 0) {               
                var sum = carry + K % 10;
                temp[numDigits-1] = sum % 10;
                carry = sum/10;
                K = K/10;
                numDigits--;
            }            
            if (carry > 0)  {
                result.Add(carry);
            }
            foreach (var item in temp) {
                result.Add(item);
            }
            foreach (var item in A) {
                result.Add(item);
            }

        } else if (K <= 0) {
            if (carry > 0)  {
                result.Add(carry);
            }
            foreach (var item in A) {
                result.Add(item);
            }                
        }
        
        return result;
    }
}