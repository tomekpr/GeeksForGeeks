using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeeksForGeeks.Algos.NumberTheory
{
    class RandomUsingOtherRandom
    {
		public int Rand7()
		{
			var random = new Random();
			while(true)
			{
				int r1 = 2 * random.Next(4); // [0,2,6,8] - full spectrum
				int r2 = random.Next(4); // just to extend the spectrum by at most 1

				if(r2 != 4) // we don't like 4
				{
					// Gen 0 or 1
					int rand = r2 % 2;

					// Bump
					int result = r1 + rand; // [0..9]

					// Cap max value according to definition of rand7()
					if (result < 7)
						return result;
				}
			}
		}
    }

	[TestFixture]
	public class TestRandomUsingOtherRandom
	{
		[Test, Repeat(10)]
		public void Test1()
		{
			var r1 = new RandomUsingOtherRandom();
			var next = r1.Rand7();

			Assert.That(next, Is.AtLeast(0));
			Assert.That(next, Is.AtMost(6));
		}
	}
}
