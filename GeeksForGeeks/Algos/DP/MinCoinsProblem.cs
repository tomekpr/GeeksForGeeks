using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class MinCoinsProblem
	{
		public int MinCoinRec(int money, int[] coins)
		{
			if (money == 0) return 0;

			int minNumCoins = int.MaxValue;
			foreach (var coin in coins)
			{
				if (money >= coin)
				{
					int minCoins = MinCoinRec(money - coin, coins);
					if (minCoins + 1 < minNumCoins)
						minNumCoins = minCoins + 1;
				}
			}

			return minNumCoins;
		}

		public int MinCoinChangeDP(int money, int[] coins)
		{
			int[] minChange = new int[money+1]; // 9 cents
			for(int m=1; m <= money; m++)
			{
				minChange[m] = int.MaxValue;
				foreach (var coin in coins)
				{
					if(m >= coin)
					{
						var numCoins = minChange[m - coin] + 1;
						if(numCoins < minChange[m])
						{
							minChange[m] = numCoins;
						}
					}
				}
			}

			return minChange[money];
		}
	}

	[TestFixture]
	public class TestMinCoinsProblem
	{
		[Test]
		public void Test1()
		{
			var minCoins = new MinCoinsProblem();
			var result = minCoins.MinCoinRec(9, new int[] { 6, 5, 1 });

			var result2 = minCoins.MinCoinChangeDP(9, new int[] { 6, 5, 1 });

			Assert.That(result, Is.EqualTo(4));
			Assert.That(result2, Is.EqualTo(4));
		}

		[Test]
		public void Test2()
		{
			var minCoins = new MinCoinsProblem();
			var result = minCoins.MinCoinRec(40, new int[] { 5, 10, 20, 25 });

			var result2 = minCoins.MinCoinChangeDP(40, new int[] { 5, 10, 20, 25 });

			Assert.That(result, Is.EqualTo(2));
			Assert.That(result2, Is.EqualTo(2));
		}

		[Test]
		public void Test3()
		{
			var minCoins = new MinCoinsProblem();

			Stopwatch sw = Stopwatch.StartNew();
			var result = minCoins.MinCoinRec(58, new int[] { 6, 5, 1 });
			sw.Stop();

			Stopwatch sw2 = Stopwatch.StartNew();
			var result2 = minCoins.MinCoinChangeDP(58, new int[] { 6, 5, 1 });
			sw2.Stop();

			Console.WriteLine($"Rec took: {sw.Elapsed.TotalSeconds}");
			Console.WriteLine($"DP took: {sw2.Elapsed.ToString()}");
		}
	}
}
