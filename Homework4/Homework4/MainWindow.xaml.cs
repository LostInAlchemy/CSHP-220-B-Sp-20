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
        private bool _match = false;
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
            ZipCodeValidation validation = new ZipCodeValidation();

            if (uxZipcode.Text != string.Empty)
            {
                if (validation.ZipCodeVal(uxZipcode.Text.ToString()))
                    {
                    uxSubmit.IsEnabled = true;
                    _match = true;
                }
                else
                {
                    _match = false;
                    uxSubmit.IsEnabled = false;
                }
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }

        private void uxSubmit_Click()
        {
            if (_match)
            {
                MessageBox.Show(uxZipcode.Text + Constants.message1, Constants.titleMsg1, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(uxZipcode.Text + Constants.message2, Constants.titleMsg2, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            uxZipcode.Text = string.Empty;
            uxZipcode.Focus();
        }
    }
}
