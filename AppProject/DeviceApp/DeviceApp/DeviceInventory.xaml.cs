using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using static DeviceApp.Sorter;

namespace DeviceApp
{
    /// <summary>
    /// Interaction logic for DeviceInventory.xaml
    /// </summary>
    public partial class DeviceInventory : Window
    {
        private Models.DeviceModel selectedDevice;
        private string selectedDeviceType;
        //public string ExitType { get; set; }
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        public DeviceInventory(string ExitType, string selectedType = null)
        {
            InitializeComponent();
            DeviceList(selectedType);
            PopulateFilterMenu();
        }

        #region Click Events

        private void uxAllDevices_Click(object sender, RoutedEventArgs e)
        {
            DeviceList("All");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = "";
            this.Close();
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

        private void Menu1_Click(object sender, RoutedEventArgs e)
        {
            MenuItem obMenuItem = e.OriginalSource as MenuItem;

            var selectedType = obMenuItem.Header.ToString();
            var devices = App.DeviceRepository.GetAll();
            LoadSelectDevices(selectedType, devices);
        }

        private void uxOnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = "Logout";
            this.Close();
        }

        private void TypePage_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = "TypePage";
            this.Close();
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            Sort(sender);
        }

        #endregion

        #region Double Click Envents

        private void uxDeviceList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EditDevice();
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

        #region Change Events

        private void uxDeviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDevice = (Models.DeviceModel)uxDeviceList.SelectedValue;
        }

        #endregion

        #region Window Methods

        private void EditDevice()
        {
            var window = new NewDevice
            {
                Device = selectedDevice.Clone()
            };

            if (window.ShowDialog() == true)
            {
                App.DeviceRepository.Update(window.Device.ToRepositoryModel());
                DeviceList(selectedDeviceType);
            }
        }

        private void LoadDevices(List<Repository.DeviceModel> devices)
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

            List<Models.DeviceModel> deviceList = (from d in selectDevices
                                                   where d.DeviceType == selectedType
                                                   select d).ToList();

            uxDeviceList.ItemsSource = deviceList;
        }

        private void DeviceList(string selectedType)
        {
            selectedDeviceType = selectedType;
            var devices = App.DeviceRepository.GetAll();

            if (selectedType == null || selectedType == "All")
            {
                LoadDevices(devices);
            }
            else
            {
                LoadSelectDevices(selectedType, devices);
            }
        }

        private void Sort(object sender)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                uxDeviceList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            uxDeviceList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        private void PopulateFilterMenu()
        {
            var devices = App.DeviceRepository.GetAll();
            var menuList = devices
                                .Select(t => Models.DeviceModel.ToModel(t).DeviceType)
                                .Distinct()
                                .ToList();

            Menu1.ItemsSource = menuList;
            ContextMenu1.ItemsSource = menuList;
        }
        #endregion
    }
}