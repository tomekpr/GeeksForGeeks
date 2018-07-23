using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	[TestFixture]
	class SummaryRangesImpl
	{
		List<string> SummaryRanges(int[] arr)
		{
			var ranges = new SortedDictionary<int, int?>();
			int prev = 0, currentRange = 0;

			foreach (var n in arr)
			{
				if (prev + 1 == n && ranges.ContainsKey(currentRange))
				{
					ranges[currentRange] = n;
					prev = n;
				}
				else
				{
					if (ranges.ContainsKey(n) == false)
					{
						ranges[n] = null;
						prev = n;
						currentRange = n;
					}
					else
					{
						ranges[n] = null;
						prev = n;
						currentRange = n;
					}
				}
			}

			var result = new List<string>();
			foreach (var kvp in ranges)
			{
				var s = $"{kvp.Key}";
				if (kvp.Value.HasValue)
					s = $"{s}->{kvp.Value}";

				result.Add(s);
			}

			return result;
		}

		[Test]
		public void Test1()
		{
			int[] arr = new int[] { 0, 1, 2, 4, 5, 7 };
			var r = SummaryRanges(arr);

			Assert.That(r.SequenceEqual(new[] { "0->2", "4->5", "7" }), Is.True);
		}

		[Test]
		public void Test2()
		{
			int[] arr = new int[] { 0, 2, 3, 4, 6, 8, 9 };
			var r = SummaryRanges(arr);

			Assert.That(r.SequenceEqual(new[] { "0", "2->4", "6", "8->9" }), Is.True);
		}

		[Test]
		public void Test3()
		{
			int[] arr = new int[] { 1 };
			var r = SummaryRanges(arr);

			Assert.That(r.SequenceEqual(new[] { "1" }), Is.True);
		}

		[Test]
		public void Test4()
		{
			int[] arr = new int[] { -2, -1, 1, 2, 2147483646, 2147483647 };
			var r = SummaryRanges(arr);

			Assert.That(r.SequenceEqual(new[] { "-2->-1", "1->2", "2147483646->2147483647" }), Is.True);
		}
	}
}
