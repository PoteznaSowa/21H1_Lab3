using System;

namespace A2a_Calculator {
	class Program {
		static void PrintLn(object sender, string text) => Console.WriteLine(text);

		static double GetDouble(string prompt) {
			for(; ; ) {
				Console.Write(prompt);
				string input = Console.ReadLine();
				if(double.TryParse(input, out double result))
					return result;
				Console.WriteLine($"Рядок \"{input}\" не є представленням дійсного числа.");
			}
		}

		static void Main() {
			Console.Title = "Calculator";
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			Presenter presenter = new(PrintLn);

			do {
				double a = GetDouble("a= ");
				double b = GetDouble("b= ");
				presenter.SendInput(a, b);
				Console.WriteLine("Натисніть Enter, щоб вийти, або будь-яку іншу клавішу, щоб продовжити.");
			} while(Console.ReadKey(true).Key != ConsoleKey.Enter);
		}
	}
}
