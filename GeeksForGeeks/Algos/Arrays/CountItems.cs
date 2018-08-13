using NUnit.Framework;

namespace GeeksForGeeks.Algos.Arrays
{
	// Another better approach: use binary search twice!
	// First search - find beg of the range.
	// Second search - find end of the range.
	// Dont count elements 1 by 1 (O(n)) just do simple math end-beg + 1
	// https://codesays.com/2014/solution-to-number-of-k-from-jobdu/
	class ItemCountInArray
	{
		public int CountItems(int[] arr, int k)
		{
			// 1. Find the item in the array
			// 2. Expand your search in both directions

			int left = 0, right = arr.Length - 1;

			int foundIndex = -1;

			while (left <= right) // base case of 2 elements: left = 0, right = 2, mid => 0+2/2 = 1 and narrow down to 0
			{
				int mid = (left + right) / 2; // overflow!
				if (arr[mid] == k)
				{
					foundIndex = mid;
					break;
				}
				else if (k >= arr[mid])
				{
					left = mid + 1;
				}
				else
				{
					right = mid - 1;
				}
			}

			// Check for element not found
			if (foundIndex == -1) return 0;

			int count = 0;
			int i = foundIndex;

			// count-left
			while (i >= 0 && arr[i] == k)
			{
				count++;
				i--;
			}

			// count-right
			int j = foundIndex + 1; // becase [i] already count the element at foundIndex!
			while (j < arr.Length && arr[j] == k)
			{
				count++;
				j++;
			}

			return count;
		}

		public static int count(int[] input, int target)
		{
			int begin = 0, end = 0;
			// Find the begin position of target(s) in input, with binary search.
			int bs_begin = 0, bs_end = input.Length - 1, bs_middle;
			while (bs_begin <= bs_end)
			{
				bs_middle = (bs_begin + bs_end) / 2;
				if (target <= input[bs_middle]) bs_end = bs_middle - 1;
				else bs_begin = bs_middle + 1;
			}
			if (bs_end + 1 >= input.Length || input[bs_end + 1] != target)
			{
				// Did not find the target in the input array.
				return 0;
			}
			else
			{
				begin = bs_end + 1;
			}
			// Find the end position of target(s) in input, with binary search.
			bs_begin = begin;
			bs_end = input.Length - 1;
			while (bs_begin <= bs_end)
			{
				bs_middle = (bs_begin + bs_end) / 2;
				if (target < input[bs_middle]) bs_end = bs_middle - 1;
				else bs_begin = bs_middle + 1;
			}
			end = bs_begin - 1;
			return end - begin + 1;
		}
	}

	[TestFixture]
	public class TestItemCountInArray
	{
		[TestCase(3, 4)]
		[TestCase(1, 1)]
		[TestCase(17, 0)]
		public void Test(int k, int exp)
		{
			var sut = new ItemCountInArray();
			var result = sut.CountItems(new int[] { 1, 2, 3, 3, 3, 3, 4, 5 }, k);

			Assert.That(result == exp);
		}

		[TestCase(3, 4)]
		[TestCase(1, 1)]
		[TestCase(17, 0)]
		public void Test2(int k, int exp)
		{
			var sut = new ItemCountInArray();
			var result = ItemCountInArray.count(new int[] { 1, 2, 3, 3, 3, 3, 4, 5 }, k);

			Assert.That(result == exp);
		}
	}
}
