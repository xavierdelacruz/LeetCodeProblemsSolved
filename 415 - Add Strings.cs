public class Solution {
    public string AddStrings(string num1, string num2) {
        if (string.IsNullOrEmpty(num1) && string.IsNullOrEmpty(num2)) {
            return "";
        }
        
        int i = num1.Length-1;
        int j = num2.Length-1;
        int carry = 0;
        StringBuilder sb = new StringBuilder();
        while (i >= 0 || j >= 0 || carry > 0) {
            
            int iVal = i >= 0 ? (int) num1[i] - '0' : 0;
            int jVal = j >= 0 ? (int) num2[j] - '0' : 0;
            
            int sum = iVal + jVal + carry;
            int actualDigit = sum % 10;
            carry = sum / 10;
            sb.Append(actualDigit);
            i--;
            j--;
            
        }
        char[] charArr = sb.ToString().ToCharArray();        
        Array.Reverse(charArr);
        return new String(charArr);
        
    }
}