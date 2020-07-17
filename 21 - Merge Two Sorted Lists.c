/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */

struct ListNode* mergeTwoLists(struct ListNode* l1, struct ListNode* l2){ 
    if (l1 == NULL && l2 == NULL) {
        return NULL;
    }
    
    if (l1 == NULL && l2 != NULL) {
        return l2;
    }
    
    if (l1 != NULL && l2 == NULL) {
        return l1;
    }

    struct ListNode * prev = (struct ListNode*) malloc(sizeof(struct ListNode));
    struct ListNode * head = prev;
    
    while (l1 != NULL && l2 != NULL) {
        if (l1->val >= l2->val) {
            prev->next = l2;
            struct ListNode * tmp = l2->next;
            prev = prev->next;
            l2->next = l1;
            l2 = tmp;
        } else {
            prev->next = l1;
            struct ListNode * tmp = l1->next;
            prev = prev->next;
            l1->next = l2;
            l1 = tmp;
        }
    }
    return head->next;
}








