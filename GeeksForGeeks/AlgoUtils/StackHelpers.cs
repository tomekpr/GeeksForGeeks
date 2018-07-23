using System;
using System.Collections.Generic;

namespace GeeksForGeeks.AlgoUtils
{
	class StackHelpers
	{
		public static bool CompareStacks<T>(Stack<T> actual, Stack<T> expected) where T : struct, System.IComparable<T>
		{
			if (actual.Count != expected.Count)
			{
				Console.WriteLine($"Expected: {expected.Count} elements but got: {actual.Count}");
				return false;
			}

			while (expected.Count > 0)
			{
				var act = actual.Pop();
				var exp = expected.Pop();

				if (act.CompareTo(exp) != 0)
				{
					Console.WriteLine($"{act} and {exp} dont equal");
					return false;
				}
			}

			return true;
		}
	}
}
