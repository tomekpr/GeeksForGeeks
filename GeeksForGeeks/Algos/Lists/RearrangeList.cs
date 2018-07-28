using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks.Algos.Lists
{
	class RearrangeList
	{
		public void Rearrange(SNode node)
		{
			var oddNumbers = new List<int>();
			var writeIndex = node;
			var readIndex = node;

			while (readIndex != null)
			{
				if (readIndex.Value % 2 != 0)
				{
					oddNumbers.Add(readIndex.Value);
					readIndex = readIndex.Next;
				}
				else
				{
					writeIndex.Value = readIndex.Value;
					writeIndex = writeIndex.Next;
					readIndex = readIndex.Next;
				}
			}

			foreach (var n in oddNumbers)
			{
				writeIndex.Value = n;
				writeIndex = writeIndex.Next;
			}
		}
	}

	[TestFixture]
	public class TestRearrangeList
	{
		[Test]
		public void Test1()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 1, 2, 4, 3, 6 });
			var expected = new int[] { 2, 4, 6, 1, 3 };

			var sut = new RearrangeList();
			sut.Rearrange(list);

			var actual = AlgoUtilities.Utilities.ToList(list);
			var areEqual = expected.SequenceEqual(actual);

			Assert.That(areEqual, Is.True);
		}
	}
}
