using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class ReverseNoSpecialChars
	{
		public string Reverse(string s)
		{
			var items = s.ToCharArray();
			int w = 0, r = items.Length - 1;

			while(w < r)
			{
				if(Char.IsLetter(items[r]) == false)
				{
					r--;
					continue;
				}

				if(Char.IsLetter(items[w]) == false)
				{
					w++;
					continue;
				}

				var tmp = items[w];
				items[w] = items[r];
				items[r] = tmp;

				r--;
				w++;
			}

			return new string(items);
		}
	}

	[TestFixture]
	public class TestReverseNoSpecialChars
	{
		[Test]
		public void Test1()
		{
			ReverseNoSpecialChars r = new ReverseNoSpecialChars();
			var actual = r.Reverse("a,b$c");

			Assert.That(actual, Is.EqualTo("c,b$a"));
		}

		[Test]
		public void Test2()
		{
			ReverseNoSpecialChars r = new ReverseNoSpecialChars();
			var actual = r.Reverse("Ab,c,de!$");

			Assert.That(actual, Is.EqualTo("ed,c,bA!$"));
		}

		[TestCase("$.","$.")]
		[TestCase("$A","$A")]
		[TestCase("","")]
		[TestCase("A$","A$")]
		[TestCase("a!!!b.c.d,e'f,ghi", "i!!!h.g.f,e'd,cba")]
		public void Test3(string input, string output)
		{
			ReverseNoSpecialChars r = new ReverseNoSpecialChars();
			var actual = r.Reverse(input);

			Assert.That(actual, Is.EqualTo(output));
		}
	}
}
