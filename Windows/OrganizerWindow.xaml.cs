using DEMO.Database;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DEMO.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrganizerWindow.xaml
    /// </summary>
    public partial class OrganizerWindow : Window
    { 
        private User user;

        public OrganizerWindow(User organizer)
        {
            InitializeComponent();
            user = organizer;

            UserImage.Source = new BitmapImage(new Uri(organizer.UserPhoto, UriKind.Relative));
            TBUserName.Text = $"{(organizer.GenderCode == "м" ? "Mrs" : "Ms")} {organizer.UserFIO}";

            string dayText = "";
            if (DateTime.Now.Hour >= 9 && DateTime.Now.Hour <= 11)
            {
                dayText = "Доброе утро!";
            }
            else if (DateTime.Now.Hour > 11 && DateTime.Now.Hour <= 18)
            {
                dayText = "Добрый день!";
            } else
            {
                dayText = "Добрый вечер!";
            }

            TBDayText.Text = dayText;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow createWindow = new CreateWindow(user);
            createWindow.Show();

            this.Close();
        }
    }
}
