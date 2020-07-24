public class Solution {
    public int[] PlusOne(int[] digits) {
        if (digits.Length == 0) {
            return new int[1] {1};
        }
        
        var i = digits.Length-1;
        var carry = 0;
        
        while (i >= 0) {            
            var sum = digits[i] + 1;          
            carry = sum/10;
            digits[i] = sum%10;            
            if (carry == 0) {
                break;
            }
            i--;
        }
        
        if (carry > 0) {
            var newArr = new int[digits.Length+1];
            newArr[0] = carry;
            Array.Copy(digits, 0, newArr, 1, digits.Length);            
            return newArr;
        }
        
        return digits;
    }
}