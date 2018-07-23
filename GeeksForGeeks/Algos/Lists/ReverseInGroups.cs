using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Lists
{
	class ReverseInGroups
	{
		public void ReverseInPlace(ref SNode node, int k)
		{
			var headToResult = new SNode();
			var prev = headToResult;

			var visitor = node;
			while(visitor != null)
			{
				var head = visitor;
				int i = 0;
				while(i < k-1 && visitor != null)
				{
					visitor = visitor.Next;
					i++;
				}

				var tail = visitor;
				if(visitor != null)
				{
					visitor = visitor.Next;
					tail.Next = null;
				}

				head = new ReverseSingleLinkedList().Reverse(head);
				prev.Next = head;
				prev = FindTail(head);
			}

			node = headToResult.Next;
		}

		public void Reverse(ref SNode node, int k)
		{
			var splitLists = new List<SNode>();
			var nodeCount = CountNodes(node);

			int finalListCount = (int)Math.Ceiling((decimal)nodeCount / k);
			int i = 0;

			SNode nextList = node;
			while (i < finalListCount)
			{
				SNode head = nextList;
				SNode it = head;

				int m = 0;
				while (m < k - 1 && it != null)
				{
					it = it.Next;
					m++;
				}

				if (it != null)
				{
					nextList = it.Next;
					it.Next = null;
				}

				splitLists.Add(head);
				i++;
			}

			var reversedLists = new List<SNode>();
			foreach (var list in splitLists)
			{
				var rlist = new ReverseSingleLinkedList().Reverse(list);
				reversedLists.Add(rlist);
			}

			node = Merge(reversedLists);
		}

		SNode Merge(List<SNode> reversedLists)
		{
			var head = reversedLists[0];
			for (int i = 1; i < reversedLists.Count; i++)
			{
				var tail = FindTail(reversedLists[i - 1]);
				tail.Next = reversedLists[i];
			}

			return head;
		}

		SNode FindTail(SNode list)
		{
			var it = list;
			var prev = it;

			while (it != null)
			{
				prev = it;
				it = it.Next;
			}

			return prev;
		}

		int CountNodes(SNode n)
		{
			int count = 0;
			while (n != null)
			{
				count++;
				n = n.Next;
			}

			return count;
		}
	}

	[TestFixture]
	public class TestListReverseInGroups
	{
		[Test]
		public void Test1()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(Enumerable.Range(1, 8).ToList());

			var expected = new int[] { 3, 2, 1, 6, 5, 4, 8, 7 }.ToList();

			var testReversal = new ReverseInGroups();
			testReversal.Reverse(ref list, 3);

			var actual = AlgoUtilities.Utilities.ToList(list);
			bool areListsEqual = actual.SequenceEqual(expected);

			Assert.That(areListsEqual, Is.True);
		}

		[Test]
		public void Test2()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(Enumerable.Range(1, 8).ToList());

			var expected = new int[] { 5, 4, 3, 2, 1, 8, 7, 6 }.ToList();

			var testReversal = new ReverseInGroups();
			testReversal.Reverse(ref list, 5);

			var actual = AlgoUtilities.Utilities.ToList(list);
			bool areListsEqual = actual.SequenceEqual(expected);

			Assert.That(areListsEqual, Is.True);
		}

		[Test]
		public void Test3()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(Enumerable.Range(1, 8).ToList());

			var expected = new int[] { 3, 2, 1, 6, 5, 4, 8, 7 }.ToList();

			var testReversal = new ReverseInGroups();
			testReversal.ReverseInPlace(ref list, 3);

			var actual = AlgoUtilities.Utilities.ToList(list);
			bool areListsEqual = actual.SequenceEqual(expected);

			Assert.That(areListsEqual, Is.True);
		}

		[Test]
		public void Test4()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(Enumerable.Range(1, 8).ToList());

			var expected = new int[] { 5, 4, 3, 2, 1, 8, 7, 6 }.ToList();

			var testReversal = new ReverseInGroups();
			testReversal.ReverseInPlace(ref list, 5);

			var actual = AlgoUtilities.Utilities.ToList(list);
			bool areListsEqual = actual.SequenceEqual(expected);

			Assert.That(areListsEqual, Is.True);
		}
	}
}
