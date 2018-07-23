using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class SieveOfErathothenes
	{
		// https://www.geeksforgeeks.org/sieve-of-eratosthenes/
		public List<int> FindPrimes(int n)
		{
			int upper = Math.Min(100, n);
			var table = Enumerable.Range(0, upper).ToArray();
			for (int i = 2; i < upper; i++)
			{
				if (i == 2 || i == 3)
				{
					CrossOut(i + i, i, table);
					continue;
				}

				if (table[i] == -1) continue;

				if (IsPrime(i)) CrossOut(i + i, i, table);
			}

			var result = new List<int>();
			foreach (var k in table)
			{
				if (k > 1 && k != -1 && k < n) result.Add(k);
			}

			return result;
		}

		void CrossOut(int start, int inc, int[] t)
		{
			for (int k = start; k < t.Length; k += inc)
				t[k] = -1;
		}

		bool IsPrime(int i)
		{
			var divCount = 2;

			for (int k = 2; k < i; k++)
			{
				if (i % k == 0)
				{
					if (divCount++ > 3) return false;
				}
			}

			return true;
		}
	}

	[TestFixture]
	public class TestSieveOfErasthothenes
	{
		[Test]
		public void Test1()
		{
			var se = new SieveOfErathothenes();
			var result = se.FindPrimes(10);

			var expected = new int[] { 2, 3, 5, 7 };
			Console.WriteLine($"Result is: {string.Join(",", result)}");
			Assert.That(result.SequenceEqual(expected), Is.True);
		}

		[Test]
		public void Test2()
		{
			var se = new SieveOfErathothenes();
			var result = se.FindPrimes(20);

			var expected = new int[] { 2, 3, 5, 7, 11, 13, 17, 19 };
			Console.WriteLine($"Result is: {string.Join(",", result)}");
			Assert.That(result.SequenceEqual(expected), Is.True);
		}
	}
}
