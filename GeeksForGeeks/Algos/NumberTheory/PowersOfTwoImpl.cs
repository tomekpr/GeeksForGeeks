using NUnit.Framework;
using System.Collections.Generic;

namespace GeeksForGeeks
{
	class PowersOfTwoImpl
	{
		public static List<int> PowersOfTwo()
		{
			var results = new List<int>();
			for (int i = 0; i < 31; i++)
			{
				var n = 1 << i;
				results.Add(n);
			}

			return results;
		}
	}

	[TestFixture]
	public class TestPowersOfTwoImpl
	{
		[Test]
		public void Test1()
		{
			var result = PowersOfTwoImpl.PowersOfTwo();
			Assert.That(result.Contains(1));
			Assert.That(result.Contains(2));
			Assert.That(result.Contains(4));
			Assert.That(result.Contains(8));
			Assert.That(result.Contains(16));
			Assert.That(result.Contains(32));
		}
	}
}
