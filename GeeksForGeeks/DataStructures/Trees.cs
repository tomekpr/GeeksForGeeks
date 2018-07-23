using System.Collections.Generic;

namespace GeeksForGeeks.DataStructures
{
	// N-ary node
	public class NNode
	{
		public int Value;
		public List<NNode> ChildNodes;

		public NNode(int v)
		{
			Value = v;
			ChildNodes = new List<NNode>();
		}

		public void Add(params NNode[] items)
		{
			ChildNodes.AddRange(items);
		}

		public void Add(params int[] items)
		{
			foreach (var i in items)
				ChildNodes.Add(new NNode(i));
		}

		public override string ToString() => $"Value:[{Value}] Count:[{ChildNodes?.Count}]";
	}
}
