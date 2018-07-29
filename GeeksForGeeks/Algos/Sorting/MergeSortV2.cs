using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks.Algos.Sorting
{
	class MergeSortV2
	{
		public void MergeSort(int[] arr)
		{
			MergeSortHelper(arr, 0, arr.Length - 1);
		}

		void MergeSortHelper(int[] arr, int left, int right)
		{
			if (left < right)
			{
				int mid = (int)Math.Floor((left + right) / 2.0);
				MergeSortHelper(arr, left, mid);
				MergeSortHelper(arr, mid + 1, right);

				MergeArrays(arr, left, mid, right);
			}
		}

		void MergeArrays(int[] arr, int left, int mid, int right)
		{
			int length = (right - left) + 1;
			int[] tmp = new int[length];

			int write_index = 0;
			int index_in_lower_half = left;
			int index_in_upper_half = mid + 1;

			while (index_in_lower_half <= mid && index_in_upper_half <= right)
			{
				var a = arr[index_in_lower_half];
				var b = arr[index_in_upper_half];

				if (a < b)
				{
					tmp[write_index] = a;
					index_in_lower_half++;
				}
				else
				{
					tmp[write_index] = b;
					index_in_upper_half++;
				}

				write_index++;
			}

			while (index_in_lower_half <= mid)
			{
				tmp[write_index] = arr[index_in_lower_half];
				write_index++;
				index_in_lower_half++;
			}

			while (index_in_upper_half <= right)
			{
				tmp[write_index] = arr[index_in_upper_half];
				write_index++;
				index_in_upper_half++;
			}

			write_index--;
			while(write_index >= 0)
			{
				arr[left + write_index] = tmp[write_index];
				write_index--;
			}
		}
	}

	[TestFixture]
	public class TestMergeSortV2
	{
		[Test]
		public void Test0()
		{
			int[] arr = new int[] { 3, 1 };

			int[] exp = new List<int>(arr).ToArray();
			Array.Sort(exp);

			var ms = new MergeSortV2();
			ms.MergeSort(arr);

			bool areEqual = arr.SequenceEqual(exp);
			Assert.That(areEqual, Is.True);
		}

		[Test]
		public void Test1()
		{
			int[] arr = new int[] { 3, 1, 2 };

			int[] exp = new List<int>(arr).ToArray();
			Array.Sort(exp);

			var ms = new MergeSortV2();
			ms.MergeSort(arr);

			bool areEqual = arr.SequenceEqual(exp);
			Assert.That(areEqual, Is.True);
		}

		[Test]
		public void Test2()
		{
			int[] arr = new int[] { 9, 3, 7, 5, 6, 4, 8, 2 };

			int[] exp = new List<int>(arr).ToArray();
			Array.Sort(exp);

			var ms = new MergeSortV2();
			ms.MergeSort(arr);

			bool areEqual = arr.SequenceEqual(exp);
			Assert.That(areEqual, Is.True);
		}

		[Test]
		public void Test3()
		{
			var arr = new int[] { 4, 2, 9, 5, 8, 16 };
			var ms = new MergeSortV2();
			ms.MergeSort(arr);

			var copy = new int[arr.Length];
			Array.Copy(arr, copy, arr.Length);
			Array.Sort(copy);

			Assert.That(arr.SequenceEqual(copy), Is.True);
		}
	}
}
