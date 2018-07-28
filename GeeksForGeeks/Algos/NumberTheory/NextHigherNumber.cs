using GeeksForGeeks.AlgoUtils;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GeeksForGeeks.Algos.NumberTheory
{
	class NextHigherNumber
	{
		public int FindIt(int n)
		{
			int[] digits = ToDigits(n);

			// find d1 and then d2
			int d1 = -1, d2 = -1;
			for(int i=digits.Length-2; i>=0; i--)
			{
				if (digits[i] < digits[i+1])
				{
					d1 = i;
					break;
				}
			}

			// error check
			if (d1 == -1) return -1;

			for (int j = d1 + 1; j < digits.Length; j++)
			{
				if (digits[j] > digits[d1])
				{
					if (d2 == -1) d2 = j;
					else
					{
						if (digits[j] < digits[d2])
							d2 = j;
					}
				}
			}

			Collections.Swap(digits, d1, d2);

			for (int j = d1+1; j < digits.Length; j++)
			{
				for(int k = j+1; k < digits.Length; k++)
				{
					if(digits[j] > digits[k])
					{
						Collections.Swap(digits, j, k);
					}
				}
			}

			return ToNumber(digits);
		}

		int[] ToDigits(int n)
		{
			if (n < 10) return new int[] { n };

			var result = new List<int>();
			while(n != 0)
			{
				result.Insert(0, n % 10);
				n /= 10;
			}

			return result.ToArray();
		}

		int ToNumber(int[] digits)
		{
			int sum = 0;
			int pow = digits.Length - 1;
			for(int n = 0; n < digits.Length; n++)
			{
				sum += (digits[n] * (int)Math.Pow(10, pow--));
			}

			return sum;
		}
	}

	[TestFixture]
	public class TestNextHigherNumber
	{
		[Test]
		public void Test1()
		{
			var sut = new NextHigherNumber();
			var result = sut.FindIt(32841);

			Assert.That(result == 34128);
		}

		[TestCase(1234,1243)]
		[TestCase(4132,4213)]
		[TestCase(4321,-1)]
		[TestCase(32876,36278)]
		[TestCase(32841,34128)]
		public void Test2(int n, int expected)
		{
			var sut = new NextHigherNumber();
			var result = sut.FindIt(n);

			Assert.That(result == expected);
		}
	}
}
