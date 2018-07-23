using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	// https://www.geeksforgeeks.org/given-a-linked-list-which-is-sorted-how-will-you-insert-in-sorted-way/
	class InsertSortedIntoSingleLinkedList
	{
		private SNode head, tail;
		public List<int> GetValues()
		{
			var it = head.Next;
			var result = new List<int>();
			while (it != null)
			{
				result.Add(it.Value);
				it = it.Next;
			}

			return result;
		}

		public void InsertSorted(int x)
		{
			if (head == null)
			{
				var n = new SNode(x);

				head = new SNode();
				head.Next = n;

				tail = new SNode();
				tail.Next = n;

				return;
			}

			if (x <= head.Next.Value)
			{
				PrependList(x);
			}
			else if (x >= tail.Next.Value)
			{
				AppendToList(x);
			}
			else
			{
				InsertInTheMiddle(x);
			}
		}

		void PrependList(int x)
		{
			var first = head.Next;
			var n = new SNode(x);

			n.Next = first;
			head.Next = n;
		}

		void AppendToList(int x)
		{
			var last = tail.Next;
			var n = new SNode(x);

			last.Next = n;
			tail.Next = n;
		}

		void InsertInTheMiddle(int x)
		{
			var it = head.Next;
			var prev = it;

			while (it != null)
			{
				if (it.Value >= x) break;

				prev = it;
				it = it.Next;
			}

			var before = prev;
			var after = before.Next;

			var n = new SNode(x);
			before.Next = n;
			n.Next = after;
		}
	}

	[TestFixture]
	public class TestInsertSortedIntoSingleLinkedList
	{
		[Test]
		public void AddSingleElem()
		{
			var exp = new List<int>() { 5 };

			var insertAlgo = new InsertSortedIntoSingleLinkedList();
			insertAlgo.InsertSorted(5);

			var result = insertAlgo.GetValues();
			Assert.That(result.SequenceEqual(exp), Is.True);
		}

		[Test]
		public void AddBeforeFirst()
		{
			var exp = new List<int>() { 2, 5 };

			var insertAlgo = new InsertSortedIntoSingleLinkedList();
			insertAlgo.InsertSorted(5);
			insertAlgo.InsertSorted(2);

			var result = insertAlgo.GetValues();
			Assert.That(result.SequenceEqual(exp), Is.True);
		}

		[Test]
		public void AddAfterLast()
		{
			var exp = new List<int>() { 2, 5, 8 };

			var insertAlgo = new InsertSortedIntoSingleLinkedList();
			insertAlgo.InsertSorted(5);
			insertAlgo.InsertSorted(2);
			insertAlgo.InsertSorted(8);

			var result = insertAlgo.GetValues();
			Assert.That(result.SequenceEqual(exp), Is.True);
		}

		[Test]
		public void AddInTheMiddle()
		{
			var exp = new List<int>() { 2, 5, 7, 8 };

			var insertAlgo = new InsertSortedIntoSingleLinkedList();
			insertAlgo.InsertSorted(5);
			insertAlgo.InsertSorted(2);
			insertAlgo.InsertSorted(8);

			// Act
			insertAlgo.InsertSorted(7);

			var result = insertAlgo.GetValues();
			Assert.That(result.SequenceEqual(exp), Is.True);
		}


		[Test]
		public void Test1()
		{
			var items = new List<int> { 10, 7, 2, 5, 15 };
			var exp = new List<int> { 2, 5, 7, 10, 15 };

			var insertAlgo = new InsertSortedIntoSingleLinkedList();
			foreach (var n in items)
				insertAlgo.InsertSorted(n);

			var actual = insertAlgo.GetValues();
			Assert.That(actual.SequenceEqual(exp), Is.True);
		}
	}
}
