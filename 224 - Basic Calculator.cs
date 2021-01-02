public class Solution {
    public int Calculate(string s) {      
        if (s.Length == 0) {
            return 0;
        }
        
        Stack<int> stack = new Stack<int>();
        int currnum = 0; // This is where we form each number.
        int res = 0; // The actual result
        int sign = 1;
        
        for (int i = 0; i < s.Length; i++) {
            
            char c = s[i];
            
            // First, check if the current char is a digit
            // Then check for other cases
            if (Char.IsDigit(c)) {
                int val = (int) (c - '0');
                currnum = 10 * currnum + val;
            } else if (c == '+') {
                res += sign * currnum;
                sign = 1;
                
                // Reset
                currnum = 0;
            } else if (c == '-') {
                res += sign * currnum;
                sign = -1;
                
                // Reset
                currnum = 0;
            } else if (c == '(') {
                // Once we encounter a parenthesis, store all the curren num, the result, and sign because it's a new expression.
                stack.Push(res);
                stack.Push(sign);
                
                // Reset. Start of a new expression. We stored the current result inside already.
                sign = 1;
                res = 0;
            } else if (c == ')') {
                res += sign * currnum;
                
                // Once we encounter a closing paren, we pop all of it. to evaluate the curr expression. (since we pushed the sign first)
                res *= stack.Pop();
                
                // Now add the other result
                res += stack.Pop();
                
                //Reset
                currnum = 0;            
            }
        }
        
        Console.WriteLine("res: " + res + " sign: " + sign + " currnum: " + currnum);
        return res + (sign * currnum);
    }
}