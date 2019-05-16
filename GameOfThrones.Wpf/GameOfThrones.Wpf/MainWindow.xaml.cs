using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Configuration;
using Newtonsoft.Json;
using GameOfThrones.Models;
using GameOfThrones.Wpf;

namespace GameOfThrones.WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Character> _characters;

        public MainWindow()
        {
            InitializeComponent();

            string result = string.Empty;
            using (var client = new WebClient())
            {
                result = client.DownloadString("https://api.got.show/api/book/characters");
            }
            _characters = JsonConvert.DeserializeObject<List<Character>>(result);
            charactersListBox.ItemsSource = _characters;
        }

        private void CharacterNameTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            charactersListBox.ItemsSource = _characters.Where(character => character.Name.ToLower().StartsWith(characterNameTextBox.Text.ToLower()));
        }

        private void CharactersListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CharacterDescription characterDescriptionWindow = new CharacterDescription();
            characterDescriptionWindow.SetCharacter(charactersListBox.SelectedItem as Character);
            characterDescriptionWindow.ShowDialog();
        }
    }
}