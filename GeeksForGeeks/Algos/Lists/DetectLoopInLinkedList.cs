using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Lists
{
	public class DetectLoopInLinkedList
	{
		public bool HasLoop(SNode node)
		{
			var slow = node;
			var fast = node;

			while(slow != null && fast != null && fast.Next != null)
			{
				slow = slow.Next;
				fast = fast.Next.Next;

				if (slow.Value == fast?.Value) return true;
			}

			return false;
		}
	}

	[TestFixture]
	public class TestDetectLoopInLinkedList
	{
		[Test]
		public void Test1()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 1, 2, 3, 4, 5 });
			var last = AlgoUtilities.Utilities.FindLastNode(list);

			// Create a loop
			last.Next = list.Next;

			var sut = new DetectLoopInLinkedList();
			var result = sut.HasLoop(list);

			Assert.IsTrue(result);
		}

		[Test]
		public void Test2()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 1, 2, 3, 4, 5 });

			var sut = new DetectLoopInLinkedList();
			var result = sut.HasLoop(list);

			Assert.IsFalse(result);
		}

		[Test]
		public void Test3()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 1, 2});

			var sut = new DetectLoopInLinkedList();
			var result = sut.HasLoop(list);

			Assert.IsFalse(result);
		}

		[Test]
		public void Test4()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 1 });

			var sut = new DetectLoopInLinkedList();
			var result = sut.HasLoop(list);

			Assert.IsFalse(result);
		}
	}
}
