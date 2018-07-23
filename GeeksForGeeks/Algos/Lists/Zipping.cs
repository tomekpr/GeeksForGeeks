using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Lists
{
	class Zipping
	{
		public SNode Zip(SNode list)
		{
			var fast = list;
			var slow = list;

			while(slow != null && fast != null && fast.Next != null)
			{
				slow = slow.Next;
				fast = fast.Next.Next;
			}

			var head1 = list;
			var head2 = slow.Next;

			slow.Next = null; // split lists

			head2 = new ReverseSingleLinkedList().Reverse(head2);

			// Merge head1 and head2
			var it1 = head1;
			var it2 = head2;

			bool useLeft = true;

			SNode result = new SNode();
			SNode tail = new SNode();
			while(it1 != null && it2 != null)
			{
				var nodeToAdd = useLeft ? new SNode(it1.Value) : new SNode(it2.Value);		

				if (result.Next == null)
				{
					result.Next = nodeToAdd;
					tail.Next = result.Next;
				}
				else
				{
					AddToTail(ref tail, nodeToAdd);
				}

				if(useLeft)
					it1 = it1.Next;
				else
					it2 = it2.Next;

				useLeft = !useLeft;
			}

			AddRemainingItems(ref tail, it1);
			AddRemainingItems(ref tail, it2);

			return result.Next;
		}

		void AddRemainingItems(ref SNode tail, SNode node)
		{
			while(node != null)
			{
				AddToTail(ref tail, node);
				node = node.Next;
			}
		}

		void AddToTail(ref SNode tail, SNode it)
		{
			var last = tail.Next;
			last.Next = it;
			tail.Next = it;
		}
	}

	[TestFixture]
	public class TestListZipping
	{
		[Test]
		public void Test1()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 0, 1, 2, 3, 4 });
			var expected = new List<int>() { 0, 4, 1, 3, 2 };

			var zippedList = new Zipping().Zip(list);
			var actual = AlgoUtilities.Utilities.ToList(zippedList);

			bool areListsEqual = actual.SequenceEqual(expected);
			Assert.That(areListsEqual, Is.True);
		}
	}
}
