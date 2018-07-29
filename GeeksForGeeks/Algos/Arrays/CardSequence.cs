using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeeksForGeeks.Algos.Arrays
{
	// A variation of this https://codesays.com/2014/solution-to-continuous-cards-from-jobdu/
	class CardSequence
	{
		public bool Check(int[] cards)
		{
			Array.Sort(cards);
			int jokerCount = cards.Count(x => x == 0);

			for (int i = 1; i < cards.Length; i++)
			{
				int diff = cards[i] - cards[i - 1];
				if (diff != 1)
				{
					if (jokerCount > 0) jokerCount--;
					else return false;
				}
			}

			return true;
		}
	}

	[TestFixture]
	public class TestCardSequence
	{
		[Test]
		public void Test1()
		{
			var sut = new CardSequence();
			var result = sut.Check(new int[] { 3, 5, 4, 7, 6 });

			Assert.IsTrue(result);
		}

		[Test]
		public void Test2()
		{
			var sut = new CardSequence();
			var result = sut.Check(new int[] { 3, 5, 7, 4, 8 });

			Assert.IsFalse(result);
		}

		[Test]
		public void Test3()
		{
			var sut = new CardSequence();
			var result = sut.Check(new int[] { 3, 5, 1, 0, 4 });

			Assert.IsTrue(result);
		}
	}
}
