using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Arrays
{
	// tag:codility
	class CountDistinctSlices
	{
		public int CountSlices(int[] arr)
		{
			int count = 0;
			var slice = new HashSet<int>();
			for(int from = 0; from < arr.Length; from++)
			{
				count++;
				slice.Add(arr[from]);
				for(int to = from+1; to < arr.Length; to++)
				{
					if (slice.Contains(arr[to])) break;
					slice.Add(arr[to]);
					count++;
				}

				slice.Clear();
			}

			return count;
		}
	}

	[TestFixture]
	public class TestCountDistinctSlices
	{
		[Test]
		public void Test1()
		{
			int[] arr = new int[] { 3, 4, 5, 5, 2 };
			var sut = new CountDistinctSlices();
			var result = sut.CountSlices(arr);

			Assert.That(result == 9);
		}

		[Test]
		public void Test2()
		{
			int[] arr = new int[] { 1 };
			var sut = new CountDistinctSlices();
			var result = sut.CountSlices(arr);

			Assert.That(result == 1);
		}
	}
}
