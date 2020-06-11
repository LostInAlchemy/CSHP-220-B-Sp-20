using DeviceApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DeviceApp
{
    /// <summary>
    /// Interaction logic for NewDevice.xaml
    /// </summary>
    public partial class NewDevice : Window
    {
        public DeviceModel Device { get; set; }
        public ObservableCollection<string> PowerTypes { get; set; }
        public ObservableCollection<string> DeviceTypes { get; set; }

        public NewDevice()
        {
            InitializeComponent();

            // Don't show this window in the task bar
            ShowInTaskbar = false;

            FillComboBoxTypes();
            FillListBoxAttributes();
            FillComboBoxPowerTypes();
        }

        #region New Device Click Events
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            CommitAttributes();
            TypeComboBoxValue();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }
        #endregion

        #region New Device Window Load Events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Device == null)
            {
                Device = new DeviceModel();
                Device.DeviceAddedDate = DateTime.Now;
            }
            else
            {
                PopulateAttributesList();

                int DeviceTypeIndex = DeviceTypes.IndexOf(Device.DeviceType);
                uxCmbDeviceType.SelectedIndex = DeviceTypeIndex;

                int PowerTypeIndex = PowerTypes.IndexOf(Device.DevicePowerType);
                uxCmbDevicePowerType.SelectedIndex = PowerTypeIndex;
                uxSubmit.Content = "Update";
            }

            //uxGrid_Device.DataContext = Device;

            uxGrid_Attributes.DataContext = Device;
            uxGrid_Cost.DataContext = Device;
            uxGrid_General.DataContext = Device;
            uxGrid_Integration.DataContext = Device;
            uxGrid_Specs.DataContext = Device;










        }
        #endregion

        #region Device Attributes ListBox
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            uxAdd.IsEnabled = false;

            // Get the current selected attribute
            var attribute = (string)uxAttributeList.SelectedValue;

            // Remove the attribute from the list
            var list = (ObservableCollection<string>)uxAttributeList.ItemsSource;
            //var list = (List<string>)uxAttributeList.ItemsSource;
            list.Remove(attribute);

            // Add the attribute to the Device attribute list
            list = (ObservableCollection<string>)uxAddList.ItemsSource;
            //list = (List<string>)uxAddList.ItemsSource;
            list.Add(attribute);
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            uxRemove.IsEnabled = false;

            var attribute = (string)uxAddList.SelectedValue;
            var list = (ObservableCollection<string>)uxAddList.ItemsSource;
            list.Remove(attribute);

            list = (ObservableCollection<string>)uxAttributeList.ItemsSource;
            list.Add(attribute);
        }

        private static void AttributeValues(ObservableCollection<string> Attributes)
        {
            Attributes.Add("Battery Indicator");
            Attributes.Add("Color");
            Attributes.Add("Dimmer");
            Attributes.Add("Hue (light Temperature)");
            Attributes.Add("Humidity");
            Attributes.Add("Light");
            Attributes.Add("Motion");
            Attributes.Add("On/Off indicator");
            Attributes.Add("Position indicator");
            Attributes.Add("Power Consumption");
            Attributes.Add("Temperature");
            Attributes.Add("Tilt");
            Attributes.Add("Vibration");
            Attributes.Add("Repeater");
        }

        private void FillListBoxAttributes()
        {
            var Attributes = new ObservableCollection<string>();

            AttributeValues(Attributes);

            Attributes = new ObservableCollection<string>(Attributes.OrderBy(t => t));

            uxAttributeList.ItemsSource = Attributes;

            // Set uxRemoveList to an empty list
            uxAddList.ItemsSource = new ObservableCollection<string>();
        }

        private void PopulateAttributesList()
        {
            var Attributes = new ObservableCollection<string>();

            AttributeValues(Attributes);

            ObservableCollection<string> DeviceAssignedAttributes = new ObservableCollection<string>();
            var middleMan = Device.DeviceAttributes.Split(", ").ToList();
            foreach (string Attribute in middleMan)
            {
                if (Attribute != string.Empty)
                {
                    DeviceAssignedAttributes.Add(Attribute);
                    Attributes.Remove(Attribute);
                }
            }

            Attributes = new ObservableCollection<string>(Attributes.OrderBy(t => t));
            uxAttributeList.ItemsSource = Attributes;

            DeviceAssignedAttributes = new ObservableCollection<string>(DeviceAssignedAttributes.OrderBy(t => t));
            uxAddList.ItemsSource = DeviceAssignedAttributes;
        }

        private void uxCurrentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Only enable the Delete button if we are selecting items (AddedItems)
            uxAdd.IsEnabled = (e.AddedItems.Count > 0);
        }

        private void uxAddList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            uxRemove.IsEnabled = (e.AddedItems.Count > 0);
        }

        private void CommitAttributes()
        {
            string deviceAttributes = "";
            foreach (string attribute in uxAddList.Items)
            {
                deviceAttributes += attribute + ", ";
            }
            Device.DeviceAttributes = deviceAttributes;
        }
        #endregion

        #region Device Type ComboBox
        private void FillComboBoxTypes()
        {
            var devices = App.TypeRepository.GetAll();

            var middelMan = devices
                            .OrderBy(s => s.TypeType)
                            .GroupBy(t => new { t.TypeType })
                            .Select(u => u.FirstOrDefault())
                            .ToList();

            DeviceTypes = new ObservableCollection<string>();

            foreach(var item in middelMan)
            {
                DeviceTypes.Add(item.TypeType);
            }

            uxCmbDeviceType.ItemsSource = DeviceTypes;
        }
        private void uxCmbDeviceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeComboBoxValue();
        }

        private void TypeComboBoxValue()
        {
            Device.DeviceType = DeviceTypes[uxCmbDeviceType.SelectedIndex];
        }
        #endregion

        #region Device Power Type ComboBox
        private void FillComboBoxPowerTypes()
        {
            PowerTypes = new ObservableCollection<string>();

            PowerTypeValues();

            uxCmbDevicePowerType.ItemsSource = PowerTypes
                                                    .OrderBy(s => s);
                                                    //.Select(u => u)
                                                    //.ToList();
        }

        private void PowerTypeValues()
        {
            PowerTypes.Add("120V Hardwired");
            PowerTypes.Add("120V_Plug-in");
            PowerTypes.Add("Battery_CR-2450");
            PowerTypes.Add("Battery_CR-2477");
            PowerTypes.Add("Battery_AA");
            PowerTypes.Add("Battery_CR-2");
            PowerTypes.Add("Battery_CR-2032");
            PowerTypes.Add("Battery_CR-123A");
        }

        private void uxCmbDevicePowerType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DevicePowerTypeComboBoxValue();
        }

        private void DevicePowerTypeComboBoxValue()
        {
            Device.DevicePowerType = PowerTypes[uxCmbDevicePowerType.SelectedIndex];
        }
        #endregion
    }
}
