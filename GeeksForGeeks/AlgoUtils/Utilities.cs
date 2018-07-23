using GeeksForGeeks.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksForGeeks.AlgoUtilities
{
	public static class Utilities
	{
		public static SNode ToSingleLinkedList(IList<int> items)
		{
			if (items.Any() == false) return null;

			var n = new SNode(items[0]);
			var head = n;

			for (int i = 1; i < items.Count; i++)
			{
				n.Next = new SNode(items[i]);
				n = n.Next;
			}

			return head;
		}

		public static List<int> ToList(SNode node)
		{
			var result = new List<int>();
			while(node != null)
			{
				result.Add(node.Value);
				node = node.Next;
			}

			return result;
		}

		public static List<int> ToList(DNode node)
		{
			var result = new List<int>();
			while (node != null)
			{
				result.Add(node.Value);
				node = node.Next;
			}

			return result;
		}

		internal static SNode FindLastNode(SNode list)
		{
			if (list == null) return null;

			var it = list;
			while(it != null)
			{
				if (it.Next == null) return it;
				it = it.Next;
			}

			return null;
		}

		public static List<int> ToList(FNode node)
		{
			var result = new List<int>();
			while (node != null)
			{
				result.Add(node.Value);
				node = node.Next;
			}

			return result;
		}
	}
}
