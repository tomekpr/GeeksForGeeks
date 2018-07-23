using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	// alternative, yet to be understood, implementation:
	// https://www.youtube.com/watch?v=OLvzM1ZcbtQ
	class ConnectNodesOnTheSameLevelWithExtraConstantSpace
	{
		public void Connect(BinaryNode node)
		{
			var s = new Queue<BinaryNode>();
			s.Enqueue(node);

			while (s.Any())
			{
				var size = s.Count;
				BinaryNode last = null;
				while (size-- > 0)
				{
					var current = s.Dequeue();
					if (current == null) continue;

					current.Next = last;
					last = current;

					s.Enqueue(current.Right);
					s.Enqueue(current.Left);
				}
			}
		}
	}

	[TestFixture]
	public class TestConnectNodesOnTheSameLevelWithExtraConstantSpace
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNode(1);

			var two = new BinaryNode(2);
			var three = new BinaryNode(3);

			root.Left = two;
			root.Right = three;

			two.Left = new BinaryNode(4);
			two.Right = new BinaryNode(5);

			three.Right = new BinaryNode(6);

			var sut = new ConnectNodesOnTheSameLevelWithExtraConstantSpace();
			sut.Connect(root);

			// Assert
			Assert.That(root.Next == null);
			Assert.That(two.Next.Value == 3);
			Assert.That(three.Next == null);

			// first level
			Assert.That(two.Left.Next.Value == 5);
			Assert.That(two.Right.Next.Value == 6);
			Assert.That(three.Right.Next == null);
		}
	}
}
