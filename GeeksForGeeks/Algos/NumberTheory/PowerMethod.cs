using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	[TestFixture]
	class PowerMethod
	{
		int Power(int n, int p)
		{
			if (p == 0) return 1;

			int total = n * Power(n, p - 1);
			return total;
		}

		// Better than Power yet slower than Normal
		int Power2(int n, int p)
		{
			if (p < 0) throw new Exception();
			if (p == 0) return 1;

			if(p%2 == 0)
			{
				// even
				return Power2(n, p / 2) * Power2(n, p / 2);
			}
			else
			{
				// odd
				return n * Power2(n, p / 2) * Power2(n, p / 2);
			}
		}

		int Power3(int n, int p)
		{
			if (p < 0) throw new Exception();
			if (p == 0) return 1;

			if (p % 2 == 0)
			{
				// even
				var r = Power3(n, p / 2);
				return r * r;
			}
			else
			{
				// odd
				var r = Power3(n, p / 2);
				return n * r * r;
			}
		}

		[Test]
		public void Test()
		{
			var n = 2;
			var p = 5;

			int exp = (int)Math.Pow(n, p);
			var pm = new PowerMethod();
			var act = pm.Power(n, p);

			Assert.That(act, Is.EqualTo(exp));
		}

		[Test]
		public void Test2()
		{
			var n = 2;
			var p = 10;

			int exp = (int)Math.Pow(n, p);
			var pm = new PowerMethod();
			var act = pm.Power2(n, p);

			Assert.That(act, Is.EqualTo(exp));
		}

		[Test]
		public void Test3()
		{
			var n = 2;
			var p = 10;

			int exp = (int)Math.Pow(n, p);
			var pm = new PowerMethod();
			var act = pm.Power3(n, p);

			Assert.That(act, Is.EqualTo(exp));
		}
	}
}
