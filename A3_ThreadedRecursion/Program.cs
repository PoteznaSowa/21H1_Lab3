using System;
using System.Threading;

namespace A3_ThreadedRecursion {
	class Program {
		static void Loop(object state) {
			Console.WriteLine($"iteration {state}");
			if(state is int number)
				state = number + 1;
			Thread.Sleep(99);
			ThreadPool.QueueUserWorkItem(Loop, state);
		}

		static void Main() {
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			Loop(0);
			Console.WriteLine("Натисніть Enter, щоб продовжити.");
			while(Console.ReadKey(true).Key != ConsoleKey.Enter) ;
		}
	}
}
