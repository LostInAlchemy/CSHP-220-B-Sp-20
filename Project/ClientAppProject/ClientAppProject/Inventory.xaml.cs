using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientAppProject
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Window
    {
        public bool IsClosed { get; private set; }

        public Inventory()
        {
            InitializeComponent();
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new Device_Window();

            if (window.ShowDialog() == true)
            {
                var uiDeviceModel = window.Device;

                var repositoryDeviceModel = uiDeviceModel.ToRepositoryModel();

                App.DeviceRepository.Add(repositoryDeviceModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());
            }
        }

        private void uxOnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            base.OnClosed(e);
            IsClosed = true;

 
        }
    }
}
