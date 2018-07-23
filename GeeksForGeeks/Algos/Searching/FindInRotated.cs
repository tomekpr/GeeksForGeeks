using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Searching
{
	class FindInRotated
	{
		// https://www.geeksforgeeks.org/search-an-element-in-a-sorted-and-pivoted-array/
		public int Find(int[] arr, int k)
		{
			var pivot = 1;
			for (int i = 1; i < arr.Length; i++)
			{
				if (arr[i] < arr[i - 1])
				{
					pivot = i-1;
					break;
				}
			}

			if (pivot == -1)
			{
				// Array not rotated at all
				return BinarySearch.Search(arr, k, 0, arr.Length - 1);
			}

			if (k >= arr[0] && k <= arr[pivot]) return BinarySearch.Search(arr, k, 0, pivot);
			return BinarySearch.Search(arr, k, pivot + 1, arr.Length - 1);
		}
	}

	[TestFixture]
	public class FindInRotatedTests
	{
		[Test]
		public void Test1()
		{
			int[] arr = new int[] { 5, 6, 7, 8, 9, 10, 1, 2, 3 };
			int k = 8;

			var fr = new FindInRotated();
			var result = fr.Find(arr, k);

			Assert.That(result, Is.EqualTo(3));
		}

		[Test]
		public void Test2()
		{
			int[] arr = new int[] { 5, 6, 7, 8, 9, 10, 1, 2, 3 };
			int k = 30;

			var fr = new FindInRotated();
			var result = fr.Find(arr, k);

			Assert.That(result, Is.EqualTo(-1));
		}

		[Test]
		public void Test3()
		{
			int[] arr = new int[] { 30, 40, 50, 10, 20 };
			int k = 10;

			var fr = new FindInRotated();
			var result = fr.Find(arr, k);

			Assert.That(result, Is.EqualTo(3));
		}
	}
}
