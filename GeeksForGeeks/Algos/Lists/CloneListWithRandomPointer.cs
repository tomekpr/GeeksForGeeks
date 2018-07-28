using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	// https://www.geeksforgeeks.org/clone-linked-list-next-random-pointer-o1-space/
	class CloneListWithRandomPointer
	{
		public RNode Clone(RNode head)
		{
			if (head == null) return null;

			var cloneHead = new RNode();
			var cloneCurrent = cloneHead;

			var it = head;
			while (it != null)
			{
				// Handle next element
				var existing = Find(cloneHead.Next, it.Value);
				if (existing == null)
				{
					cloneCurrent.Next = new RNode(it.Value);
				}
				else
				{
					cloneCurrent.Next = existing;
				}

				// Handle random element
				if (it.Random == null)
				{
					it = it.Next;
					cloneCurrent = cloneCurrent.Next;
					continue;
				}

				var existingRandom = Find(cloneHead.Next, it.Random.Value);
				if (existingRandom == null)
				{
					cloneCurrent.Next.Random = new RNode(it.Random.Value);
				}
				else
				{
					cloneCurrent.Next.Random = existingRandom;
				}

				// Move along the lists
				cloneCurrent = cloneCurrent.Next;
				it = it.Next;
			}

			return cloneHead.Next;

		}

		RNode Find(RNode cloneHead, int k)
		{
			var it = cloneHead;
			while (it != null)
			{
				if (it.Value == k) return it;
				it = it.Random;
			}

			it = cloneHead;
			while (it != null)
			{
				if (it.Value == k) return it;
				it = it.Next;
			}

			return null;
		}
	}

	[TestFixture]
	public class TestCloneListWithRandomPointer
	{
		[Test]
		public void Test1()
		{
			var n1 = new RNode(1);
			var n2 = new RNode(2);
			var n3 = new RNode(3);
			var n4 = new RNode(4);
			var n5 = new RNode(5);

			n1.Next = n2;
			n1.Random = n3;

			n2.Next = n3;
			n2.Random = n1;

			n3.Next = n4;
			n3.Random = n5;

			n4.Next = n5;
			n4.Random = n5;

			n5.Next = null;
			n5.Random = n2;

			var sut = new CloneListWithRandomPointer();
			var result = sut.Clone(n1);

			var expIt = n1;
			var actualIt = result;

			while (expIt != null)
			{
				Assert.That(expIt.Value, Is.EqualTo(actualIt.Value));

				if (expIt.Random != null)
					Assert.That(expIt.Random.Value, Is.EqualTo(actualIt.Random.Value));
				else
					Assert.That(actualIt.Random, Is.Null);

				expIt = expIt.Next;
				actualIt = actualIt.Next;
			}
		}
	}

}