using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	class AreTreesIdentical
	{
		public bool AreIdentical(BinaryNode node1, BinaryNode node2)
		{
			var q1 = new Queue<BinaryNode>();
			var q2 = new Queue<BinaryNode>();

			q1.Enqueue(node1);
			q2.Enqueue(node2);

			while(q1.Any() || q2.Any())
			{
				var size1 = q1.Count;
				var size2 = q2.Count;

				if (size1 != size2) return false;

				while (size1-- > 0)
				{
					var n1 = q1.Dequeue();
					var n2 = q2.Dequeue();

					if (n1 == null && n2 == null) continue;

					//if(n1.Equals(n2) == false) return false;
					if(n1 != n2) return false;

					q1.Enqueue(n1.Left);
					q1.Enqueue(n1.Right);

					q2.Enqueue(n2.Left);
					q2.Enqueue(n2.Right);
				}
			}

			return true;
		}
	}

	[TestFixture]
	public class TestAreTreesIdentical
	{
		[Test]
		public void Test1()
		{
			var tree1 = new BinaryNode(10);
			tree1.Left = new BinaryNode(5);
			tree1.Right = new BinaryNode(6);

			var tree2 = new BinaryNode(10);
			tree2.Left = new BinaryNode(5);
			tree2.Right = new BinaryNode(6);

			var sut = new AreTreesIdentical();
			bool result = sut.AreIdentical(tree1, tree2);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Test2()
		{
			var tree1 = new BinaryNode(10);
			tree1.Left = new BinaryNode(5);
			tree1.Right = new BinaryNode(6);

			var tree2 = new BinaryNode(10);
			tree2.Left = new BinaryNode(5);

			var sut = new AreTreesIdentical();
			bool result = sut.AreIdentical(tree1, tree2);

			Assert.That(result, Is.False);
		}

		[Test]
		public void Test3()
		{
			var tree1 = new BinaryNode(10);
			tree1.Left = new BinaryNode(5);
			tree1.Right = new BinaryNode(6);

			var tree2 = new BinaryNode(10);
			tree2.Left = new BinaryNode(5);
			tree2.Right = new BinaryNode(6);
			tree2.Right.Left = new BinaryNode(12);

			var sut = new AreTreesIdentical();
			bool result = sut.AreIdentical(tree1, tree2);

			Assert.That(result, Is.False);
		}
	}
}
