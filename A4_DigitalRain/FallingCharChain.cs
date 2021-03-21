using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4_DigitalRain {
	class FallingCharChain {
		static readonly Random random = new();
		readonly int _length;

		public FallingCharChain(int maxlength) {
			_length = 1 + random.Next(maxlength);
		}

		public (char, ConsoleColor) PeekAt(int position) {
			if(position >= _length)
				return (' ', ConsoleColor.Black);
			ConsoleColor color = position switch {
				0 => ConsoleColor.White,
				1 => ConsoleColor.Green,
				_ => ConsoleColor.DarkGreen,
			};
			char sym;
			do {
				sym = (char)random.Next(33, 1424);
				// Перевірити, щоб не було керуючих символів,
				// інакше на екрані з'являтимуться поодинокі символи.
			} while(char.IsControl(sym));
			return (sym, color);
		}
	}
}
