using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2a_Calculator {
	class Model {
		public static double[] Calculate(double a, double b) => new[] {
			a + b,
			a - b,
			a * b,
			a / b
		};
	}
}
