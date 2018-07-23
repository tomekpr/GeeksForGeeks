using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeeksForGeeks.AlgoUtilities;
using GeeksForGeeks.DataStructures;

namespace GeeksForGeeks
{
	class UnionList
	{
		public SNode Union(SNode n1, SNode n2)
		{
			var head = new SNode();
			var index = new HashSet<int>();

			Add(ref head, n1, index);
			Add(ref head, n2, index);

			return head.Next;
		}

		void Add(ref SNode head, SNode list, HashSet<int> index)
		{
			var it = list;
			while(it != null)
			{
				if(!index.Contains(it.Value))
				{
					index.Add(it.Value);
					Add(ref head, it.Value);
				}

				it = it.Next;
			}
		}

		void Add(ref SNode head, int x)
		{
			if(head.Next == null)
			{
				head.Next = new SNode(x);
				return;
			}

			var first = head.Next;
			var n = new SNode(x);

			n.Next = first;
			head.Next = n;
		}
	}

	[TestFixture]
	public class TestUnionList
	{
		[Test]
		public void Test1()
		{
			var n1 = Utilities.ToSingleLinkedList(new int[] { 4, 5, 6 });
			var n2 = Utilities.ToSingleLinkedList(new int[] { 4, 7, 8 });

			var exp = new List<int> { 4, 5, 6, 7, 8 };
			var union = new IntersectList();

			var result = union.Intersect(n1, n2);
			var actual = Utilities.ToList(result);

			actual.Sort();

			Assert.That(actual.SequenceEqual(exp), Is.True);
		}

		[Test]
		public void Test2()
		{
			var n1 = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 4, 5, 6 });
			var n2 = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 7 });

			var exp = new List<int> { 4, 5, 6, 7 };
			var union = new IntersectList();

			var result = union.Intersect(n1, n2);
			var actual = AlgoUtilities.Utilities.ToList(result);

			actual.Sort();

			Assert.That(actual.SequenceEqual(exp), Is.True);
		}

		[Test]
		public void Test3()
		{
			var n1 = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] {  });
			var n2 = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 7 });

			var exp = new List<int> { 7 };
			var union = new IntersectList();

			var result = union.Intersect(n1, n2);
			var actual = AlgoUtilities.Utilities.ToList(result);

			actual.Sort();

			Assert.That(actual.SequenceEqual(exp), Is.True);
		}
	}
}
