<Query Kind="Program" />

/*
https://leetcode.com/problems/next-greater-element-i

You are given two arrays (without duplicates) nums1 and nums2 where nums1’s elements are subset of nums2.
Find all the next greater numbers for nums1's elements in the corresponding places of nums2.
The Next Greater Number of a number x in nums1 is the first greater number to its right in nums2. If it does not exist, output -1 for this number.

*/

void Main()
{
	NextGreaterElement(new[]{4,1,2}, new[]{1,3,4,2}).Dump();
}

private static int[] NextGreaterElement(int[] findNums, int[] nums)
{
	if(findNums == null || findNums.Length == 0)
	{
		return new int[0];
	}
	var result = new List<int>();
	
	var stack = new Stack<int>();
	var nextGreater = new Dictionary<int, int>();
	foreach (var num in nums)
	{
		while (stack.Count != 0 && stack.Peek() < num)
		{
			nextGreater[stack.Pop()] = num;
		}
		stack.Push(num);
	}
	foreach (var num in findNums)
	{
		int value;
		if(nextGreater.TryGetValue(num, out value))
		{
			result.Add(value);
		}
		else
		{
			result.Add(-1);
		}
	}
	return result.ToArray();
}