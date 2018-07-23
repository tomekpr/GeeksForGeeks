using GeeksForGeeks.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.AlgoUtils
{
	// This needs to be tested!
	public static class Trees
	{
		public static void AddChildren(this NNode root, int parent, int[] children, int level)
		{
			int currentLevel = 1;
			var parentNode = FindNode(root, parent, currentLevel, level);
			parentNode.Add(children);
		}

		// 1. Boring level order traversal
		// 2. OR recursion
		static NNode FindNode(NNode node, int x, int currentLevel, int level)
		{
			if (node == null) return null;
			if (currentLevel > level) return null;

			if (node.Value == x) return node;
			foreach (var child in node.ChildNodes)
			{
				var n = FindNode(child, x, currentLevel + 1, level);
				if (n != null) return n;
			}

			return null;
		}

		public static List<int> InOrder(BinaryNode node)
		{
			var result = new List<int>();
			InOrderHelper(node, result);
			return result;
		}

		static void InOrderHelper(BinaryNode node, List<int> result)
		{
			if (node == null) return;

			InOrderHelper(node.Left, result);
			result.Add(node.Value);
			InOrderHelper(node.Right, result);
		}

		public static List<int> PreOrder(BinaryNode node)
		{
			var result = new List<int>();
			PreOrderHelper(node, result);
			return result;
		}

		static void PreOrderHelper(BinaryNode node, List<int> result)
		{
			if (node == null) return;

			result.Add(node.Value);

			PreOrderHelper(node.Left, result);
			PreOrderHelper(node.Right, result);
		}

		public static List<int> PostOrder(BinaryNode node)
		{
			var result = new List<int>();
			PostOrderHelper(node, result);
			return result;
		}

		static void PostOrderHelper(BinaryNode node, List<int> result)
		{
			if (node == null) return;

			PostOrderHelper(node.Left, result);
			PostOrderHelper(node.Right, result);

			result.Add(node.Value);
		}
	}
}
