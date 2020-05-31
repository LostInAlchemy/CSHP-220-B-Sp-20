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
            windownTypeInv.ShowDialog();

            ExitEvent(windownTypeInv);
        }

        private void ExitEvent(TypeInventory windownTypeInv)
        {
            try
            {
                if ((string)windownTypeInv.DataContext == "Logout")
                {
                    this.Visibility = Visibility.Visible;
                }
                else
                {
                    this.Close();
                }
            }
            catch
            {
                this.Close();
            }
        }
    }
}
