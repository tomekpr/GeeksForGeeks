using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Trees
{
	// https://www.youtube.com/watch?v=K5ifmmXjwOg
	class AllLeavesOnTheSameLevel
	{
		public bool IsSameLevel(BinaryNode node)
		{
			int? leafLevel = null;
			int currentLevel = 0;

			bool result = VisitorHelper(node, currentLevel, ref leafLevel);

			return result;
		}

		bool VisitorHelper(BinaryNode node, int currentLevel, ref int? leafLevel)
		{
			if (node == null) return true;

			if(node.Left == null && node.Right == null)
			{
				if (!leafLevel.HasValue)
					leafLevel = currentLevel;

				return leafLevel == currentLevel;
			}

			var result = VisitorHelper(node.Left, currentLevel + 1, ref leafLevel);
			if (!result) return false;

			result = VisitorHelper(node.Right, currentLevel + 1, ref leafLevel);
			return result;
		}
	}
	
	[TestFixture]
	public class TestAllLeavesOnTheSameLevel
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNode(12);
			root.Left = new BinaryNode(5);
			root.Left.Left = new BinaryNode(3);

			root.Right = new BinaryNode(7);

			var sameLevel = new AllLeavesOnTheSameLevel();

			bool result = sameLevel.IsSameLevel(root);
			Assert.IsFalse(result);
		}

		[Test]
		public void Test2()
		{
			var root = new BinaryNode(12);
			root.Left = new BinaryNode(5);
			root.Left.Left = new BinaryNode(3);

			root.Right = new BinaryNode(7);
			root.Right.Right = new BinaryNode(1);

			var sameLevel = new AllLeavesOnTheSameLevel();

			bool result = sameLevel.IsSameLevel(root);
			Assert.IsTrue(result);
		}

		[Test]
		public void Test3()
		{
			var root = new BinaryNode(12);
			root.Left = new BinaryNode(5);
			root.Left.Left = new BinaryNode(3);
			root.Left.Left.Left = new BinaryNode(1);

			root.Left.Right = new BinaryNode(9);
			root.Left.Right.Left = new BinaryNode(2);

			var sameLevel = new AllLeavesOnTheSameLevel();

			bool result = sameLevel.IsSameLevel(root);
			Assert.IsTrue(result);
		}
	}
}
