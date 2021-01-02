class Solution {
    public int calculate(String s) {
        
        if (s.length() == 0) {
            return 0;
        }
        
        int currNum = 0; // stores current chunk of numbers.
        int sign = 1;
        int result = 0;
        
        Stack<Integer> stack = new Stack<Integer>();
        
        for (int i = 0; i < s.length(); i++) { 
            char c = s.charAt(i);
            if (Character.isDigit(c)) {
                int value = (int) (s.charAt(i) - '0');
                currNum = (currNum * 10) + value;               
            } else if (c == '+') {
                result += currNum * sign;
                sign = 1;
                currNum = 0;            
            } else if (c == '-') {
                result += currNum * sign;
                sign = -1;
                currNum = 0;               
            } else if (c == '(') {
                stack.push(result);
                stack.push(sign);
                sign = 1;
                currNum = 0;        
                result = 0;
            } else if (c == ')') {
                result += currNum * sign;
                result *= stack.pop();
                result += stack.pop();
                currNum = 0;
                sign = 1;
            }
        }
        return result + (currNum * sign);
    }
}