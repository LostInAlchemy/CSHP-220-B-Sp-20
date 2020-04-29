using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        int nmSortDirection = 0;
        int pwSortDirection = 0;

        public SecondWindow()
        {
            InitializeComponent();

            UserDatabase db = new UserDatabase();
            uxList.ItemsSource = db.Users;
        }

        private void Header_Click(object sender, RoutedEventArgs e)
        {
            sort(e);
        }

        private void sort(RoutedEventArgs e)
        {
            ListSortDirection direction = ListSortDirection.Descending;
            string column = "";
            var headerClicked = e.OriginalSource as GridViewColumnHeader;

            if (headerClicked.Content.ToString() == "Name")
            {
                if (nmSortDirection == 0 || nmSortDirection == 2)
                {
                    direction = ListSortDirection.Ascending;
                    nmSortDirection = 1;
                    pwSortDirection = 0;
                }
                else
                {
                    direction = ListSortDirection.Descending;
                    nmSortDirection = 2;
                }

                column = "Name";
            }

            else if (headerClicked.Content.ToString() == "Password")
            {
                if (pwSortDirection == 0 || pwSortDirection == 2)
                {
                    direction = ListSortDirection.Ascending;
                    pwSortDirection = 1;
                    nmSortDirection = 0;
                }
                else
                {
                    direction = ListSortDirection.Descending;
                    pwSortDirection = 2;
                    nmSortDirection = 0;
                }

                column = "Password";
            }

            if (column != "" || column != string.Empty)
            {
                ICollectionView dataView = CollectionViewSource.GetDefaultView(uxList.ItemsSource);
                dataView.SortDescriptions.Clear();
                SortDescription sd = new SortDescription(column, direction);
                dataView.SortDescriptions.Add(sd);
                dataView.Refresh();
            }
        }
    }
}
