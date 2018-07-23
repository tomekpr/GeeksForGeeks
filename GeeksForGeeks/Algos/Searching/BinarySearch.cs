using NUnit.Framework;
using System;

namespace GeeksForGeeks.Algos.Searching
{
	class BinarySearch
	{
		public int Search(int[] arr, int k)
		{
			return Search(arr, k, 0, arr.Length - 1);
		}

		public static int Search(int[] arr, int k, int left, int right)
		{
			while (left <= right)
			{
				int mid = (int)Math.Floor((left + right) / 2.0);
				if (arr[mid] == k) return mid;
				if (k > arr[mid]) left = mid + 1;
				else right = mid - 1;
			}

			return -1;
		}
	}

	[TestFixture]
	public class TestBinarySearch
	{
		[Test]
		public void Test1()
		{
			var nums = new int[] { 1, 2, 3, 4, 5 };
			var k = 7;

			var bs = new BinarySearch();
			var result = bs.Search(nums, k);

			Assert.That(result, Is.EqualTo(-1));
		}

		[Test]
		public void Test2()
		{
			var nums = new int[] { 1, 2, 3, 4, 5 };
			var k = 3;

			var bs = new BinarySearch();
			var result = bs.Search(nums, k);

			Assert.That(result, Is.EqualTo(2));
		}

		[Test]
		public void Test3()
		{
			var nums = new int[] { 1, 2, 3, 4, 5 };
			var k = 1;

			var bs = new BinarySearch();
			var result = bs.Search(nums, k);

			Assert.That(result, Is.EqualTo(0));
		}

		[Test]
		public void Test4()
		{
			var nums = new int[] { 1, 2, 3, 4, 5 };
			var k = 5;

			var bs = new BinarySearch();
			var result = bs.Search(nums, k);

			Assert.That(result, Is.EqualTo(4));
		}
	}
}
