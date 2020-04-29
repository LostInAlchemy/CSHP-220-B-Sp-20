using System.Windows;
using System.Windows.Controls;

namespace HelloWorld
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

            //this.WindowState = WindowState.Maximized;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password:" + uxPassword.Text);
            uxName.Text = string.Empty;
            uxPassword.Text = string.Empty;

            SecondWindow secondWindow = new SecondWindow();
            secondWindow.Show();
        }

        private void uxSubmitAvailable()
        {
            if (uxName.Text != string.Empty && uxPassword.Text != string.Empty)
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }

        private void uxSubmitAvailable(object sender, TextChangedEventArgs e)
        {
            uxSubmitAvailable();
        }
    }
}
