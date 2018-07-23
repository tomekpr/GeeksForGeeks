using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	[TestFixture]
	class PrintSeries
	{
		List<int> Print(int n1, int n2)
		{
			var result = new List<int>();
			Print(n1, n2, result);
			return result;
		}

		void Print(int n1, int n2, List<int> result)
		{
			if(n1 <= n2)
			{
				result.Add(n1);
				Print(n1 + 1, n2, result);
			}
		}

		[Test]
		public void Test1()
		{
			var printer = new PrintSeries();
			var result = printer.Print(5, 10);
			Assert.That(result.SequenceEqual(new int[] { 5, 6, 7, 8, 9, 10 }), Is.True);
		}
	}
}
