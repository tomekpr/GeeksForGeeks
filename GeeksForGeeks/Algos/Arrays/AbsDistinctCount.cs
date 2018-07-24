using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Arrays
{
	class AbsDistinctCount
	{
		public int Count(int[] A)
		{
			var unique = new HashSet<int>();
			foreach(var val in A)
			{
				int v = val;
				if (v < 0) v = -v;

				if (unique.Contains(v) == false) unique.Add(v);
			}

			return unique.Count;
		}
	}

	[TestFixture]
	public class TestAbsDistinctCount
	{
		[Test]
		public void TestCount1()
		{
			int[] arr = new int[] { -5, -3, -1, 0, 3, 6 };
			var sut = new AbsDistinctCount();

			var result = sut.Count(arr);
			Assert.That(result == 5);
		}

		[Test]
		public void TestCount2()
		{
			int[] arr = new int[] { -5 };
			var sut = new AbsDistinctCount();

			var result = sut.Count(arr);
			Assert.That(result == 1);
		}

		[Test]
		public void TestCount3()
		{
			int[] arr = new int[] { -5,-5 };
			var sut = new AbsDistinctCount();

			var result = sut.Count(arr);
			Assert.That(result == 1);
		}
	}
}
