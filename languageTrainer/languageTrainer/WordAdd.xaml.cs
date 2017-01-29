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
    /// Interaction logic for WordAdd.xaml
    /// </summary>
    public partial class WordAdd : Window
    {
        const string FILENAME = @"C:\Users\DannePanne\Documents\Arbeten\languageTrainer\languageTrainer\words\words.txt";

        public WordAdd()
        {
            InitializeComponent();
            InitializeListBox();
        }
        private void InitializeListBox()
        {
            string[] text = System.IO.File.ReadAllLines(FILENAME);
            listBox.Items.Clear();

            foreach (string line in text)
            {
                listBox.Items.Add(line);
            }
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string text = foreignBox.Text + " = " + translatedBox.Text;

            string[] fileText = System.IO.File.ReadAllLines(FILENAME);

            if (!fileText.Contains(text))
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(FILENAME, true))
                {
                    file.WriteLine(text);
                }
                listBox_AddItem(text);
            }
            else
            {
                MessageBox.Show("Already entered that word");
            }
        }

        private void listBox_AddItem(string text)
        {
            listBox.Items.Add(text);
        }

        private void removeItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string remove = listBox.SelectedItem.ToString();
                System.IO.File.WriteAllLines(FILENAME,
                            System.IO.File.ReadLines(FILENAME).Where(l => l != remove).ToList());
            }
            catch (NullReferenceException except)
            {
                MessageBox.Show("Error: no item selected");
            }
            InitializeListBox();
        }

        private void foreignBox_GotFocus(object sender, RoutedEventArgs e)
        {
            foreignBox.SelectAll();
        }
    }
}
