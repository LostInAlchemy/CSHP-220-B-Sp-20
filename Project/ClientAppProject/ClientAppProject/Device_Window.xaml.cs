using DeviceApp.Models;
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
    /// Interaction logic for Device_Window.xaml
    /// </summary>
    public partial class Device_Window : Window
    {
        public Device_Window()
        {
            InitializeComponent();

            // Don't show this window in the task bar
            ShowInTaskbar = false;
        }

        public DeviceModel Device { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            Device = new DeviceModel();







            Device.PartNumber = uxPartNumber.Text;
            Device.MfgName = uxMFGName.Text;

            //if (uxMotion.IsChecked.Value)
            //{
            //    Device.Type = "Motion";
            //}
            //else
            //{
            //    Device.Type = "Leak";
            //}

            Device.Type = uxMotion.Text;

            Device.Desc = uxDesc.Text;

            Device.AddedDate = DateTime.Now;

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
    }
}
