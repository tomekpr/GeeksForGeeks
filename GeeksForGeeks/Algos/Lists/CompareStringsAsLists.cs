using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class Node<T>
	{
		public T Value;
		public Node<T> Next;

		public Node() { }
		public Node(T item) { Value = item; }
	}

	class CompareStringsAsLists
	{
		public int Compare(Node<char> n1, Node<char> n2)
		{
			if (n1 == null && n2 == null) return 0;
			if (n1 == null) return -1;
			if (n2 == null) return 1;

			var it1 = n1;
			var it2 = n2;

			int result = 1000;

			while(it1 != null && it2 != null)
			{
				result = it1.Value.CompareTo(it2.Value);
				if (result != 0) return result;

				it1 = it1.Next;
				it2 = it2.Next;
			}

			if (it1 == null && it1 == null) return result;


			if (it1 == null) return -1;
			if (it2 == null) return 1;

			return result;
		}
	}

	[TestFixture]
	public class TestCompareStringsAsLists
	{
		[Test]
		public void Test1()
		{
			var n1 = ToList("geeksa");
			var n2 = ToList("geeksb");

			var co = new CompareStringsAsLists();
			var result = co.Compare(n1, n2);

			Assert.That(result, Is.EqualTo(-1));
		}

		[Test]
		public void Test2()
		{
			var n1 = ToList("geeksa");
			var n2 = ToList("geeks");

			var co = new CompareStringsAsLists();
			var result = co.Compare(n1, n2);

			Assert.That(result, Is.EqualTo(1));
		}

		[Test]
		public void Test3()
		{
			var n1 = ToList("geeks");
			var n2 = ToList("geeks");

			var co = new CompareStringsAsLists();
			var result = co.Compare(n1, n2);

			Assert.That(result, Is.EqualTo(0));
		}

		private Node<char> ToList(string s)
		{
			var n = new Node<char>(s[0]);
			var head = n;

			for (int i=1; i < s.Length; i++)
			{
				n.Next = new Node<char>(s[i]);
				n = n.Next;
			}

			return head;
		}
	}
}
