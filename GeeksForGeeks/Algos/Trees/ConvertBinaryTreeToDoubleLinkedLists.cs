using GeeksForGeeks.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks.Algos.Trees
{
	class ConvertBinaryTreeToDoubleLinkedLists
	{
		public DNode Convert(BinaryNode binaryNode)
		{
			var head = new DNode();
			InOrder(binaryNode, head);
			return head.Next;
		}

		void InOrder(BinaryNode binaryNode, DNode prev)
		{
			if (binaryNode == null) return;

			InOrder(binaryNode.Left, prev);

			// Adjust prev
			while (prev.Next != null)
				prev = prev.Next;

			// Link
			var newNode = new DNode(binaryNode.Value);
			newNode.Prev = prev;
			prev.Next = newNode;

			prev = newNode;

			InOrder(binaryNode.Right, newNode);
		}
	}

	[TestFixture]
	public class TestConvertBinaryTreeToDoubleLinkedLists
	{
		[Test]
		public void Test1()
		{
			var root = new BinaryNode(10);
			root.Left = new BinaryNode(12);
			root.Left.Left = new BinaryNode(25);
			root.Left.Right = new BinaryNode(30);

			root.Right = new BinaryNode(15);
			root.Right.Left = new BinaryNode(36);

			var converter = new ConvertBinaryTreeToDoubleLinkedLists();
			var list = converter.Convert(root);

			var actual = AlgoUtilities.Utilities.ToList(list);
			var expected = new List<int> { 25, 12, 30, 10, 36, 15 };

			Console.WriteLine($"  Actual: {String.Join(",",actual)}");
			Console.WriteLine($"Expected: {String.Join(",",expected)}");
			bool areEqual = actual.SequenceEqual(expected);
			Assert.That(areEqual, Is.True);
		}
	}
}
