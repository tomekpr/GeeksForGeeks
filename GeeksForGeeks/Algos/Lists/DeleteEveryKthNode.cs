using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Lists
{
	// https://www.youtube.com/watch?v=o-_r86WD3Qo
	// optimizations: if k == 1 return empty list?
	class DeleteEveryKthNode
	{
		public SNode Delete(SNode n, int k)
		{
			if (k < 1) return n;

			var result = new SNode();
			result.Next = n;

			var prev = result;
			var curr = n;

			var i = 1;
			while(curr != null)
			{
				if(i < k)
				{
					i++;
					prev = curr;
					curr = curr.Next;
				} else
				{
					var next = curr.Next;
					prev.Next = next;
					curr.Next = null;
					curr = next;
					i = 1;
				}
			}

			return result.Next;
		}
	}

	[TestFixture]
	public class TestDeleteEveryKthNode
	{
		[Test]
		public void test1()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
			var exp = new int[] { 1, 2, 4, 5, 7, 8 };

			var delete = new DeleteEveryKthNode();
			var result = delete.Delete(list, 3);

			var actual = AlgoUtilities.Utilities.ToList(result);
			var areEqual = actual.SequenceEqual(exp);

			Assert.IsTrue(areEqual);
		}

		[Test]
		public void test2()
		{
			var list = AlgoUtilities.Utilities.ToSingleLinkedList(new int[] { 1, 2, 3, 4, 5, 6 });
			var exp = new int[] {  };

			var delete = new DeleteEveryKthNode();
			var result = delete.Delete(list, 1);

			var actual = AlgoUtilities.Utilities.ToList(result);
			var areEqual = actual.SequenceEqual(exp);

			Assert.IsTrue(areEqual);
		}
	}
}
