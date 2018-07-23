using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class ModularExponentiation
	{
		// https://www.geeksforgeeks.org/modular-exponentiation-power-in-modular-arithmetic/
		public int Calc(int x,int y, int p)
		{
			int power = Power(x, y);
			return power % p;
		}

		public int Power(int x, int y)
		{
			if (y == 0) return 1;
			if (y == 1) return x;

			int square = x * x;
			int prevOdd = 1;
			int prevEven = square;

			int result = 1;
			for(int i=3; i <= y; i++)
			{
				if(i % 2 != 0)
				{
					result = prevEven * x;
					prevOdd = result;
				}
				else
				{
					result = prevEven * square;
					prevEven = result;
				}
			}

			return result;
		}
	}

	[TestFixture]
	public class TestModExp
	{
		[Test]
		public void Test1()
		{
			var me = new ModularExponentiation();
			Assert.That(me.Power(5, 7), Is.EqualTo((int)Math.Pow(5, 7)));
		}

		[Test]
		public void Test2()
		{
			var me = new ModularExponentiation();
			var result = me.Calc(2, 3, 5);

			Assert.That(result, Is.EqualTo(3));
		}

		[Test]
		public void Test3()
		{
			var me = new ModularExponentiation();
			var result = me.Calc(2, 5, 13);

			Assert.That(result, Is.EqualTo(6));
		}
	}
}
