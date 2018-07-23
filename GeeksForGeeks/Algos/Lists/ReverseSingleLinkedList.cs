using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	// Variant: can you do that in place? Yes, but much slower due to always looking for a tail
	class ReverseSingleLinkedList
	{
		public SNode Reverse(SNode list)
		{
			var stack = new Stack<int>();
			var it = list;
			while(it != null)
			{
				stack.Push(it.Value);
				it = it.Next;
			}

			SNode head = null, tail = null;
			while(stack.Count > 0)
			{
				if(head == null)
				{
					head = new SNode();
					head.Next = new SNode(stack.Pop());

					tail = new SNode();
					tail.Next = head.Next;
				}
				else
				{
					var last = tail.Next;
					var n = new SNode(stack.Pop());

					last.Next = n;
					tail.Next = n;
				}
			}

			return head.Next;
		}
	}
	
	[TestFixture]
	public class TestListReversal
	{
		[Test]
		public void Test1()
		{
			var s1 = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 9, 5, 17, 2 });
			var rev = new ReverseSingleLinkedList();

			var actual = rev.Reverse(s1);
			var actualAsList = AlgoUtilities.Utilities.ToList(actual);

			bool listEquals = actualAsList.SequenceEqual(new int[] { 2, 17, 5, 9 });
			Assert.That(listEquals, Is.True);
		}

		[Test]
		public void Test2()
		{
			var s1 = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 9 });
			var rev = new ReverseSingleLinkedList();

			var actual = rev.Reverse(s1);
			var actualAsList = AlgoUtilities.Utilities.ToList(actual);

			bool listEquals = actualAsList.SequenceEqual(new int[] { 9 });
			Assert.That(listEquals, Is.True);
		}
	}
}
