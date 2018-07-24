using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Lists
{
	// Could be done with easy stack implementation
	class PrintListFromEnd
	{
		public List<int> Print(SNode node)
		{
			var result = new List<int>();
			PrintHelper(node, result);
			return result;
		}

		void PrintHelper(SNode node, List<int> result)
		{
			if (node == null) return;

			PrintHelper(node.Next, result);
			result.Add(node.Value);
		}
	}

	[TestFixture]
	public class TestPrintListFromEnd
	{
		[Test]
		public void Test1()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 1, 2, 3, 4, 5 });
			var expected = new List<int>() { 5, 4, 3, 2, 1 };
			var sut = new PrintListFromEnd();
			var result = sut.Print(list);

			var areEqual = result.SequenceEqual(expected);
			Assert.That(areEqual, Is.True);
		}

	}
}
