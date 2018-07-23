using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	[TestFixture]
	class MergeSort
	{
		public void Sort(int[] arr)
		{
			var left = 0;
			var right = arr.Length - 1;

			Sort(arr, left, right);
		}

		void Sort(int[] arr, int left, int right)
		{
			if (left == right) return;

			int mid = (int)Math.Floor((left + right) / 2.0);

			Sort(arr, left, mid);
			Sort(arr, mid + 1, right);
			Merge(arr, left, mid, right);
		}

		void Merge(int[] arr, int left, int mid, int right)
		{
			var width = (right + 1 - left);
			var temp = new int[width];

			var index_in_lower_half = left;
			var index_in_upper_half = mid + 1;

			var write_index = 0;

			while (index_in_lower_half <= mid && index_in_upper_half <= right)
			{
				var a = arr[index_in_lower_half];
				var b = arr[index_in_upper_half];

				if (a < b)
				{
					temp[write_index] = a;
					index_in_lower_half++;
				}
				else
				{
					temp[write_index] = b;
					index_in_upper_half++;
				}

				write_index++;
			}

			// insert any trailing elements from lower half
			while (index_in_lower_half <= mid)
			{
				temp[write_index] = arr[index_in_lower_half];
				index_in_lower_half++;
				write_index++;
			}

			// insert any trailing elements from upper half
			while (index_in_upper_half <= right)
			{
				temp[write_index] = arr[index_in_upper_half];
				index_in_upper_half++;
				write_index++;
			}

			// write back temp array to the original input array
			write_index -= 1;
			while (write_index >= 0)
			{
				arr[left + write_index] = temp[write_index];
				write_index--;
			}
		}

		[Test]
		public void Test1()
		{
			var arr = new int[] { 4, 2, 9, 5, 8, 16 };
			Sort(arr);

			var copy = new int[arr.Length];
			Array.Copy(arr, copy, arr.Length);
			Array.Sort(copy);

			Assert.That(arr.SequenceEqual(copy), Is.True);
		}

		[Test]
		public void Test2()
		{
			int[] arr = new int[] { 9, 3, 7, 5, 6, 4, 8, 2 };

			int[] exp = new List<int>(arr).ToArray();
			Array.Sort(exp);

			Sort(arr);

			bool areEqual = arr.SequenceEqual(exp);
			Assert.That(areEqual, Is.True);
		}
	}
}
