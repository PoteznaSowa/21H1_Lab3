using System;
using System.Windows;
using System.ComponentModel;

// View

namespace MVP {
	public partial class MainWindow: Window {
		public MainWindow() {
			InitializeComponent();
			p = new Presenter(this);
		}

		readonly Presenter p;
		event EventHandler MyEvent1;

		public event EventHandler MyEvent {
			add {
				MyEvent1 += value;
				MessageBox.Show("MyEvent add");
			}
			remove {
				MyEvent1 -= value;
				MessageBox.Show("MyEvent remove");
			}
		}

		void Button1_Click(object sender, RoutedEventArgs e) => MyEvent1?.Invoke(sender, e);
		void Window_Closing(object sender, CancelEventArgs e) => p.RemoveEvent();
	}
}
