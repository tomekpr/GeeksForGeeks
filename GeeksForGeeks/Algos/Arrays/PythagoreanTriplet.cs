using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	// https://www.geeksforgeeks.org/find-pythagorean-triplet-in-an-unsorted-array/ <- can be done in 0(n^2)
	class PythagoreanTriplet
	{
		public bool HasTriplet(int[] arr)
		{
			if (arr.Length < 3) return false;
			Array.Sort(arr);

			for(int i=1; i < arr.Length;i++)
			{
				var a = arr[i - 1];
				var b = arr[i];
				var c = Math.Sqrt(a * a + b * b);

				for(int j=0; j < arr.Length; j++)
				{
					if (arr[j] == a || arr[j] == b) continue;
					if (arr[j] == c) return true;
				}
			}

			return false;
		}
	}

	[TestFixture]
	public class TestPythagoreanTriplet
	{
		[Test]
		public void Test1()
		{
			var pt = new PythagoreanTriplet();
			Assert.IsTrue(pt.HasTriplet(new int[] { 3, 1, 4, 6, 5 }));
		}

		[Test]
		public void Test2()
		{
			var pt = new PythagoreanTriplet();
			Assert.IsFalse(pt.HasTriplet(new int[] { 10, 4, 6, 12, 5 }));
		}

		// unrelated
		[Test]
		public void Test3()
		{
			double c = 8.0;
			double d = (int)c;
			var diff = c - d;

			if (diff != 0)
				Console.WriteLine("Has fraction");
			else
				Console.WriteLine("No fraction");
		}
	}
}
