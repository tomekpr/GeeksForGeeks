using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Lists
{
	class FlattenLists
	{
		public FNode Flatten(FNode list)
		{
			var result = new FNode();
			var linker = result;

			while (list != null)
			{
				var it = BuildIterator(list);
				var it2 = BuildIterator(list.Next);

				linker.Next = Merge(it, it2);
				linker = linker.Next;

				list = list.Next?.Next;
				//if (list != null) list = list.Next;
			}

			return result.Next;
		}

		FNode BuildIterator(FNode fnode)
		{
			if (fnode == null) return null;

			var it = new FNode(fnode.Value);
			it.Next = fnode.Head;

			return it;
		}

		FNode Merge(FNode n1, FNode n2)
		{
			if (n1 == null) return n2;
			if (n2 == null) return n1;

			var result = new FNode();
			var linker = result;
			while (n1 != null && n2 != null)
			{
				if (n1.Value <= n2.Value)
				{
					linker.Next = n1;
					n1 = n1.Next;
				}
				else
				{
					linker.Next = n2;
					n2 = n2.Next;
				}

				linker = linker.Next;
			}

			while (n1 != null)
			{
				linker.Next = n1;
				n1 = n1.Next;
				linker = linker.Next;
			}

			while (n2 != null)
			{
				linker.Next = n2;
				n2 = n2.Next;
				linker = linker.Next;
			}

			return result.Next;
		}
	}

	[TestFixture]
	public class FlattenListsTests
	{
		[Test]
		public void Test1()
		{
			var five = new FNode(5);
			five.Head = new FNode(7);
			five.Head.Next = new FNode(8);
			five.Head.Next.Next = new FNode(30);

			var ten = new FNode(10);
			ten.Head = new FNode(20);

			five.Next = ten;

			var expected = new int[] { 5, 7, 8, 10, 20, 30 };
			var fl = new FlattenLists();
			var result = fl.Flatten(five);

			var actual = AlgoUtilities.Utilities.ToList(result);

			var equal = actual.SequenceEqual(expected);
			Assert.That(equal, Is.True);
		}

		[Test]
		public void Test2()
		{
			var four = new FNode(4);
			four.Head = new FNode(5);
			four.Head.Next = new FNode(6);

			var one = new FNode(1);
			one.Head = new FNode(3);
			one.Head.Next = new FNode(7);

			var nine = new FNode(9);
			nine.Head = new FNode(11);
			nine.Head.Next = new FNode(13);

			four.Next = one;
			one.Next = nine;

			var expected = new int[] { 1, 3, 4, 5, 6, 7, 9, 11, 13 };
			var fl = new FlattenLists();
			var result = fl.Flatten(four);

			var actual = AlgoUtilities.Utilities.ToList(result);

			var equal = actual.SequenceEqual(expected);
			Assert.That(equal, Is.True);
		}
	}
}
