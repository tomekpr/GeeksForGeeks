using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks
{
	class DoubleLinkedList
	{
		private DNode head, tail;

		public List<int> GetValues()
		{
			var result = new List<int>();

			if (head == null)
				return result;

			var it = head.Next;
			while(it != null)
			{
				result.Add(it.Value);
				it = it.Next;
			}

			return result;
		}

		public void Add(int x)
		{
			var n = new DNode(x);

			if (head == null)
			{
				head = new DNode();
				head.Next = n;

				tail = new DNode();
				tail.Next = n;
				return;
			}

			
			var last = tail.Next;
			last.Next = n;
			n.Prev = last;

			// don't touch head
			// update tail
			tail.Next = n;
		}

		public void Delete(int x)
		{
			var toDel = Find(x);
			if (toDel == null) return;

			if (toDel.Prev == null)
				DeleteFirst();
			else if (toDel.Next == null)
				DeleteLast();
			else
			{
				// Somewhere in the middle!
				var before = toDel.Prev;
				var after = toDel.Next;

				before.Next = after;
				after.Prev = before;

				toDel.Next = null;
				toDel.Prev = null;
			}
		}

		void DeleteFirst()
		{
			var first = head.Next;

			// update head
			head.Next = first.Next;

			// clear previous pointer
			head.Next.Prev = null;

			// clear node
			first.Next = null;
		}

		void DeleteLast()
		{
			var last = tail.Next;

			var newLast = tail.Next.Prev;
			newLast.Next = null;

			tail.Next = newLast;
			last.Prev = null;
		}

		DNode Find(int x)
		{
			if (head == null) return null;

			var it = head.Next;
			while(it != null)
			{
				if (it.Value == x) return it;
				it = it.Next;
			}

			return null;
		}
	}

	[TestFixture]
	public class TestDoublyLinkedList
	{
		[Test]
		public void Test1()
		{
			var dll = new DoubleLinkedList();
			var exp = new int[] { 5, 12, 4, 8 };

			foreach (var n in exp)
				dll.Add(n);

			var actual = dll.GetValues();
			Assert.That(actual.SequenceEqual(exp), Is.True);
		}

		[Test]
		public void Test2()
		{
			var dll = new DoubleLinkedList();
			var exp = new List<int> { 5, 12, 4, 8 };

			foreach (var n in exp)
				dll.Add(n);

			dll.Delete(4);
			exp.Remove(4);

			var actual = dll.GetValues();
			Assert.That(actual.SequenceEqual(exp), Is.True);
		}

		[Test]
		public void Test3()
		{
			var dll = new DoubleLinkedList();
			var exp = new List<int> { 5, 12, 4, 8 };

			foreach (var n in exp)
				dll.Add(n);

			dll.Delete(5);
			exp.Remove(5);

			var actual = dll.GetValues();
			Assert.That(actual.SequenceEqual(exp), Is.True);
		}

		[Test]
		public void Test4()
		{
			var dll = new DoubleLinkedList();
			var exp = new List<int> { 5, 12, 4, 8 };

			foreach (var n in exp)
				dll.Add(n);

			dll.Delete(8);
			exp.Remove(8);

			var actual = dll.GetValues();
			Assert.That(actual.SequenceEqual(exp), Is.True);
		}
	}
}
