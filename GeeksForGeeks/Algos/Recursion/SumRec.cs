using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	[TestFixture]
	class SumRec
	{
		// sum(6) = 6 + sum(5) = 6 + 5 + sum(4) = 6 + 5 + 4 + sum(3)....

		int Sum(int n)
		{
			if (n <= 0) return 0;

			int total = n + Sum(n - 1);
			return total;
		}

		[Test]
		public void Test1()
		{
			var sumRec = new SumRec();
			var result = sumRec.Sum(6);

			var expected = (6 * (6 + 1)) / 2;
			Console.WriteLine($"Exp: {expected}");
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void Test2()
		{
			int n = 253;

			var sumRec = new SumRec();
			var result = sumRec.Sum(n);

			var expected = (n * (n + 1)) / 2;
			Console.WriteLine($"Exp: {expected}");
			Assert.That(result, Is.EqualTo(expected));
		}
	}
}
