using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeeksForGeeks.Algos.Arrays
{
	// https://app.codility.com/programmers/lessons/99-future_training/array_inversion_count/
	// https://www.geeksforgeeks.org/counting-inversions/
	// Not finished!
	class CountInversionPairs
	{
		public int Count(int[] arr)
		{
			// Naive approach
			int count = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = i + 1; j < arr.Length; j++)
				{
					if (arr[i] > arr[j]) count++;
				}
			}

			return count;
		}

		public int Count2(int[] arr)
		{
			return CountHelper(arr, 0, arr.Length - 1);
		}

		int CountHelper(int[] arr, int first, int last)
		{
			int count = 0;
			if (first < last)
			{
				var mid = (int)Math.Floor((first + last) / 2.0);
				count = CountHelper(arr, 0, mid);
				count += CountHelper(arr, mid + 1, last);

				// What happens here?
				count += Merge(arr, first, mid, last);
			}

			return count;
		}

		int Merge(int[] arr, int left, int mid, int right)
		{
			int i = left;
			int j = mid + 1;

			int[] temp = new int[(right - left) + 1];
			int write_index = 0; // index in tmp!

			int count = 0;

			while (i <= mid && j <= right)
			{
				if (arr[i] < arr[j])
				{
					temp[write_index] = arr[i];
					i++;
				}
				else
				{
					temp[write_index] = arr[j];
					j++;
					count += (mid - i);
				}

				write_index++;
			}

			// Copy remaining elements from left array
			while (i <= mid)
			{
				temp[write_index] = arr[i];
				write_index++;
				i++;
			}

			// Do the same for right array
			while (j <= right)
			{
				temp[write_index] = arr[j];
				write_index++;
				j++;
			}

			// Copy from temp to arr!
			write_index--;
			while (write_index >= 0)
			{
				arr[left + write_index] = temp[write_index];
				write_index--;
			}

			return count;
		}
	}

	[TestFixture]
	public class TestCountInversionPairs
	{
		[Test]
		public void Test1()
		{
			var sut = new CountInversionPairs();
			var result = sut.Count(new int[] { 7, 5, 6, 4 });

			Assert.That(result == 5);
		}

		[Test]
		public void Test2()
		{
			var sut = new CountInversionPairs();
			var result = sut.Count(new int[] { -1, 6, 3, 3, 7, 4 });

			Assert.That(result == 4);
		}

		[Test]
		public void Test3()
		{
			var sut = new CountInversionPairs();
			var result = sut.Count(new int[] { -1, 2 });

			Assert.That(result == 0);
		}

		[Test]
		public void Test4()
		{
			var sut = new CountInversionPairs();
			var result = sut.Count(new int[] { 11 });

			Assert.That(result == 0);
		}

		[Test]
		public void Test5()
		{
			var sut = new CountInversionPairs();
			var arr = new int[] { -1, 6, 3, 3, 7, 4 };
			var result = sut.Count2(arr);

			Assert.That(result == 4);
		}

		[Test]
		public void Test6()
		{
			var sut = new CountInversionPairs();
			var arr = new int[] { 7, 5, 6, 4 };
			var result = sut.Count2(arr);

			Assert.That(result == 5);
		}
	}
}
