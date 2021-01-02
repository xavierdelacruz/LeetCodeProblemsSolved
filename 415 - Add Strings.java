class Solution {
    public String addStrings(String num1, String num2) {
        
        if (num1.length() == 0 && num2.length() == 0) {
            return num1;
        }
        
        int i = num1.length()-1;
        int j = num2.length()-1;
        int carry = 0;
        StringBuilder sb = new StringBuilder();
        while (i >= 0 || j >= 0 || carry > 0) {
            int iVal = i >= 0 ? (int) (num1.charAt(i) - '0') : 0;
            int jVal = j >= 0 ? (int) (num2.charAt(j) - '0') : 0;
            int sum = jVal + iVal + carry;
            int actualDigit = sum % 10;
            carry = sum / 10;
            sb.append(actualDigit);
            i--;
            j--;
        }
        
        return sb.reverse().toString();
    }
}