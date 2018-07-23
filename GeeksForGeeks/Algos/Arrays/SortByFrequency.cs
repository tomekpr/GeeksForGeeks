using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Arrays
{
	class SortByFrequency
	{
		public void Sort(int[] arr)
		{
			var sortedDict = new SortedDictionary<Data, int>(Comparer<Data>.Create((x, y) => x.Freq.CompareTo(y.Freq)));

			//var sortedDict = new SortedDictionary<int, int>(Comparer<int>.Create((x,y) => y.CompareTo(x)));
			foreach (var item in arr)
			{
				var key = new Data() { Key = item };
				if (sortedDict.ContainsKey(key))
				{
					var count = sortedDict[key];
					count++;

					key.Freq = count;
					sortedDict[key] = count;
				}
				else
				{
					key.Freq = 1;
					sortedDict[key] = 1;
				}
			}

			var index = 0;
			foreach (var kvp in sortedDict)
			{
				for (int j = 0; j < kvp.Value; j++)
					arr[index++] = kvp.Key.Key;
			}
		}

		class Data
		{
			public int Key, Freq;
			public override int GetHashCode()
			{
				return Key;
			}

			public override bool Equals(object obj)
			{
				var key = obj as Data;
				return Equals(this, key);
			}

			public bool Equals(Data d, Data d2)
			{
				return d.Key == d2.Key;
			}
		}
	}

	[TestFixture]
	public class TestSortByFrequency
	{
		[Test]
		public void Test1()
		{
			int[] arr = new int[] { 2, 5, 2, 8, 5, 6, 8, 8 };
			var sut = new SortByFrequency();
			sut.Sort(arr);

			int[] exp = new int[] { 8, 8, 8, 2, 2, 5, 5, 6 };

			var result = arr.SequenceEqual(exp);
			Assert.IsTrue(result);
		}
	}
}
