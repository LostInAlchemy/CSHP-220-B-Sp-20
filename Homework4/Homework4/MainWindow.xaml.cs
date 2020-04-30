using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmitAvailable();
            uxZipcode.Focus();
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            uxSubmit_Click();
        }

        private void uxSubmitAvailable(object sender, TextChangedEventArgs e)
        {
            uxSubmitAvailable();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                uxSubmit_Click();
            }
        }

        private void uxSubmitAvailable()
        {
            if (uxZipcode.Text != string.Empty)
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }

        private void uxSubmit_Click()
        {
            ZipCodeValidation validation = new ZipCodeValidation();

            validation.ZipCodeVal(uxZipcode.Text.ToString());

            uxZipcode.Text = string.Empty;
            uxZipcode.Focus();
        }
    }
}
