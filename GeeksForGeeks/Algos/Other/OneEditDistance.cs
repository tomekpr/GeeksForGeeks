using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	[TestFixture]
	class OneEditDistance
	{
		bool IsOneEditDistanceApart(string s1, string s2)
		{
			int m = s1.Length;
			int n = s2.Length;

			// If difference between lengths is 
			// more than 1, then strings can't 
			// be at one distance
			if (Math.Abs(m - n) > 1)
				return false;

			// Count of edits
			int count = 0;
			int i = 0, j = 0;

			while (i < m && j < n)
			{
				// If current characters 
				// don't match
				if (s1[i] != s2[j])
				{
					if (count == 1)
						return false;

					// If length of one string is
					// more, then only possible edit
					// is to remove a character
					if (m > n)
						i++;
					else if (m < n)
						j++;

					// If lengths of both 
					// strings is same
					else
					{
						i++;
						j++;
					}

					// Increment count of edits 
					count++;
				}

				// If current characters match
				else
				{
					i++;
					j++;
				}
			}

			// If last character is extra 
			// in any string
			if (i < m || j < n)
				count++;

			return count == 1;
		}

		[Test]
		public void Test1()
		{
			var result = IsOneEditDistanceApart("geeks", "geek");
			Assert.That(result, Is.True);
		}

		[Test]
		public void Test2()
		{
			var result = IsOneEditDistanceApart("peaks", "geeks");
			Assert.That(result, Is.False);
		}

		[Test]
		public void Test3()
		{
			var result = IsOneEditDistanceApart("a", "");
			Assert.That(result, Is.True);
		}

		[Test]
		public void Test4()
		{
			var result = IsOneEditDistanceApart("aaaaaaaaa", "aaaaaa   ");
			Assert.That(result, Is.False);
		}
	}
}
