using NUnit.Framework;
using System;

namespace GeeksForGeeks
{
	[TestFixture]
	class ShortestDistance
	{
		int Calc(string[] words, string w1, string w2)
		{
			int? i1 = null;
			int? i2 = null;

			int min = Int32.MaxValue;
			for(int i=0; i < words.Length; i++)
			{
				if (words[i] == w1) i1 = i;
				else if (words[i] == w2) i2 = i;

				if(i1 != null && i2 != null)
				{
					min = Math.Min(min, Math.Abs(i2.Value - i1.Value));
				}
			}

			return min;
		}

		[Test]
		public void Test1()
		{
			string[] words = new[] { "practice", "makes", "perfect", "job", "int" };
			var res = Calc(words, "int", "makes");

			Assert.That(res, Is.EqualTo(3));
		}
	}
}
