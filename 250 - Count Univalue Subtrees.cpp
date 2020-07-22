class Solution {
public:
    /**
     * @param root: the given tree
     * @return: the number of uni-value subtrees.
     */
     
    int countUnivalSubtrees(TreeNode * root) {
        if (!root) {
            return 0;
        }
        int count = 0;
        isUnival(root, count);
        return count;
    }
    
    bool isUnival(TreeNode * root, int &count) {
        
        if (!root) {
            return true;
        }
        
        bool left = isUnival(root->left, count);
        bool right = isUnival(root->right, count);
        
        if (!left || !right) {
            return false;
        }
        
        if (root->left && root->left->val != root->val) {
            return false;
        }
        
        if (root->right && root->right->val != root->val) {
            return false;
        }
        
        count++;
        return false;
    }
};