using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Algos.Strings
{
	class FindLargestStringInDictionary
	{
		public string Find(HashSet<string> dict, string longs)
		{
			string longest = "";
			int length = 0;
			foreach(var w in dict)
			{
				if(w.Length > length && IsSubstring(w, longs))
				{
					length = w.Length;
					longest = w;
				}
			}

			return longest;
		}

		bool IsSubstring(string shorts, string longs)
		{
			int m = shorts.Length;
			int n = longs.Length;

			int j = 0;
			for(int i =0; i < n && j < m; i++)
			{
				if (shorts[j] == longs[i])
					j++;
			}

			return j == m; // if all characters were found
		}
	}

	[TestFixture]
	public class TestFindLargestStringInDictionary
	{
		[Test]
		public void Test1()
		{
			var dict = new HashSet<string>()
			{
				"ale", "apple", "monkey", "plea"
			};

			var finder = new FindLargestStringInDictionary();
			var largest = finder.Find(dict, "abpcplea");

			Assert.That(largest == "apple");
		}
	}
}
