using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	public class ListCycleImpl
	{
		public bool HasCycle(Cell sentinel)
		{
			if (sentinel.Next == null) return false;

			Cell newSentinel = ReverseList(sentinel);
			ReverseList(newSentinel); // restore order.

			return newSentinel.Value == sentinel.Value;
		}

		Cell ReverseList(Cell sentinel)
		{
			Cell prev = null;
			Cell current = sentinel;

			while(current != null)
			{
				var next = current.Next;
				current.Next = prev;

				prev = current;
				current = next;
			}

			return prev;
		}	
	}

	public class Cell
	{
		public char Value;
		public Cell Next;

		public Cell(char c)
		{
			Value = c;
		}
	}

	[TestFixture]
	public class TestListCycleImpl
	{
		[Test]
		public void Test1()
		{
			var a = new Cell('A');
			var b = new Cell('B');
			var c = new Cell('C');
			var d = new Cell('D');
			var e = new Cell('E');
			var f = new Cell('F');
			var g = new Cell('G');
			var h = new Cell('H');
			var i = new Cell('I');

			a.Next = b;
			b.Next = c;
			c.Next = d;
			d.Next = e;
			e.Next = f;
			f.Next = g;
			g.Next = h;
			h.Next = i;

			i.Next = d; // loop!

			var impl = new ListCycleImpl();
			bool hasCycle = impl.HasCycle(a);

			Assert.That(hasCycle, Is.True);
		}

		[Test]
		public void Test2()
		{
			var a = new Cell('A');
			var b = new Cell('B');
			var c = new Cell('C');
			var d = new Cell('D');
			var e = new Cell('E');
			var f = new Cell('F');
			var g = new Cell('G');
			var h = new Cell('H');
			var i = new Cell('I');

			a.Next = b;
			b.Next = c;
			c.Next = d;
			d.Next = e;
			e.Next = f;
			f.Next = g;
			g.Next = h;
			h.Next = i;

			var impl = new ListCycleImpl();
			bool hasCycle = impl.HasCycle(a);

			Assert.That(hasCycle, Is.False);
		}
	}
}
