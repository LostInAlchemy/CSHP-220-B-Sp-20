﻿using DeviceApp.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DeviceApp
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class TypeInventory : Window
    {
        public string ExitType { get; set; }
        private static TypeModel selectedType;

        public TypeInventory(string ExitType)
        {
            InitializeComponent();
            LoadTypes();
        }

        #region Click Events

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewType();

            if (window.ShowDialog() == true)
            {
                var uiTypeModel = window.Type;
                var repositoryTypeModel = uiTypeModel.ToRepositoryModel();

                App.TypeRepository.Add(repositoryTypeModel);
                LoadTypes();
            }
        }

        private void uxOpenDevices_Click(object sender, RoutedEventArgs e)
        {
            OpenDevicePage(ExitType);
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            EditType();
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.TypeRepository.Remove(selectedType.TypeInventoryId);
            selectedType = null;
            LoadTypes();
        }

        private void uxOnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = "Logout";
            this.Close();
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = "";
            this.Close();
        }

        #endregion

        #region Double Click Events

        private void uxTypeList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpenDevicePage(ExitType);
        }

        #endregion

        #region Load Events

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedType != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedType != null);
            uxContextFileDelete.IsEnabled = uxFileDelete.IsEnabled;
        }

        private void LoadTypes()
        {
            var types = App.TypeRepository.GetAll();

            uxTypeList.ItemsSource = types
                                    .Select(t => TypeModel.ToModel(t))
                                    .ToList();
        }

        #endregion

        #region Change Events

        private void uxTypeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedType = (TypeModel)uxTypeList.SelectedValue;
        }

        #endregion

        #region Window Methods

        private void EditType()
        {
            var window = new NewType();
            window.Type = selectedType.Clone();

            if (window.ShowDialog() == true)
            {
                App.TypeRepository.Update(window.Type.ToRepositoryModel());
                LoadTypes();
            }
        }

        private void OpenDevicePage(string ExitType)
        {
            this.Visibility = Visibility.Collapsed;

            string SelectedType = string.Empty;

            if (selectedType != null)
            {
                SelectedType = selectedType.TypeType.ToString();
            }
            else
            {
                SelectedType = "All";
            }

            var windowDeviceInv = new DeviceInventory(ExitType, SelectedType);
            windowDeviceInv.ShowDialog();

            ExitEvent(windowDeviceInv);
        }

        private void ExitEvent(DeviceInventory windowDeviceInv)
        {
            try
            {
                if ((string)windowDeviceInv.DataContext == "TypePage")
                {
                    this.Visibility = Visibility.Visible;
                }
                else if((string)windowDeviceInv.DataContext == "Logout")
                {
                    this.DataContext = "Logout";
                    this.Close();
                }
                else
                {
                    this.DataContext = "";
                    this.Close();
                }
            }
            catch
            {
                this.Close();
            }
        }

        #endregion
    }
}