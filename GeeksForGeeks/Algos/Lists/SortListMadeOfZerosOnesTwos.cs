using GeeksForGeeks.DataStructures;
using NUnit.Framework;

namespace GeeksForGeeks.Algos.Lists
{
	// Assumption: we return new sorted list.

	// Alternative approach:
	// https://www.youtube.com/watch?v=4-3TU2FRs70
	// Involves counting elemenets too but instead of creating a new list, you overwrite elements of existing list.
	class SortListMadeOfZerosOnesTwos
	{
		public SNode Sort(SNode head)
		{
			int[] counts = new int[3];
			var it = head;
			while (it != null)
			{
				counts[it.Value]++;
				it = it.Next;
			}

			SNode result = null;
			for (int k = counts.Length - 1; k >= 0; k--)
			{
				while (counts[k] > 0)
				{
					var n = new SNode(k);
					n.Next = result;
					result = n;
					counts[k]--;
				}
			}

			return result;
		}
	}

	[TestFixture]
	public class TestSortListMadeOfZerosOnesTwos
	{
		[Test]
		public void Test1()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 2, 1, 0, 0, 1 });
			var expList = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 0, 0, 1, 1, 2 });

			var sut = new SortListMadeOfZerosOnesTwos();
			var result = sut.Sort(list);

			var areQual = AlgoUtils.Lists.AreSingleListsEqual(result, expList);

			Assert.That(areQual, Is.True);
		}

		[Test]
		public void Test2()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 2, 1, 2, 1, 1, 2, 0, 1, 0 });
			var expList = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 0, 0, 1, 1, 1, 1, 2, 2, 2 });

			var sut = new SortListMadeOfZerosOnesTwos();
			var result = sut.Sort(list);

			var areQual = AlgoUtils.Lists.AreSingleListsEqual(result, expList);

			Assert.That(areQual, Is.True);
		}
	}
}
