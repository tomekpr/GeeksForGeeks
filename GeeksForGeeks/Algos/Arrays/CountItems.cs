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
	}
}
