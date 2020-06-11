using System.Windows;

namespace DeviceApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ExitType { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //this = Application.MainWindow;
        }

        private void uxClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            var windownTypeInv = new TypeInventory(ExitType);
            windownTypeInv.DataContext = this;
            windownTypeInv.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //windownTypeInv.Topmost = true;

            windownTypeInv.ShowDialog();
            _ = App.Current.Windows;
            ExitEvent(windownTypeInv);
            
        }

        private void ExitEvent(TypeInventory windownTypeInv)
        {
            if (windownTypeInv.DataContext.ToString() == "Logout")
            {
                this.Visibility = Visibility.Visible;
            }
            else if (windownTypeInv.DataContext.ToString() == "Exit")
            {
            Application.Current.Shutdown();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ = App.Current.Windows;
            MessageBox.Show("THis Sucks");
        }
    }
}
