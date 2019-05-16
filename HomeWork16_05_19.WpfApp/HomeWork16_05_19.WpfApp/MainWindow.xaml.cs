using MaterialDesignThemes.Wpf;
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
using Newtonsoft.Json;
using HomeWork16_05_19.Models;
using System.Net;

namespace HomeWork16_05_19.WpfApp
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

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (cityNameTextBox.Text == null)
            {
                MessageBox.Show("Введите город");
                return;
            }

            string result;
            using (var client = new WebClient())
            {
                result = client.DownloadString($"http://api.apixu.com/v1/forecast.json?key=59bacc56d0fc4e55bdb144248190605&q={cityNameTextBox.Text}&days=7");
            }
            var forecast = JsonConvert.DeserializeObject<Forecast>(result);
            var cards = cardsGrid.Children.OfType<Card>().ToList();

            foreach(var card in cards)
            {
                var stackPanel = card.Content as StackPanel;
                var textBlocks = stackPanel.Children.OfType<TextBlock>().ToList();
            }
        }
    }
}
