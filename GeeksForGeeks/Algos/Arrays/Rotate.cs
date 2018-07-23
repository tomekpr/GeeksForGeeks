using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Arrays
{
	class RotateArray
	{
		public void Rotate(int[] arr, int i)
		{
			Reverse(arr, 0, arr.Length);
			Reverse(arr, 0, i);
			Reverse(arr, i, arr.Length);
		}

		void Reverse(int[] arr, int start, int end)
		{
			end--;
			for (int i = start; i < end; i++, end--)
			{
				Swap(arr, i, end);
			}
		}

		void Swap(int[] arr, int a, int b)
		{
			var tmp = arr[a];
			arr[a] = arr[b];
			arr[b] = tmp;
		}
	}

	[TestFixture]
	public class TestRotation
	{
		[Test]
		public void Test1()
		{
			var nums = new int[] { 1, 2, 3, 4, 5, 6 };
			int pos = 2;

			var exp = new int[] { 5, 6, 1, 2, 3, 4 };

			new RotateArray().Rotate(nums, pos);
			bool areEqual = nums.SequenceEqual(exp);

			Assert.IsTrue(areEqual);
		}

		[Test]
		public void Test2()
		{
			var nums = new int[] { 3, 4, 5, 6 };
			int pos = 3;

			var exp = new int[] { 4, 5, 6, 3 };

			new RotateArray().Rotate(nums, pos);
			bool areEqual = nums.SequenceEqual(exp);

			Assert.IsTrue(areEqual);
		}
	}
}
