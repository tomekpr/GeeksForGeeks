using System;
using System.Collections.Generic;

namespace GeeksForGeeks.AlgoUtils
{
	public class Collections
	{
		public static void Swap(int[] arr, int a, int b)
		{
			var tmp = arr[a];
			arr[a] = arr[b];
			arr[b] = tmp;
		}

		public static void Swap(ref int a, ref int b)
		{
			var tmp = a;
			a = b;
			b = tmp;
		}

		public static bool CompareStacks<T>(Stack<T> actual, Stack<T> expected) where T : struct, System.IComparable<T>
		{
			return StackHelpers.CompareStacks(actual, expected);
		}
	}
}
