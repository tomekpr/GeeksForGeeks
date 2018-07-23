using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class CountTriplets
	{
		public int Count(int[] arr, int sum)
		{
			var result = new HashSet<Tuple<int, int, int>>();
			for (int i = 1; i < arr.Length; i++)
			{
				var a = arr[i - 1];
				var b = arr[i];
				var x = sum - (a + b);

				for (int j = 0; j < arr.Length; j++)
				{
					if (arr[j] == a || arr[j] == b) continue;

					if (arr[j] < x)
					{
						var tmp = new int[] { a, b, arr[j] };
						Array.Sort(tmp);

						var tuple = new Tuple<int, int, int>(tmp[0], tmp[1], tmp[2]);
						if (result.Contains(tuple) == false)
							result.Add(tuple);
					}
				}
			}

			return result.Count;
		}
	}

	[TestFixture]
	public class TestCountTriplets
	{
		[Test]
		public void Test()
		{
			var ct = new CountTriplets();
			var result = ct.Count(new int[] { -2, 0, 1, 3 }, 2);

			Assert.That(result, Is.EqualTo(2));
		}

		[Test]
		public void Test2()
		{
			var ct = new CountTriplets();
			var result = ct.Count(new int[] { 5, 1, 3, 4, 7 }, 12);

			Assert.That(result, Is.EqualTo(4));
		}
	}
}
