using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2a_Calculator {
	class Presenter {
		event EventHandler<string> OutputEvent;

		public Presenter(EventHandler<string> outputevent) {
			OutputEvent = outputevent;
		}

		public void SendInput(double a, double b) {
			double[] results = Model.Calculate(a, b);
			OutputEvent?.Invoke(this, $"a+b= {results[0]:G16}");
			OutputEvent?.Invoke(this, $"a-b= {results[1]:G16}");
			OutputEvent?.Invoke(this, $"a*b= {results[2]:G16}");
			OutputEvent?.Invoke(this, $"a/b= {(b is 0.0 or (-0.0) ? "(Помилка ділення на нуль)" : results[3]):G16}");
		}
	}
}
