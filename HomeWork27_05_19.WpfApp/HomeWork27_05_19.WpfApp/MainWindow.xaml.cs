using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace HomeWork27_05_19.WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrintButtonClick(object sender, RoutedEventArgs e)
        {

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(
                    ((IDocumentPaginatorSource)document.Document).DocumentPaginator, "");
            }
        }
    }
}
