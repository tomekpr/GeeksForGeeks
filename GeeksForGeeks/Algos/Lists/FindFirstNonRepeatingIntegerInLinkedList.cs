using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System.Collections.Generic;

namespace GeeksForGeeks.Algos.Lists
{
	class FindFirstNonRepeatingIntegerInLinkedList
	{
		// https://www.youtube.com/watch?v=lnA26dsi3IU
		public int? firstNonRepeating(SNode node)
		{
			var elemToCount = new Dictionary<int, int>();
			var it = node;
			while (it != null)
			{
				if (elemToCount.ContainsKey(it.Value))
				{
					var count = elemToCount[it.Value];
					count++;
					elemToCount[it.Value] = count;
				}
				else
				{
					elemToCount.Add(it.Value, 1);
				}

				it = it.Next;
			}

			it = node;
			while(it != null)
			{
				if (elemToCount[it.Value] == 1)
					return it.Value;

				it = it.Next;
			}


			return null;
		}
	}

	[TestFixture]
	public class TestFindFirstNonRepeatingCharacter
	{
		[Test]
		public void Test1()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 10, 20, 30, 10, 20, 40, 30 });
			var finder = new FindFirstNonRepeatingIntegerInLinkedList();

			Assert.That(finder.firstNonRepeating(list), Is.EqualTo(40));
		}

		[Test]
		public void Test2()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 1,1,2,2,3,4,3,4 });
			var finder = new FindFirstNonRepeatingIntegerInLinkedList();

			Assert.That(finder.firstNonRepeating(list), Is.Null);
		}
	}
}
