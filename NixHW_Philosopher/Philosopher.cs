using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NixHW_Philosopher
{
	class Philosopher
	{
		public string Name { get; set; }
		public Mutex LeftHand;
		public Mutex RightHand;
		public Thread PhilosopherLife;

		private Mutex _consoleMutex;
		private Waiter _waiter;

		public Philosopher(string name, Waiter waiter, Mutex consoleMutex, Mutex leftHand, Mutex rightHand)
		{
			this.Name = name;
			this.LeftHand = leftHand;
			this.RightHand = rightHand;
			this._waiter = waiter;

			this._consoleMutex = consoleMutex;
			this.PhilosopherLife = new Thread(this.SitAtTable);
		}

		private bool AskPermission()
		{
			_consoleMutex.WaitOne();
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine($"{this.Name}: Sir, {this._waiter.Name}, may i eat?");
			Console.ForegroundColor = ConsoleColor.White;
			_consoleMutex.ReleaseMutex();

			return this._waiter.CheckForkAccess(this);
		}

		public void Live()
		{
			this.PhilosopherLife.Start();
		}

		public void Die()
		{
			this.PhilosopherLife.Join();
		}

		private void SitAtTable()
		{
			while (true)
			{
				this.Think();
				while (!this.AskPermission())
				{
					_consoleMutex.WaitOne();
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine($"{this._waiter.Name}: Nope, {this.Name}, wait for your turn, please.");
					Console.ForegroundColor = ConsoleColor.White;
					_consoleMutex.ReleaseMutex();
					Thread.Sleep(1000);
				}
				_consoleMutex.WaitOne();
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"{this._waiter.Name}: Yea, {this.Name}, enjoy your meal.");
				Console.ForegroundColor = ConsoleColor.White;
				_consoleMutex.ReleaseMutex();
				this.Eat();
			}
		}

		private void Think()
		{
			_consoleMutex.WaitOne();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"{this.Name}: 'I`m thinking'");
			Console.ForegroundColor = ConsoleColor.White;
			_consoleMutex.ReleaseMutex();

			Thread.Sleep(10000);

			_consoleMutex.WaitOne();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"{this.Name}: 'I`m done! I want to eat'");
			Console.ForegroundColor = ConsoleColor.White;
			_consoleMutex.ReleaseMutex();

		}

		private void Eat()
		{
			TakeForks();

			_consoleMutex.WaitOne();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"{this.Name}: I`m eating");
			Console.ForegroundColor = ConsoleColor.White;
			_consoleMutex.ReleaseMutex();

			Thread.Sleep(5000);

			_consoleMutex.WaitOne();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"{this.Name}: I`m finished!!");
			Console.ForegroundColor = ConsoleColor.White;
			_consoleMutex.ReleaseMutex();

			PutForks();
		}


		#region forks stuff

		private void TakeForks()
		{
			TakeLeftFork();
			Thread.Sleep(1000);
			TakeRightFork();

		}

		private void TakeLeftFork()
		{
			this.LeftHand.WaitOne();

			_consoleMutex.WaitOne();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"{this.Name} takes left fork");
			Console.ForegroundColor = ConsoleColor.White;
			_consoleMutex.ReleaseMutex();
		}

		private void TakeRightFork()
		{
			this.RightHand.WaitOne();

			_consoleMutex.WaitOne();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"{this.Name} takes right fork");
			Console.ForegroundColor = ConsoleColor.White;
			_consoleMutex.ReleaseMutex();
		}


		private void PutForks()
		{
			PutRightFork();
			PutLeftFork();
			this._waiter.SetFreeForks(RightHand, LeftHand);
		}

		private void PutLeftFork()
		{
			this.LeftHand.ReleaseMutex();

			_consoleMutex.WaitOne();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"{this.Name} has puts left fork");
			Console.ForegroundColor = ConsoleColor.White;
			_consoleMutex.ReleaseMutex();
		}

		private void PutRightFork()
		{
			this.RightHand.ReleaseMutex();

			_consoleMutex.WaitOne();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"{this.Name} has puts right fork");
			Console.ForegroundColor = ConsoleColor.White;
			_consoleMutex.ReleaseMutex();
		}

		#endregion
	}
}
