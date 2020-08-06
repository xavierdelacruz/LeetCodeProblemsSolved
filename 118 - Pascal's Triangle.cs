public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var res = new List<IList<int>>();      
        if (numRows <= 0) {
            return res;
        }    
        
        var prevList = new List<int>();
        for (int i = 0; i < numRows; i++) {
            var len = i + 1;
            var j = 0;
            var list = new List<int>();
            while (j < len) {                
                if (j == 0 || j == len-1) {
                    list.Add(1);
                } else {
                    var first = prevList[j];
                    var second = prevList[j-1];
                    var sum = first + second;
                    list.Add(sum);
                }
                j++;
            }
            res.Add(list);
            prevList = list;
        }     
        return res;
    }
}