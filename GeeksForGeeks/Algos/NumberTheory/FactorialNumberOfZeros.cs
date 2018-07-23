using NUnit.Framework;
using System;

namespace GeeksForGeeks.Algos.NumberTheory
{
	// Kudos to: http://www.purplemath.com/modules/factzero.htm
	class FactorialNumberOfZeros
	{
		public int CountZeros(int n)
		{
			if (n < 5) return 0;

			int count = 0;
			for(int i=1; i < 10; i++) // how far do we go?!
			{
				var factor = Math.Pow(5, i);
				if (n / factor < 1.0) break;

				count += (n / (int)factor);
			}

			return count;
		}

		// doesn't cover all multiplies of 5
		public int CountZerosStepByStep(int n)
		{
			if (n < 5) return 0;
			int count = 0;
			int sum = 5;

			while (sum <= n)
			{
				count++;
				sum += 5;

				if (sum <= n)
				{
					// 25 == 5 x 5
					// 50 == 5 x 5 x 5 x 5
					if (sum % 25 == 0) count++;
					if (sum % 125 == 0) count++;
					if (sum % 625 == 0) count++;
				}
			}

			return count;
		}
	}

	[TestFixture]
	public class TestFactorialNumberOfZeros
	{
		[TestCase(14, 2)]
		[TestCase(17, 3)]
		[TestCase(24, 4)]
		[TestCase(25, 6)]
		[TestCase(101, 24)]
		[TestCase(1000, 249)]
		public void Test1(int n, int exp)
		{
			var sut = new FactorialNumberOfZeros();
			var result = sut.CountZeros(n);

			Assert.That(result, Is.EqualTo(exp));
		}
	}
}
