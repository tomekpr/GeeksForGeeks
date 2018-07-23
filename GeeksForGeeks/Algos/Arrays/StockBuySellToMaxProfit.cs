using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class StockBuySellToMaxProfit
	{
		// https://www.geeksforgeeks.org/stock-buy-sell/
		public int BuyAndSell(int[] dailyPrices)
		{
			int buy = dailyPrices[0];
			int totalProfit = 0;
			int profitSoFar = 0;
			int day = 1;

			while (day < dailyPrices.Length)
			{
				if (dailyPrices[day] >= dailyPrices[day - 1])
				{
					profitSoFar = Math.Max(profitSoFar, dailyPrices[day] - buy);
					day++;
				}
				else
				{
					// sell
					totalProfit += profitSoFar;
					// buy
					buy = dailyPrices[day];
					profitSoFar = 0;
					day++;
				}
			}

			profitSoFar = Math.Max(profitSoFar, dailyPrices[day - 1] - buy);
			return totalProfit + profitSoFar;
		}
	}

	[TestFixture]
	public class TestStockBuySellToMaxProfit
	{
		[Test]
		public void Test1()
		{
			var bs = new StockBuySellToMaxProfit();
			int totalProfit = bs.BuyAndSell(new int[] { 100, 180, 260, 310, 40, 535, 695 });
			Assert.That(totalProfit, Is.EqualTo(865));
		}

		[Test]
		public void Test2()
		{
			var bs = new StockBuySellToMaxProfit();
			int totalProfit = bs.BuyAndSell(new int[] { 4, 3, 2 });
			Assert.That(totalProfit, Is.EqualTo(0));
		}

		[Test]
		public void Test3()
		{
			var bs = new StockBuySellToMaxProfit();
			int totalProfit = bs.BuyAndSell(new int[] { 1, 1, 1000, 1, 1, 100000 });
			Assert.That(totalProfit, Is.EqualTo(100998));
		}
	}
}
