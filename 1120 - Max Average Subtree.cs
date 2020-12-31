using System;
		
public class TreeNode {
      public int val;
      public TreeNode left, right;
      public TreeNode(int val) {
          this.val = val;
          this.left = this.right = null;
	  }
}
public class Program
{
	public static void Main()
	{
		var root = new TreeNode(1);
		root.left = new TreeNode(-5);
		root.right = new TreeNode(11);
		
		root.left.left = new TreeNode(1);
		root.left.right = new TreeNode(2);
		
		root.right.left = new TreeNode(4);
		root.right.right = new TreeNode(-2);
		
		double max = Int32.MinValue;
		TreeNode res = null;
		Result result = FindMaxAvgSubTree(root, ref max, ref  res);
		Console.WriteLine("Max avg: " + max);
		Console.WriteLine("Treenode val: " + res.val);
	}
	
	
	public class Result {
		public int sum {get; set;}
		public int count {get; set;}
		
		public Result(int sum, int count) {
			this.sum = sum;
			this.count = count;
		}
	}
	
	// Can use global variable.
	public static Result FindMaxAvgSubTree(TreeNode root, ref double maxAvgSoFar, ref TreeNode result) {
		if (root == null) {
			return new Result(0, 0);
		}
		Result lRes = FindMaxAvgSubTree(root.left, ref maxAvgSoFar, ref result);
		Result rRes = FindMaxAvgSubTree(root.right, ref maxAvgSoFar, ref result);
		int sum = (root.val + lRes.sum + rRes.sum);
		int count = (1 + lRes.count + rRes.count);
		double average = (double) sum/ (double) count;
		if (maxAvgSoFar < average) {
			result = root;
			maxAvgSoFar = average;	
		}
		
		return new Result(lRes.sum + rRes.sum + root.val, lRes.count + rRes.count + 1);
	}
}