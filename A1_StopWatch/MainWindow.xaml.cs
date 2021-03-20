// Створіть програму (WPF) секундомір. Потрібно виводити показники секундоміра
// у вікні. Вікно має кнопки запуску, зупинки і скидання секундоміра. Необхідно
// використовувати події. Для реалізації секундоміра використовуйте патерн MVP.

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

namespace A1_StopWatch {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow: Window {
		// View component

		readonly Presenter p;

		public MainWindow() {
			InitializeComponent();
			p = new Presenter(UpdateDisplay);
		}

		void StartButton_Click(object sender, RoutedEventArgs e) => p.StartStopwatch();

		void ClearButton_Click(object sender, RoutedEventArgs e) => p.ResetStopwatch();

		void UpdateDisplay(object sender, (TimeSpan time, bool? isrunning) state) {
			StopWatchDisplay.Content = $"{state.time:h\\:mm\\:ss\\,ff}";
			if(state.isrunning != null)
				StartButton.Content = state.isrunning.Value ? "Stop" : "Start";
		}
	}
}
