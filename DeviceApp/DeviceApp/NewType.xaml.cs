using DeviceApp.Models;
using System;
using System.Windows;

namespace DeviceApp
{
    /// <summary>
    /// Interaction logic for NewType.xaml
    /// </summary>
    public partial class NewType : Window
    {
        public NewType()
        {
            InitializeComponent();

            // Don't show this window in the task bar
            ShowInTaskbar = false;
        }

        public TypeModel Type { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Type == null)
            {
                Type = new TypeModel();
                Type.TypeAddedDate = DateTime.Now;
            }

            uxGrid_Type.DataContext = Type;
        }
    }
}
