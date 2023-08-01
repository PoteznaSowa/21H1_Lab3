using System;
using System.Threading;

namespace A4_DigitalRain {
	class Program {
		static void CancelKey(object sender, ConsoleCancelEventArgs e) {
			_exit = true;
			e.Cancel = true;
		}

		static bool _exit = false;

		static void Main() {
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			Console.Title = "DigitalRain";

			int topedge = Console.CursorTop;
			Console.BackgroundColor = ConsoleColor.Black;
			for(int i = 1; i < Console.WindowHeight; i++)
				Console.WriteLine();
			int bottomedge = Console.CursorTop;
			Console.CursorVisible = false;
			Random random = new();

			(FallingCharChain obj, int x, int y)[] chains = new (FallingCharChain, int, int)[2];

			Console.CancelKeyPress += CancelKey;

			do {
				for(int i = 0; i < chains.Length; i++) {
					if(chains[i].obj == null) {
						chains[i].obj = new FallingCharChain(Console.WindowHeight);
						chains[i].x = random.Next(Console.WindowWidth);
						chains[i].y = 0;
					}

					bool despawn = true;
					int x = chains[i].x;
					int y = chains[i].y;

					for(int j = 0; j <= y; j++) {
						if(topedge + y - j >= bottomedge)
							continue;

						(char symbol, ConsoleColor color) = chains[i].obj.PeekAt(j);
						Console.SetCursorPosition(x, y + topedge - j);
						Console.ForegroundColor = color;
						Console.Write(symbol);
						Console.SetCursorPosition(0, bottomedge);

						if(symbol == ' ')
							break;
						despawn = false;
					}

					if(despawn)
						chains[i].obj = null;
					else
						chains[i].y++;
				}

				Thread.Sleep(17);

			} while(!_exit && (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape));

			Console.ResetColor();
			Console.CursorVisible = true;
		}
	}
}
