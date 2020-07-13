/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
     
        if (root == null) {
            return "[]";
        }
        var sb = new StringBuilder();       
        sb.Append("[");
        
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while (q.Count > 0) {
            var curr = q.Dequeue();
            
            if (curr == null) {
                sb.Append("null");
                sb.Append(",");
                continue;
            } else {
                sb.Append(curr.val);
                sb.Append(",");
            }
        
            q.Enqueue(curr.left);
            q.Enqueue(curr.right);
        }
        
        sb.Remove(sb.Length-1, 1);
        sb.Append("]");
        return sb.ToString();
        
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        // Check if input is bad to begin with.
        if (string.IsNullOrEmpty(data)) {
            return null;
        }
        
        // This is the case where we have a string "[]"
        if (data.Length <= 2) {
            return null;
        }
        
        var len = data.Length;      
        var startTrim = data.Replace("[", "");
        var endTrim = startTrim.Replace("]", "");   
        // This contains the actual data per node now, as strings.
        var split = endTrim.Split(",");

        var root = new TreeNode(Int32.Parse(split[0]));
        
        // Contains all data we need for level-order traversal.
        var strQ = TransferToQueue(split);
        strQ.Dequeue();
        
        // This will be important for level order traversal.
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while (strQ.Count != 0) {           
            var qCount = q.Count;            
            while(qCount > 0) {
                var curr = q.Dequeue();
                qCount--;
                var leftStr = strQ.Dequeue();
                var rightStr = strQ.Dequeue();
                
                if (!leftStr.Equals("null")) {
                    var val = Int32.Parse(leftStr);
                    curr.left = new TreeNode(val);
                    q.Enqueue(curr.left);
                }
                
                if (!rightStr.Equals("null")) {
                    var val = Int32.Parse(rightStr);
                    curr.right = new TreeNode(val);
                    q.Enqueue(curr.right);
                }
                
            }
        }
        
        return root;
    }
    
    private Queue<string> TransferToQueue(string[] data) {
        var queue = new Queue<string>();   
        foreach (var str in data) {
            queue.Enqueue(str);
        }
        return queue;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));