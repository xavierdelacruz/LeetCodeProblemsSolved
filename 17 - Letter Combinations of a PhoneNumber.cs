public class Solution {
    public IList<string> LetterCombinations(string digits) {
        
        // Again, if we are to return all possible combinations, this will involve some form of backtracking.       
        var list = new List<string>();
        if (string.IsNullOrEmpty(digits)) {
            return list;
        }
        
        var dict = new Dictionary<char, char[]>();
        dict.Add('1', new char[] {});
        dict.Add('2', new char[] { 'a', 'b', 'c'});
        dict.Add('3', new char[] { 'd', 'e', 'f'});
        dict.Add('4', new char[] { 'g', 'h', 'i'});
        dict.Add('5', new char[] { 'j', 'k', 'l'});
        dict.Add('6', new char[] { 'm', 'n', 'o'});
        dict.Add('7', new char[] { 'p', 'q', 'r', 's'});
        dict.Add('8', new char[] { 't', 'u', 'v'});
        dict.Add('9', new char[] { 'w', 'x', 'y', 'z'});
        
        // Backtracking call
        LetterCombinationHelper(digits, 0, "", list, dict);
        
        return list;    
    }
    
    private void LetterCombinationHelper(string digits, int index, string curr, IList<string> comb, Dictionary<char, char[]> dict) {
        if (index >= digits.Length) {
            comb.Add(curr.ToString());
            return;
        }
        
        var currDigit = digits[index];
        var letters = dict[currDigit];
        
        for (int i = 0; i < letters.Length; i++) {
            LetterCombinationHelper(digits, index+1, curr + letters[i] , comb, dict);
        }       
    }
}