using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	// Euclidian algorithm or Euclid's algorithm:
	// TIME AT MOST O(LOGB)
	class GreatestCommonDivisor
	{
		public static int GCD(int a, int b)
		{
			while(b != 0)
			{
				int reminder = a % b;
				a = b;
				b = reminder;
			}

			return a;
		}
	}

	[TestFixture]
	public class GCDTest
	{
		[Test]
		public void Test1()
		{
			var result = GreatestCommonDivisor.GCD(4851, 3003);
			Assert.That(result, Is.EqualTo(231));
		}
	}
}
