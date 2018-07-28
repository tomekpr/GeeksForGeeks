using NUnit.Framework;

namespace GeeksForGeeks
{
	class FibonacciSeriesImpl
	{
		public static long FibRec(int n)
		{
			if (n == 1 || n == 2) return 1;

			return FibRec(n - 1) + FibRec(n - 2);
		}

		public static long FibIt(int n)
		{
			if (n == 1 || n == 2) return 1;

			long[] fib = new long[n+1];
			fib[1] = fib[2] = 1;

			for(int i=3; i <= n; i++)
			{
				long result = fib[i - 1] + fib[i - 2];
				fib[i] = result;
			}

			return fib[n];
		}
	}

	[TestFixture]
	public class TestFibonnaciSeriesImpl
	{
		[TestCase(1, 1)]
		[TestCase(2, 1)]
		[TestCase(3, 2)]
		[TestCase(4, 3)]
		[TestCase(5, 5)]
		[TestCase(6, 8)]
		[TestCase(20, 6765)]
		[TestCase(30, 832040)]
		[TestCase(40, 102334155)]
		//[TestCase(80, 23416728348467685)]
		public void TestRec(int n, long expected)
		{
			var result = FibonacciSeriesImpl.FibRec(n);
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(1, 1)]
		[TestCase(2, 1)]
		[TestCase(3, 2)]
		[TestCase(4, 3)]
		[TestCase(5, 5)]
		[TestCase(6, 8)]
		[TestCase(20, 6765)]
		[TestCase(30, 832040)]
		[TestCase(40, 102334155)]
		//[TestCase(80, 23416728348467685)]
		public void TestIt(int n, long expected)
		{
			var result = FibonacciSeriesImpl.FibIt(n);
			Assert.That(result, Is.EqualTo(expected));
		}
	}
}
