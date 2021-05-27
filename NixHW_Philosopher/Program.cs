using System;
using System.Threading;

namespace NixHW_Philosopher
{
	class Program
	{
		public static Forks PhilosophersForks = new Forks(forkCount:5);
		public static Mutex consoleMutex = new Mutex();

		public static Philosopher[] Philosophers = new Philosopher[5];
		public static Waiter PhilosophersWaiter = new Waiter("Alfred", PhilosophersForks);

		static void Main(string[] args)
		{
			Philosophers[0] = new Philosopher("Aristotle",	PhilosophersWaiter, consoleMutex, PhilosophersForks[4], PhilosophersForks[0]);
			Philosophers[1] = new Philosopher("Plato", PhilosophersWaiter, consoleMutex, PhilosophersForks[0], PhilosophersForks[1]);
			Philosophers[2] = new Philosopher("Nietzsche", PhilosophersWaiter, consoleMutex, PhilosophersForks[1], PhilosophersForks[2]);
			Philosophers[3] = new Philosopher("Descartes", PhilosophersWaiter, consoleMutex, PhilosophersForks[2], PhilosophersForks[3]);
			Philosophers[4] = new Philosopher("Freud", PhilosophersWaiter, consoleMutex, PhilosophersForks[3], PhilosophersForks[4]);

			foreach (var philosophersThread in Philosophers)
			{
				philosophersThread.Live();
			}
			foreach (var philosophersThread in Philosophers)
			{
				philosophersThread.Die();
			}
		}
	}
}
