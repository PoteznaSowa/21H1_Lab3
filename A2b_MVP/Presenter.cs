using System;

namespace MVP {
	class Presenter {
		readonly Model model = new Model();
		readonly MainWindow mainWindow;

		public Presenter(MainWindow mainWindow) {
			this.mainWindow = mainWindow;
			this.mainWindow.MyEvent += MainWindow_myEvent;
		}

		void MainWindow_myEvent(object sender, EventArgs e) =>
			mainWindow.textBox1.Text = model.Logic(mainWindow.textBox1.Text);

		public void RemoveEvent() => mainWindow.MyEvent -= MainWindow_myEvent;
	}
}
