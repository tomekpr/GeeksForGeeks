using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks
{
	public class MoveZerosImpl
	{
		public void Move(int[] arr)
		{
			int ri = 0;
			int wi = 0;

			while(ri < arr.Length)
			{
				int val = arr[ri];
				if(val != 0)
				{
					arr[wi] = val;
					wi++;
				}

				ri++;
			}

			while (wi < arr.Length)
				arr[wi++] = 0;
		}
	}

	[TestFixture]
	public class TestMoveZerosImpl
	{
		[Test]
		public void Test1()
		{
			var input = new int[] { 3, 4, 0, 2, -5, 0, 12, 0, 5 };
			var impl = new MoveZerosImpl();
			impl.Move(input);

			Assert.That(input.SequenceEqual(new int[] { 3, 4, 2, -5, 12, 5, 0, 0, 0 }), Is.True);
		}
	}
}
