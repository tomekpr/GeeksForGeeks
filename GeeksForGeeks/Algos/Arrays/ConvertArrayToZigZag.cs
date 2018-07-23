using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	class ConvertArrayToZigZag
	{
		public void Convert(int[] arr)
		{
			bool odd = true;
			for(int i=1; i < arr.Length; i++)
			{
				if(odd)
				{
					if(arr[i-1] > arr[i])
					{
						Swap(arr, i - 1, i);
					}

					odd = false;
				}
				else
				{
					if (arr[i - 1] < arr[i])
						Swap(arr, i - 1, i);

					odd = true;
				}
			}
		}

		void Swap(int[] arr, int i, int j)
		{
			var tmp = arr[i];
			arr[i] = arr[j];
			arr[j] = tmp;
		}
	}

	[TestFixture]
	public class TestConvertToZigZag
	{
		[Test]
		public void Test()
		{
			var c = new ConvertArrayToZigZag();

			var arr = new int[] { 1, 4, 3, 2 };
			var exp = new int[] { 1, 4, 2, 3 };

			c.Convert(arr);

			Assert.That(arr.SequenceEqual(exp), Is.True);
		}

		[Test]
		public void Test2()
		{
			var c = new ConvertArrayToZigZag();

			var arr = new int[] { 4, 3, 7, 8, 6, 2, 1 };
			var exp = new int[] { 3, 7, 4, 8, 2, 6, 1 };

			c.Convert(arr);

			Assert.That(arr.SequenceEqual(exp), Is.True);
		}
	}
}
