using System;

namespace GeeksForGeeks.DataStructures
{
	public class SNode
	{
		public int Value;
		public SNode Next;
		public SNode() { }
		public SNode(int x) => Value = x;

		public override string ToString() => Value.ToString();

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(obj, null)) return false;
			if (ReferenceEquals(this, obj)) return true;

			return Equals(this, obj as SNode);
		}

		internal object ToList()
		{
			throw new NotImplementedException();
		}

		bool Equals(SNode node1, SNode node2)
		{
			return node1.Value == node2.Value;
		}

		public override int GetHashCode()
		{
			return Value ^ 1254323;
		}
	}

	public class DNode
	{
		public int Value;
		public DNode Prev;
		public DNode Next;

		public DNode() { }
		public DNode(int x) => Value = x;

		public override string ToString() => Value.ToString();
	}

	// flatten list representation
	public class FNode
	{
		public int Value;
		public FNode Next;
		public FNode Head;

		public FNode() { }
		public FNode(int x) => Value = x;

		public override string ToString() => Value.ToString();
	}
}
