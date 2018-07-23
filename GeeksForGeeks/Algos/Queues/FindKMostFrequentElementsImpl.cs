using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class NumToFreq
	{
		public int Num;
		public int Freq;

		public NumToFreq(int n, int f)
		{
			Num = n;
			Freq = f;
		}
	}

	class FindKMostFrequentElementsImpl
	{
		public List<int> Find(List<int> items, int k)
		{
			var numToFreq = GroupItems(items);
			var result = new List<int>();
			var slist = new SortedList<NumToFreq, bool>(
				Comparer<NumToFreq>.Create((x, y) => x.Freq.CompareTo(y.Freq)));

			foreach (var nf in numToFreq)
				slist.Add(new NumToFreq(nf.Key, nf.Value), true);

			for (int i = slist.Count - 1; i >= 0; i--)
			{
				if (result.Count < k)
					result.Add(slist.Keys[i].Num);
				else
					break;
			}

			return result;
		}

		private Dictionary<int, int> GroupItems(List<int> items)
		{
			var numToFreq = new Dictionary<int, int>();
			foreach (var i in items)
			{
				if (numToFreq.ContainsKey(i))
				{
					numToFreq[i]++;
				}
				else numToFreq[i] = 1;
			}

			return numToFreq;
		}
	}


	[TestFixture]
	class TestFindKMostFrequentElementsImpl
	{
		[Test]
		public void Test1()
		{
			var impl = new FindKMostFrequentElementsImpl();
			var result = impl.Find(new List<int>() { 1, 6, 2, 1, 6, 1 }, 2);

			Assert.That(result.SequenceEqual(new List<int>() { 1, 6 }), Is.True);
		}
	}
}
