using GeeksForGeeks.AlgoUtils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Sorting
{
	//https://www.youtube.com/watch?v=PgBzjlCcFvc
	class QuickSort
	{
		public void Sort(int[] arr)
		{
			SortHelper(arr, 0, arr.Length - 1);
		}

		void SortHelper(int[] arr, int low, int high)
		{
			if(low < high)
			{
				int j = Partition(low, high, arr);
				SortHelper(arr, low, j);
				SortHelper(arr, j + 1, high);
			}
		}

		int Partition(int low, int high, int[] arr)
		{
			int pivot = arr[low];
			int i = low;
			int j = high;

			while (i < j)
			{
				do
				{
					i++;
				} while (i < j && pivot >= arr[i]);

				do
				{
					j--;
				} while (j >= 0 && pivot < arr[j]);

				if (i <= j)
					Collections.Swap(arr, i, j);
			}

			Collections.Swap(arr, low, j);
			return j;
		}
	}

	[TestFixture]
	public class TestQuickSortV2
	{
		[Test]
		public void Test0()
		{
			int[] arr = new int[] { 3, 1 };

			int[] exp = new List<int>(arr).ToArray();
			Array.Sort(exp);

			var ms = new QuickSort();
			ms.Sort(arr);

			bool areEqual = arr.SequenceEqual(exp);
			Assert.That(areEqual, Is.True);
		}

		[Test]
		public void Test1()
		{
			int[] arr = new int[] { 3, 1, 2 };

			int[] exp = new List<int>(arr).ToArray();
			Array.Sort(exp);

			var ms = new QuickSort();
			ms.Sort(arr);

			bool areEqual = arr.SequenceEqual(exp);
			Assert.That(areEqual, Is.True);
		}

		[Test]
		public void Test2()
		{
			int[] arr = new int[] { 9, 3, 7, 5, 6, 4, 8, 2 };

			int[] exp = new List<int>(arr).ToArray();
			Array.Sort(exp);

			var ms = new QuickSort();
			ms.Sort(arr);

			bool areEqual = arr.SequenceEqual(exp);
			Assert.That(areEqual, Is.True);
		}

		[Test]
		public void Test3()
		{
			var arr = new int[] { 4, 2, 9, 5, 8, 16 };
			var ms = new QuickSort();
			ms.Sort(arr);

			var copy = new int[arr.Length];
			Array.Copy(arr, copy, arr.Length);
			Array.Sort(copy);

			Assert.That(arr.SequenceEqual(copy), Is.True);
		}
	}
}
