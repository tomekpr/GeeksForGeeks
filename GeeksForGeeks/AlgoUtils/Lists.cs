using GeeksForGeeks.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.AlgoUtils
{
	public static class Lists
	{
		public static bool AreSingleListsEqual(SNode actual, SNode expected)
		{
			var actualList = AlgoUtilities.Utilities.ToList(actual);
			var expList = AlgoUtilities.Utilities.ToList(expected);

			return actualList.SequenceEqual(expList);
		}
	}
}
