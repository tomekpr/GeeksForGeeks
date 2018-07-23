using GeeksForGeeks.AlgoUtils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Stacks
{
	class ReverseStack
	{
		// https://www.youtube.com/watch?v=SW14tOda_kI
		public void Revese(Stack<int> s)
		{
			var q = new Queue<int>();
			ReverseHelper(s, q);
		}

		void ReverseHelper(Stack<int> s, Queue<int> q)
		{
			if(s.Count > 0)
			{
				var item = s.Pop();
				q.Enqueue(item);
				ReverseHelper(s, q);

				s.Push(q.Dequeue());
			}
		}
	}

	[TestFixture]
	public class TestReverseStack
	{
		[Test]
		public void Test1()
		{
			var s = new Stack<int>();
			s.Push(3);
			s.Push(2);
			s.Push(1);

			var sut = new ReverseStack();
			sut.Revese(s);

			var expected = new Stack<int>();
			expected.Push(1);
			expected.Push(2);
			expected.Push(3);

			var areEqual = StackHelpers.CompareStacks(s, expected);
			Assert.IsTrue(areEqual);
		}
	}
}
