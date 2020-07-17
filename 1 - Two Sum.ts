function twoSum(nums: number[], target: number): number[] {
    if (nums.length <= 1) {
        var arr : number[] = [];
        return arr;
    }
    let dict = new Map();
    for (var i = 0; i < nums.length; i++) {
        if (!dict.has(nums[i])) {
            dict.set(nums[i], i);
        } else {
            dict.set(nums[i], i);
        }
    }
    
    var result : number[] = [];
    var j = 0;
    
    while (j < nums.length) {
        var diff = target-nums[j];        
        if (dict.has(diff) && dict.get(diff) != j){
            result[0] = j
            result[1] = dict.get(diff);
            return result;
        }
        j++;
    }   
    return result;    
};