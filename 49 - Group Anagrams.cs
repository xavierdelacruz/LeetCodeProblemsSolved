public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {          
        List<IList<string>> result = new List<IList<string>>();
        
        if (strs.Length <= 0) {
            return result;
        }
        
        // O(n * klogk) when using a dictionary to populate it
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
           
        // Outer loop at O(n)
        for (int i = 0; i < strs.Length; i++) {
            
            // This sort is O(klogk), where k is the length of the string.
            string sortedStr = SortString(strs[i]);
            
            // Lookup is O(1)
            if (!dict.ContainsKey(sortedStr)) {
                List<string> grouped = new List<string>();
                grouped.Add(strs[i]);
                dict.Add(sortedStr, grouped);
            } else {
                // If the current string has length greater than 1
                // Then we start caring about duplicates.
                dict[sortedStr].Add(strs[i]);
            }            
        }
        
        foreach (var kvp in dict) {
            result.Add(kvp.Value);
        }
        
        return result;
    }
    
    private string SortString(string str) {
        char[] charArr = str.ToCharArray();
        Array.Sort(charArr);
        return new string(charArr);
    }

}