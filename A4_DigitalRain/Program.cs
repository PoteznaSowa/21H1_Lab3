// Створіть програму, яка буде виводити на екран ланцюжка падаючих символів.
// Довжина кожного ланцюжка задається випадково.
// Перший символ ланцюжка - білий, другий символ - світло-зелений,
// інші символи темно-зелені.
// Під час падіння ланцюжка, на кожному кроці,
// все символи змінюють своє значення.
// Дійшовши до кінця, ланцюжок зникає і зверху формується новий ланцюжок.

// Розширити завдання 4, так,
// щоб в одному стовпці одночасно могло бути два ланцюжки символів.

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

			// Завершення програми за допомогою Ctrl+C призведе до
			// невизначеного стану консолі/терміналу,
			// тому нам треба перехоплювати цю комбінацію, щоб ми
			// мали можливість відновити попередні налаштування.
			Console.CancelKeyPress += CancelKey;

			// Показувати "цифровий дощ" на екрані,
			// поки користувач не захоче закінчити програму.
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

					// Малювати ланцюжок на екрані.
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

				Thread.Sleep(17);  // Чекати не менше, ніж 1000/60=16,67 мілісекунд.

				// Кожен раз перевіряти, якщо треба вийти з програми.
			} while(!_exit && (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape));

			Console.ResetColor();
			Console.CursorVisible = true;
		}
	}
}
