using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Lists
{
	class MakeLoopInList
	{
		public void MakeLoop(SNode node, int k)
		{
			var steps = 0;
			var it = node;

			SNode kthNode = null;
			while (it != null)
			{
				steps++;

				if (steps == k)
				{
					kthNode = it;
				}

				if (it.Next == null)
				{
					it.Next = kthNode;
					break;
				}
				else
				{
					it = it.Next;
				}
			}
		}
	}

	[TestFixture]
	public class TestMakeLoopInList
	{
		[Test]
		public void Test1()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7 });

			var last = AlgoUtilities.Utilities.FindLastNode(list);

			var looper = new MakeLoopInList();
			looper.MakeLoop(list, 2);

			Assert.That(last.Next.Value, Is.EqualTo(2));
		}
	}
}
