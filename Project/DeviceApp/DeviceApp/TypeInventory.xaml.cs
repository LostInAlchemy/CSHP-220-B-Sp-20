using DeviceApp.Models;
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
            OpenDevicePage();
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
            this.DataContext = "ReturnToMain";
            this.Close();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = "";
            this.Close();
        }

        #endregion

        #region Double Click Events

        private void uxTypeList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpenDevicePage();
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

        private void OpenDevicePage()
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

            var deviceInventory = new DeviceInventory(ExitType, SelectedType);
            deviceInventory.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
