using System.Windows;
using System.Windows.Controls;

namespace Копировалка_ссылок.V
{
    /// <summary>
    /// Логика взаимодействия для ReferensList.xaml
    /// </summary>
    public partial class ReferensList : UserControl
    {
        public ReferensList()
        {
            InitializeComponent();
            ShowReferenses();
        }

        void ShowReferenses() {
            FileWorker worker = new FileWorker();
            string[] referenses = worker.ReadFile();
            if(referenses != null)
                foreach (var item in referenses) {
                    TextBlock block = new TextBlock { Text = item };
                    block.MouseLeftButtonUp += (s, e) => CopyMethod(block);
                    block.MouseRightButtonUp += (s, e) => DeleteReferens(s);
                    referensSP.Children.Add(block);
                }
        }

        void CopyMethod(TextBlock txt) {
            if(playCopyCB.IsChecked == true) 
                Clipboard.SetText($"+play {txt.Text}");
            else
                Clipboard.SetText(txt.Text);
        }

        void DeleteReferens(object sender) {
            if (rmcCB.IsChecked == true) {
                TextBlock block = sender as TextBlock;
                int SPlenght = referensSP.Children.Count - 1;
                for(int i = SPlenght; i >= 0; i--) {
                    if (referensSP.Children[i] == block) {
                        FileWorker worker = new FileWorker();
                        worker.DeleteReferens(block.Text);
                    }
                    referensSP.Children.RemoveAt(i);
                }
                ShowReferenses();
            }
        }
    }
}
