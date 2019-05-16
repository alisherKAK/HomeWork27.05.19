using GameOfThrones.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GameOfThrones.Wpf
{
    /// <summary>
    /// Логика взаимодействия для CharacterDescription.xaml
    /// </summary>
    public partial class CharacterDescription : Window
    {
        public CharacterDescription()
        {
            InitializeComponent();
        }

        public void SetCharacter(Character character)
        {
            if (!string.IsNullOrEmpty(character.Image))
            {
                characterImage.Source = new BitmapImage(new Uri(character.Image));
            }
            nameTextBlock.Text = $"Name: {character.Name}";
            genderTextBlock.Text = $"Gender: {character.Gender}";
            houseTextBlock.Text = $"House: {character.House}";
            isAliveTextBlock.Text = $"Is Alive: {character.Alive}";
            birthDateTextBlock.Text = $"Birth Date: {character.Birth} y";
            deathDateTextBlock.Text = $"Death Date: {character.Death}";
            placeOfBirthTextBlock.Text = $"Place of birth: {character.PlaceOfBirth}";
            placeOfDeathTextBlock.Text = $"Place of death: {character.PlaceOfDeath}";
            for (int i = 0; i < character.Titles.Count; i++)
            {
                titelsStackPanel.Children.Add(new TextBlock() { Text = $"   {character.Titles[i]}", FontSize = nameTextBlock.FontSize, Foreground = nameTextBlock.Foreground, FontFamily = nameTextBlock.FontFamily });
            }
            for (int i = 0; i < character.Books.Count; i++)
            {
                booksStackPanel.Children.Add(new TextBlock() { Text = $"    {character.Books[i]}", FontSize = nameTextBlock.FontSize, Foreground = nameTextBlock.Foreground, FontFamily = nameTextBlock.FontFamily });
            }
        }
    }
}
