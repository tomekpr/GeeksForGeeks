using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Arrays
{
	// tag: codility
	// url: https://app.codility.com/programmers/lessons/15-caterpillar_method/count_triangles/
	// O(n^3) but apparently I could take it down to O(n^2) with O(n) space.
	class CountTriangles
	{
		public int Count(int[] a)
		{
			// Can I do some sort of quick lookup  to eliminate inner most value?

			int count = 0;
			for (int p = 0; p < a.Length; p++)
			{
				for (int q = p + 1; q < a.Length; q++)
				{
					for (int r = q + 1; r < a.Length; r++)
					{
						var cond1 = a[p] + a[q] > a[r];
						var cond2 = a[q] + a[r] > a[p];
						var cond3 = a[r] + a[p] > a[q];

						if (cond1 && cond2 && cond3)
						{
							Console.WriteLine("Triangle: ({0},{1},{2}) can be build", p, q, r);
							count++;
						}
					}
				}
			}

			return count;
		}
	}

	[TestFixture]
	public class TestCountTriangles
	{
		[Test]
		public void Test1()
		{
			var arr = new int[] { 10, 2, 5, 1, 8, 12 };
			var sut = new CountTriangles();
			var result = sut.Count(arr);

			Assert.That(result == 4);
		}
	}
}
