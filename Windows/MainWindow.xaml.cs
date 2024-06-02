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

            ListView.ItemsSource = EFClass.Context.Events.ToList();

        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();

            this.Close();
        }

        private void ButtonSortDirection_Click(object sender, RoutedEventArgs e)
        {
            listSortDirection = listSortDirection != ListSortDirection.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;

            ListView.Items.SortDescriptions.Clear();
            ListView.Items.SortDescriptions.Add(new SortDescription("Direction.DirectionName", listSortDirection));
        }

        private void ButtonSortDate_Click(object sender, RoutedEventArgs e)
        {
            listSortDirection = listSortDirection != ListSortDirection.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;

            ListView.Items.SortDescriptions.Clear();
            ListView.Items.SortDescriptions.Add(new SortDescription("EventDate", listSortDirection));
        }
    }
}
