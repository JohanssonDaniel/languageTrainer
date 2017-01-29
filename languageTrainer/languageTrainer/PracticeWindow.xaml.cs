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
using System.Windows.Shapes;

namespace languageTrainer
{
    /// <summary>
    /// Interaction logic for PracticeWindow.xaml
    /// </summary>
    public partial class PracticeWindow : Window
    {
        const string FILENAME = @"C:\Users\DannePanne\Documents\Arbeten\languageTrainer\languageTrainer\words\words.txt";
        string answer = "";
        Dictionary<string, string> matchedWords = new Dictionary<string, string>();
        public PracticeWindow()
        {
            InitializeComponent();
            openFile();
        }

        private void openFile()
        {
            List<string> fileString = System.IO.File.ReadAllLines(FILENAME).ToList();
            foreach (string line in fileString)
            {
                string[] temp = line.Split('=');
                matchedWords.Add(temp[0].TrimEnd(), temp[1].TrimStart());
            }
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            inputForeignBox.Text = "";
            inputTranslatedBox.Text = "";
            Random rand = new Random();
            if (foreignRadioButton.IsChecked.Value)
            {
                try
                {
                    int i = rand.Next(0, matchedWords.Count);
                    inputForeignBox.Text = matchedWords.ElementAt(i).Key;
                    answer = matchedWords.ElementAt(i).Value;
                }
                catch (ArgumentOutOfRangeException except)
                {
                    Console.WriteLine("No words added to list");
                    throw;
                }
            }
            else if(translatedRadioButton.IsChecked.Value)
            {
                try
                {
                    int i = rand.Next(0, matchedWords.Count);
                    inputTranslatedBox.Text = matchedWords.ElementAt(i).Value;
                    answer = matchedWords.ElementAt(i).Key;
                }
                catch (ArgumentOutOfRangeException except)
                {
                    Console.WriteLine("No words added to list");
                    throw;
                }
                
            }
            else
            {
                MessageBox.Show("No language selected");
            }
        }

        private void foreignRadioButton_Click(object sender, RoutedEventArgs e)
        {
            inputForeignBox.Text = "";
            inputTranslatedBox.Text = "";
            answer = "";
        }

        private void translatedRadioButton_Click(object sender, RoutedEventArgs e)
        {
            inputForeignBox.Text = "";
            inputTranslatedBox.Text = "";
            answer = "";
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            if (foreignRadioButton.IsChecked.Value)
            {
                if (inputTranslatedBox.Text.Equals(answer))
                {
                    MessageBox.Show("Correct answer!");
                }
                else
                {
                    MessageBox.Show("Wrong answer, correct answer is {0}!", answer);
                    Console.WriteLine(answer);
                    Console.WriteLine(inputTranslatedBox.Text);
                }

            }
            else if (translatedRadioButton.IsChecked.Value)
            {
                {
                    if (inputForeignBox.Text.Equals(answer))
                    {
                        MessageBox.Show("Correct answer!");
                    }
                    else
                    {
                        MessageBox.Show("Wrong answer, correct answer is {0}!", answer);
                        Console.WriteLine(answer);
                        Console.WriteLine(inputTranslatedBox.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("No language selected");
            }
        }
    }
}
