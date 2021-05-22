public class WordDictionary {

    protected class Node {
        public Dictionary<char, Node> children = new Dictionary<char, Node>();      
        public bool IsEnd = false;       
        public Node() {}
    }
    
    protected readonly Node Root;
    
    /** Initialize your data structure here. */
    public WordDictionary() {
        Root = new Node();
    }
    
    public void AddWord(string word) {
        
        if (string.IsNullOrEmpty(word)) {
            return;
        }
        
        Node curr = Root;
        
        foreach (char c in word.ToLower()) {
                        
            // If it does not contain the character, create a new node for it
            // O(1) lookup
            if (!curr.children.ContainsKey(c)) {
                curr.children.Add(c, new Node());
            }
            
            // Finally, update cur to the next, since it will now contain c.
            curr = curr.children[c];
        }
        
        curr.IsEnd = true;
    }
    
    public bool Search(string word) {
        if (string.IsNullOrEmpty(word)) {
            return false;
        }     
        
        Node curr = Root;
        return SearchDFS(word.ToLower(), 0, curr);
    }
    
    private bool SearchDFS(string word, int idx, Node curr) {
        // CASE 1 GOAL: We found the word we want    
        if (idx >= word.Length) {   
            return curr.IsEnd;
        }        
        bool res = false;
        // CASE 2: If we encounter a period, move to the next one and check.
        // This also covers the case where our current character (word[i])
        if (word[idx] == '.') {
            // Iterate through all children here RECURSIVELY (DFS)
            foreach (var kvp in curr.children) {
                res = res || SearchDFS(word, idx+1, kvp.Value);               
            }
        // CASE 3: It does not exist here. just return false
        } else if (!curr.children.ContainsKey(word[idx])) {
            return false;
        } else {
        // CASE 4: Continue searching since we found it in the current dictionary of children.
            Node next = curr.children[word[idx]];
            res = res || SearchDFS(word, idx+1, next);
        }
        
        return res;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */