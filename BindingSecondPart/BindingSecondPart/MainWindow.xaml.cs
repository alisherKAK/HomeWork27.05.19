using BindingSecondPart.DataAccess;
using BindingSecondPart.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BindingSecondPart
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Item> _items { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            using(var context = new ShopContext())
            {
                _items = new ObservableCollection<Item>(context.Items.ToList());
                itemsDataGrid.ItemsSource = _items;
            }
        }

        private void ShowLoading(bool isLoading = true)
        {
            if(isLoading)
            {
                progressBar.Visibility = Visibility.Visible;
                statusTextBlock.Text = "Please wait";
            }
            else
            {
                progressBar.Visibility = Visibility.Collapsed;
                statusTextBlock.Text = "Done";
            }
        }

        private async void CreateItemButtonClick(object sender, RoutedEventArgs e)
        {
            ShowLoading();

            var item = new Item()
            {
                Name = itemNameTextBox.Text,
                Price = int.Parse(itemPriceTextBox.Text),
                Description = new TextRange(itemDescriptionRichTextBox.Document.ContentStart, itemDescriptionRichTextBox.Document.ContentEnd).Text
            };

            _items.Add(item);

            using(var context = new ShopContext())
            {
                context.Items.Add(item);
                await context.SaveChangesAsync();
            }

            ShowLoading(false);
        }

        private void ChangeFirstRowButtonClick(object sender, RoutedEventArgs e)
        {
            var item = _items[0];
            item.Name = "Капуста";
        }
    }
}
