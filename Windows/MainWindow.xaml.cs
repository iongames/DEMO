using DEMO.Database;
using DEMO.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DEMO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListSortDirection listSortDirection = ListSortDirection.Ascending;
        public MainWindow()
        {
            InitializeComponent();
            Cities allCities = new Cities();
            allCities.CityID = -2;
            allCities.CityName = "Все";

            ListView.ItemsSource = EFClass.Context.Events.ToList();

            List<Cities> list = EFClass.Context.Cities.ToList();
            list.Insert(0, allCities);

            CBDirection.ItemsSource = list;
            CBDirection.SelectedIndex = 0;
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();

            this.Close();
        }

        //private void ButtonSortDate_Click(object sender, RoutedEventArgs e)
        //{
        //    listSortDirection = listSortDirection != ListSortDirection.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;
        //
        //    ListView.Items.SortDescriptions.Clear();
        //    ListView.Items.SortDescriptions.Add(new SortDescription("EventDate", listSortDirection));
        //}

        private void CBDirection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cities city = CBDirection.SelectedItem as Cities;
            DateTime? date = DPDate.SelectedDate;

            ListView.ItemsSource = EFClass.Context.Events.ToList().Where(i => (city.CityID == -2 || i.CityID == city.CityID) && (date == null || i.EventDate == date));
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Cities city = CBDirection.SelectedItem as Cities;
            DateTime? date = DPDate.SelectedDate;

            ListView.ItemsSource = EFClass.Context.Events.ToList().Where(i => (city.CityID == -2 || i.CityID == city.CityID) && (date == null || i.EventDate == date));
        }
    }
}
