public class Solution {
    public IList<string> GenerateParenthesis(int n) 
    {
        IList<string> list = new List<string>();
        Generate(list, new char[2*n], 0, n, n);
        return list;
    }
    
    public void Generate(IList<string> list, char[] curr, int currLen, int leftRemaining, int rightRemaining)
    {
        if (leftRemaining == 0 && rightRemaining == 0)
        {
            list.Add(new string(curr));
        }
        else
        {
            if (leftRemaining > 0)
            {
                curr[currLen] = '(';
                Generate(list, curr, currLen + 1, leftRemaining - 1, rightRemaining);
            }
            if (rightRemaining > leftRemaining)
            {
                curr[currLen] = ')';
                Generate(list, curr, currLen + 1, leftRemaining, rightRemaining - 1);
            }
        }
    }
}