public class Solution {
    public IList<string> FizzBuzz(int n) {
        
        var list = new List<string>();

        // Two Case approach. Just Append if it fulfills both cases.
        // Otherwise, append the actual number.
        for (int i = 1; i <= n; i++) {      
            
            var hasFizzBuzz = false;
            var sb = new StringBuilder();
            
            if (i % 3 == 0) {
                hasFizzBuzz = true;
                sb.Append("Fizz");
            }
            
            if (i % 5 == 0) {
                hasFizzBuzz = true;
                sb.Append("Buzz");
            }
            
            list.Add(hasFizzBuzz ? sb.ToString() : i.ToString());
        }
        return list;   
    }
}