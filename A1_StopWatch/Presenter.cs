using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace A1_StopWatch {
	class Presenter {
		readonly Model model = new();
		event EventHandler<(TimeSpan, bool?)> Update;
		readonly DispatcherTimer timer = new();

		public Presenter(EventHandler<(TimeSpan, bool?)> updateevent) {
			Update = updateevent;
			UpdateStopwatch(this, null);

			timer.Interval = new TimeSpan(100000);

			timer.Tick += UpdateStopwatch;
		}

		public void StartStopwatch() {
			timer.IsEnabled = model.Start();
			UpdateStopwatch(this, null);
		}

		public void ResetStopwatch() {
			model.Reset();
			UpdateStopwatch(this, null);
		}

		void UpdateStopwatch(object sender, EventArgs e) => Update?.Invoke(this, model.Read());
	}
}
