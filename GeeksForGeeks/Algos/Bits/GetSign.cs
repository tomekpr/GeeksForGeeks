using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeeksForGeeks.Algos.Bits
{
    class GetSign
    {
		// -1 when n < 0
		// +1 when n >= 0
		public int Get(int n)
		{
			// Get sign using bit operations
			// Two complements encoding / notation
			// first bit of a number, if that's 1 then negative, else that's positive.
			int firstBit = n >> 31;
			if ((firstBit & 0x1) == 1) return -1;

			return 1;
		}
    }

	[TestFixture]
	public class TestGetSign
	{
		[TestCase(-10,-1)]
		[TestCase(15,1)]
		[TestCase(0,1)]
		public void Test1(int n, int exp)
		{
			var sut = new GetSign();
			var result = sut.Get(n);

			Assert.That(result == exp);
		}
	}
}
