using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace A1_StopWatch {
	class Model {
		readonly Stopwatch stopwatch = new();
		bool _prevstate = false;

		public bool Start() {
			if(stopwatch.IsRunning) {
				stopwatch.Stop();
				return false;
			} else {
				stopwatch.Start();
				return true;
			}
		}
		public void Reset() {
			if(stopwatch.IsRunning)
				stopwatch.Restart();
			else
				stopwatch.Reset();
		}
		public (TimeSpan, bool?) Read() =>
			(stopwatch.Elapsed, stopwatch.IsRunning == _prevstate ? null : (_prevstate = stopwatch.IsRunning));
	}
}
