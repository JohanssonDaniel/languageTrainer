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

namespace languageTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WordAdd wa = new WordAdd();
            wa.ShowDialog();
            this.Close();
        }

        private void practiceButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PracticeWindow pw = new PracticeWindow();
            pw.ShowDialog();
            this.Close();
        }
    }
}
