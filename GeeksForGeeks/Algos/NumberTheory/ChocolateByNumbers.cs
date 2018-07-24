using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GeeksForGeeks.Algos.NumberTheory
{
	class ChocolateByNumbers
	{
		public int Solve(int N, int m)
		{
			int count = 0;
			var wrappers = new HashSet<int>();
			int n = 0;

			while(wrappers.Contains(n) == false)
			{
				wrappers.Add(n);

				int next = (n + m) % N;
				count++;

				n = next;
			}

			return count;
		}
	}

	[TestFixture]
	public class TestChocolateByNumbers
	{
		[Test]
		public void Test1()
		{
			var sut = new ChocolateByNumbers();
			var result = sut.Solve(10, 4);

			Assert.That(result == 5);
		}
	}
}
