using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NixHW_Philosopher
{
	class Waiter
	{
		private readonly Mutex _askPermission;
		private readonly Forks _forks;

		private ConcurrentQueue<Philosopher> _carterQueue;

		private Dictionary<Mutex, bool> _forksIsFree;

		public string Name { get; set; }

		public Waiter(string name, Forks forks)
		{
			this.Name = name;
			this._forks = forks;
			this._askPermission = new Mutex();

			this._carterQueue = new ConcurrentQueue<Philosopher>();
			this._forksIsFree = new Dictionary<Mutex, bool>();
			foreach (var mutex in _forks.ForkArr)
			{
				_forksIsFree[mutex] = true;
			}
		}

		public void SetFreeForks(Mutex fork1, Mutex fork2)
		{
			_forksIsFree[fork1] = true;
			_forksIsFree[fork2] = true;
		}

		public bool CheckForkAccess(Philosopher philosopher)
		{
			_askPermission.WaitOne();

			_carterQueue.TryPeek(out Philosopher firstInQueue);
			bool isInQueue = _carterQueue.Contains(philosopher);

			bool isForkFree1 = _forksIsFree[philosopher.LeftHand];
			bool isForkFree2 = _forksIsFree[philosopher.RightHand];
			if (isForkFree1 && isForkFree2 && 
			    (firstInQueue == null || !isInQueue || firstInQueue == philosopher))
			{
				_carterQueue.TryDequeue(out firstInQueue);
				_forksIsFree[philosopher.LeftHand] = false;
				_forksIsFree[philosopher.RightHand] = false;
			}
			else if (isInQueue)
			{
				
			}
			else
			{
				_carterQueue.Enqueue(philosopher);
			}
			_askPermission.ReleaseMutex();
			return isForkFree1 && isForkFree2;
		}
	}
}
