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

			// Виставити інтервал таймера у 10 мс.
			timer.Interval = new TimeSpan(100000);

			timer.Tick += UpdateStopwatch;
		}

		// Запустити або зупинити секундомір.
		public void StartStopwatch() {
			timer.IsEnabled = model.Start();
			UpdateStopwatch(this, null);
		}

		// Обнулити секундомір.
		public void ResetStopwatch() {
			model.Reset();
			UpdateStopwatch(this, null);
		}

		// Отримати поточні показники секундоміра та повідомити компонент View.
		void UpdateStopwatch(object sender, EventArgs e) => Update?.Invoke(this, model.Read());
	}
}
