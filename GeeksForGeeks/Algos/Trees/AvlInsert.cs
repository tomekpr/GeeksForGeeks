using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class AvlNode
	{
		public int Value;
		public int Depth;
		public int BFactor;
		public AvlNode Left;
		public AvlNode Right;

		public AvlNode(int x) => Value = x;
		public override string ToString()
		{
			return $"Value:{Value} Depth:{Depth} BFactor:{BFactor}";
		}
	}

	class AvlInsert
	{
		public AvlNode root;

		public void Insert(int x)
		{
			if(root == null)
			{
				root = new AvlNode(x);
				return;
			}

			Insert(root, x);
		}

		void Insert(AvlNode node, int x)
		{
			if(x < node.Value)
			{
				if(node.Left == null)
				{
					node.Left = new AvlNode(x);
					node.Depth = Math.Max(1, GetDepth(node.Right));
				}
				else
				{
					Insert(node.Left, x);
					node.Depth = Math.Max(1 + node.Left.Depth, GetDepth(node.Right));
				}
			}
			else
			{
				if(node.Right == null)
				{
					node.Right = new AvlNode(x);
					node.Depth = Math.Max(GetDepth(node.Left), 1);
				}
				else
				{
					Insert(node.Right, x);
					node.Depth = Math.Max(GetDepth(node.Left), 1 + node.Right.Depth);
				}
			}

			node.BFactor = GetDepth(node.Left) - GetDepth(node.Right);
		}

		int GetDepth(AvlNode node) => node == null ? 0 : node.Depth;
	}

	[TestFixture]
	public class TestAvlInsert
	{
		[Test]
		public void Test1()
		{
			var avl = new AvlInsert();
			avl.Insert(10);

			Assert.That(avl.root.Depth, Is.EqualTo(0));
			Assert.That(avl.root.BFactor, Is.EqualTo(0));
		}

		[Test]
		public void Test2()
		{
			var avl = new AvlInsert();
			avl.Insert(10);
			avl.Insert(5);

			Assert.That(avl.root.Depth, Is.EqualTo(1));
			Assert.That(avl.root.BFactor, Is.EqualTo(1));
			Assert.That(avl.root.Left.Depth, Is.EqualTo(0));
		}

		[Test]
		public void Test3()
		{
			var avl = new AvlInsert();
			avl.Insert(10);
			avl.Insert(5);
			avl.Insert(3);

			Assert.That(avl.root.Depth, Is.EqualTo(2));
			Assert.That(avl.root.Left.Depth, Is.EqualTo(1));
			Assert.That(avl.root.Left.Left.Depth, Is.EqualTo(0));
		}

		[Test]
		public void Test4()
		{
			var avl = new AvlInsert();
			avl.Insert(10);
			avl.Insert(5);
			avl.Insert(3);
			avl.Insert(8);

			Assert.That(avl.root.Depth, Is.EqualTo(2));
			Assert.That(avl.root.Left.Depth, Is.EqualTo(1));
			Assert.That(avl.root.Left.Left.Depth, Is.EqualTo(0));

			Assert.That(avl.root.Left.Right.Depth, Is.EqualTo(0));
		}

		[Test]
		public void Test5()
		{
			var avl = new AvlInsert();
			avl.Insert(10);
			avl.Insert(5);
			avl.Insert(3);
			avl.Insert(8);
			avl.Insert(9);

			Assert.That(avl.root.Depth, Is.EqualTo(3));
			Assert.That(avl.root.Left.Depth, Is.EqualTo(2));
			Assert.That(avl.root.Left.Left.Depth, Is.EqualTo(0));

			Assert.That(avl.root.Left.Right.Depth, Is.EqualTo(1));
			Assert.That(avl.root.Left.Right.Right.Depth, Is.EqualTo(0));
		}
	}
}
