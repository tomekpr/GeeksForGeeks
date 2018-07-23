using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	class VerticalSum
	{
		public int Sum(BinaryNode n, int line)
		{
			int sum = 0;
			SumHelper(n, line, line, ref sum);
			return sum;
		}

		void SumHelper(BinaryNode n, int line, int target, ref int sum)
		{
			if (n == null) return;

			Console.WriteLine("Node: " + n.Value + " line " + line);
			SumHelper(n.Left, line - 1, target, ref sum);

			if (line == target)
				sum += n.Value;

			SumHelper(n.Right, line + 1, target, ref sum);
		}
	}

	[TestFixture]
	public class TestVerticalSum
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNode(1);
			root.Left = new BinaryNode(2);
			root.Left.Left = new BinaryNode(4);
			root.Left.Right = new BinaryNode(5);

			root.Right = new BinaryNode(3);
			root.Right.Left = new BinaryNode(7);
			root.Right.Right = new BinaryNode(6);

			var sut = new VerticalSum();
			var result = sut.Sum(root, 3);

			Assert.That(result == 13);
		}
	}
}
