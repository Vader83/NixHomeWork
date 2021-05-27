using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NixHW_Philosopher
{
	class Forks
	{
		public Mutex[] ForkArr;

		public Forks(int forkCount)
		{
			ForkArr = new Mutex[forkCount];
			for (int i = 0; i < ForkArr.Length; i++)
			{
				ForkArr[i] = new Mutex();
			}
		}

		public Mutex this[int index]
		{
			get => ForkArr[index];
			set => ForkArr[index] = value;
		}
	}
}
