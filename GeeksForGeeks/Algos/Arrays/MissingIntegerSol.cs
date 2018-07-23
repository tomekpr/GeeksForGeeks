using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class MissingIntegerSol
	{
		public int Sol(int[] A)
		{
			int max = Int32.MinValue;
			var numSet = new HashSet<int>();
			foreach (var n in A)
			{
				if (numSet.Contains(n) == false)
				{
					numSet.Add(n);
					max = Math.Max(max, n);
				}
			}

			for (int i = 1; i <= max; i++)
				if (numSet.Contains(i) == false) return i;

			return max <= 0 ? 1 : max + 1;
		}

		[TestFixture]
		public class TestMissingIntegerSol
		{
			MissingIntegerSol sol = new MissingIntegerSol();

			[Test]
			public void Test1()
			{
				var result = sol.Sol(new int[] { 1, 3, 6, 4, 1, 2 });
				Assert.That(result == 5);
			}

			[Test]
			public void Test2()
			{
				var result = sol.Sol(new int[] { 1,2,3 });
				Assert.That(result == 4);
			}

			[Test]
			public void Test3()
			{
				var result = sol.Sol(new int[] { -1,-3 });
				Assert.That(result == 1);
			}

		}
	}
}