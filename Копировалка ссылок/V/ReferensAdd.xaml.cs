using System.Windows;
using System.Windows.Controls;

namespace Копировалка_ссылок.V
{
    /// <summary>
    /// Логика взаимодействия для ReferensAdd.xaml
    /// </summary>
    public partial class ReferensAdd : UserControl
    {
        public ReferensAdd() {
            InitializeComponent();
        }

        private void AddBut_Click(object sender, RoutedEventArgs e) {
            if(addTB.Text != null && addTB.Text != "") {
                FileWorker worker = new FileWorker();
                worker.WriteFile(addTB.Text);
                addTB.Text = "";
            }
        }
    }
}
