using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DeviceApp
{
    /// <summary>
    /// Interaction logic for DeviceInventory.xaml
    /// </summary>
    public partial class DeviceInventory : Window
    {
        private Models.DeviceModel selectedDevice;
        private string selectedDeviceType;

        public DeviceInventory(string ExitType, string selectedType = null)
        {
            InitializeComponent();
            DeviceList(selectedType);
        }

        #region Click Events
        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewDevice();

            if (window.ShowDialog() == true)
            {
                var uiDeviceModel = window.Device;
                var repositoryDeviceModel = uiDeviceModel.ToRepositoryModel();

                App.DeviceRepository.Add(repositoryDeviceModel);
                DeviceList(selectedDeviceType);
            }
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            EditDevice();
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.DeviceRepository.Remove(selectedDevice.DeviceInventoryId);
            selectedDevice = null;
            DeviceList(selectedDeviceType);
        }

        private void uxOnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void uxDeviceList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EditDevice();
        }
        
        private void uxAllDevices_Click(object sender, RoutedEventArgs e)
        {
            DeviceList("All");
        }
        #endregion

        #region Load Events
        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedDevice != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedDevice != null);
            uxContextFileDelete.IsEnabled = uxFileDelete.IsEnabled;
        }

        #endregion

        #region Window Events

        private void uxDeviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDevice = (Models.DeviceModel)uxDeviceList.SelectedValue;
        }

        #endregion

        #region Windown Methods

        private void DeviceList(string selectedType)
        {
            selectedDeviceType = selectedType;
            var devices = App.DeviceRepository.GetAll();

            if (selectedType == null)
            {
                LoadDevices(devices);
            }
            else if (selectedType == "All")
            {
                LoadDevices(devices);
            }
            else
            {
                LoadSelectDevices(selectedType, devices);
            }
        }

        private void LoadDevices(List<Repository.DeviceModel> devices)
        {
            DeviceLoad(devices);
        }

        private void DeviceLoad(List<Repository.DeviceModel> devices)
        {
            uxDeviceList.ItemsSource = devices
                                       .Select(t => Models.DeviceModel.ToModel(t))
                                       .ToList();
        }

        private void LoadSelectDevices(string selectedType, List<Repository.DeviceModel> devices)
        {
            var selectDevices = devices
                                .Select(t => Models.DeviceModel.ToModel(t))
                                .ToList();

            uxDeviceList.ItemsSource = (from d in selectDevices
                                        where d.DeviceType == selectedType
                                        select d)
                                       .ToList();
        }

        private void EditDevice()
        {
            var window = new NewDevice();
            window.Device = selectedDevice.Clone();

            if (window.ShowDialog() == true)
            {
                App.DeviceRepository.Update(window.Device.ToRepositoryModel());
                DeviceList(selectedDeviceType);
            }
        }

        #endregion
    }
}