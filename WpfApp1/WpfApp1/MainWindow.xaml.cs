using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileInfo fi = new FileInfo("personen.txt");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (firstNameTextBox.Text.Length > 0 && lastNameTextBox.Text.Length > 0)
            {
                firstNameListBox.Items.Add(firstNameTextBox.Text);
                lastNameListBox.Items.Add(lastNameTextBox.Text);
                firstNameTextBox.Clear();
                lastNameTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Vul beide naamvelden in!");
            }
        }

        private void readFileButton_Click(object sender, RoutedEventArgs e)
        {
            firstNameListBox.Items.Clear();
            lastNameListBox.Items.Clear();

            using (StreamReader sr = fi.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    string[] nameSplit = sr.ReadLine().Split();
                    firstNameListBox.Items.Add(nameSplit[0]);
                    lastNameListBox.Items.Add(nameSplit[1]);
                }
            }
        }

        private void saveFileButton_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = fi.CreateText())
            {
                for (int i = 0; i < firstNameListBox.Items.Count; i++)
                {
                    sw.WriteLine(firstNameListBox.Items[i] + " " + lastNameListBox.Items[i]);
                }
            }

            firstNameListBox.Items.Clear();
            lastNameListBox.Items.Clear();
        }
    }
}