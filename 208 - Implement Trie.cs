public class Trie {

    // We need to define a Node for the trie
    // This will include its own children
    // And to indicate if the node is a terminating node
    protected class Node {
        private static int ALPHABET_COUNT = 26;
        
        // An array of children (ASCII array style)
        // This is inherent sorted based on the conversion between the character.
        // We will inherently map the Node based on its chracter index on an ASCII table
        public Node[] Children = new Node[ALPHABET_COUNT];
        
        public bool IsEnd = false;
        
        // Constructor                                        
        public Node() {}
    }
    
    
    protected Node Root;
    
    /** Initialize your data structure here. */
    public Trie() {
        Root = new Node();
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {   
        
        if (string.IsNullOrEmpty(word)) {
            return;
        }
        
        Node curr = Root;
        // Ensure that word is in lower case.
        // this is despite it being guaranteed.
        foreach (char c in word.ToLower()) {
            // First, find the find the index of that character
            int idx = c - 'a';
            
            // If the entry of this trie is null, then create a new node for it
            // Otherwise, set the tmp to the existing child
            if (curr.Children[idx] == null) {
                curr.Children[idx] = new Node();
            }
            
            // Now, set the next tmp node for the next string as the newly created child at that index.
            // In this case, it will keep digging down.
            curr = curr.Children[idx];
        }
        
        // Finally, designate this as a known word.
        curr.IsEnd = true;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        
        if (string.IsNullOrEmpty(word)) {
            return false;
        }
        
        Node curr = Root;
        
        // Ensure that word is in lower case.
        // this is despite it being guaranteed.
        foreach (char c in word.ToLower()) {
            // First, find the find the index of that character
            int idx = c - 'a';
            // If the entry of this trie is null then it does not exist.
            // Return false
            if (curr.Children[idx] == null) {
                return false;
            }
            
            // Now, set the next tmp node for the next string as the newly created child at that index.
            // In this case, it will keep digging down.
            curr = curr.Children[idx];
        }
        
        // Finally
        return curr != null ? curr.IsEnd : false;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        
        if (string.IsNullOrEmpty(prefix)) {
            return false;
        }
        
        Node curr = Root;
        
        // Ensure that word is in lower case.
        // this is despite it being guaranteed.
        foreach (char c in prefix.ToLower()) {
            // First, find the find the index of that character
            int idx = c - 'a';
            
            // If the entry of this trie is null then it does not exist.
            // Retuen false
            if (curr.Children[idx] == null) {
                return false;
            }
            
            // Now, set the next tmp node for the next string as the newly created child at that index.
            // In this case, it will keep digging down.
            curr = curr.Children[idx];
        }
            
        return curr != null;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */