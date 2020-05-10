using System.IO;
using System.Windows;
using Копировалка_ссылок.VM;

namespace Копировалка_ссылок
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FileStream fileStream;
        public MainWindow() {
            InitializeComponent();
            FileWorker worker = new FileWorker();
            worker.CheckDirectory();
        }

        private void ReferensList_Selected(object sender, RoutedEventArgs e) {
            Application.Current.MainWindow.DataContext = new ReferensListVM();
        }

        private void ReferensAdd_Selected(object sender, RoutedEventArgs e) {
            Application.Current.MainWindow.DataContext = new ReferensAddVM();
        }
    }
}
