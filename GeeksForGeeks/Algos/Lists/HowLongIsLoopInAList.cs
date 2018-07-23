using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Lists
{
	class HowLongIsLoopInAList
	{
		public int LoopLength(SNode node)
		{
			var map = new HashSet<int>(); // assuming unique values.
			var it = node;

			SNode loopStart = null;

			while(it != null)
			{
				if(map.Contains(it.Value))
				{
					loopStart = it;
					break;
				}

				map.Add(it.Value);
				it = it.Next;
			}

			if (loopStart == null) return 0;

			var loopLength = 1;
			it = loopStart.Next;
			while(it.Next.Value != loopStart.Value)
			{
				loopLength++;
				it = it.Next;
			}

			return loopLength;
		}
	}

	[TestFixture]
	public class TestHowLongIsALoopInAList
	{
		[Test]
		public void Test1()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 1, 2, 3, 4, 5 });
			var last = AlgoUtilities.Utilities.FindLastNode(list);

			// Create a loop
			last.Next = list.Next;

			var sut = new HowLongIsLoopInAList();
			var result = sut.LoopLength(list);

			Assert.That(result, Is.EqualTo(3));
		}

		[Test]
		public void Test2()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 1, 2, 3, 4 });
			var last = AlgoUtilities.Utilities.FindLastNode(list);

			// Create a loop
			last.Next = list.Next;

			var sut = new HowLongIsLoopInAList();
			var result = sut.LoopLength(list);

			Assert.That(result, Is.EqualTo(2));
		}
	}
}
