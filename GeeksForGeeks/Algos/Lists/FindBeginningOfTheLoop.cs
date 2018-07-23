using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System.Collections.Generic;

namespace GeeksForGeeks.Algos.Lists
{
	class FindBeginningOfTheLoop
	{
		public SNode Find(SNode head)
		{
			var slow = head;
			var fast = head;

			while (slow != null && fast.Next != null)
			{
				slow = slow.Next;
				fast = fast.Next.Next;

				if (slow == fast)
					break;
			}

			// Check for potential errors
			if (fast == null || fast.Next == null) return null;

			// they both point at the same node
			slow = head;
			while (slow != fast)
			{
				slow = slow.Next;
				fast = fast.Next;
			}

			// they both now indicate begining of the loop
			return fast;
		}
	}

	[TestFixture]
	public class TestFindBeginningOfTheLoop
	{
		[Test]
		public void Test1()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
			var last = AlgoUtilities.Utilities.FindLastNode(list);

			// Make loop
			last.Next = list.Next.Next.Next;

			var sut = new FindBeginningOfTheLoop();
			var result = sut.Find(list);

			Assert.That(result.Value == 4);
		}
	}
}
