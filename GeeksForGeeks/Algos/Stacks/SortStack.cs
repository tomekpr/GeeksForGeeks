using NUnit.Framework;
using System.Collections.Generic;

namespace GeeksForGeeks
{
	[TestFixture]
	class SortStack
	{
		void Sort(Stack<int> stack)
		{
			int current = 0;
			while(current < stack.Count)
			{
				var elem = stack.Pop();
				InsertIntoStack(elem, stack);
				current++;
			}
		}

		void InsertIntoStack(int elem, Stack<int> stack)
		{
			if (stack.Count == 0)
				stack.Push(elem);
			else
			{
				if (elem < stack.Peek())
				{
					var holder = stack.Pop();
					InsertIntoStack(elem, stack);
					stack.Push(holder);
				}
				else stack.Push(elem);
			}
		}

		[Test]
		public void Test()
		{
			var s = new Stack<int>();
			s.Push(4);
			s.Push(2);
			s.Push(-5);

			Sort(s);

			var exp = new List<int>() { 4,2,-5 };
			for(int i=0; i < exp.Count; i++)
			{
				var item = s.Pop();
				Assert.That(item, Is.EqualTo(exp[i]));
			}
		}

		[Test]
		public void TestAlreadySorted()
		{
			var s = new Stack<int>();
			s.Push(-5);
			s.Push(2);
			s.Push(4);

			Sort(s);

			var exp = new List<int>() { 4, 2, -5 };
			for (int i = 0; i < exp.Count; i++)
			{
				var item = s.Pop();
				Assert.That(item, Is.EqualTo(exp[i]));
			}
		}
	}
}
