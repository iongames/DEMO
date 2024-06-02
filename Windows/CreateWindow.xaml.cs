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
    /// Логика взаимодействия для CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        private User user;
        public CreateWindow(User organizer)
        {
            InitializeComponent();
            user = organizer;

            CheckEvent.IsChecked = true;
            CheckShowPassword.IsChecked = true;
            CBGender.ItemsSource = EFClass.Context.Genders.ToList();
            CBRole.ItemsSource = EFClass.Context.Role.ToList();
            CBDirection.ItemsSource = EFClass.Context.Directions.ToList();
            CBEvent.ItemsSource = EFClass.Context.Events.ToList();

            TBIdNumber.Text = (EFClass.Context.User.ToList().Last().UserID + 1).ToString();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User newUser = new User();

                newUser.UserID = int.Parse(TBIdNumber.Text);
                newUser.UserFIO = TBFio.Text;
                newUser.GenderCode = (CBGender.SelectedItem as Genders).GenderCode;
                newUser.RoleID = (CBRole.SelectedItem as Role).RoleID;
                newUser.Email = TBEmail.Text;
                newUser.UserPhone = TBPhone.Text;
                newUser.DirectionID = (CBDirection.SelectedItem as Directions).DirectionID;
                newUser.Pasword = TBPassword.Text;
                newUser.UserBirthday = DateTime.Now;

                if (CheckEvent.IsChecked == true)
                {
                    newUser.EventID = (CBEvent.SelectedItem as Events).EventID;
                }

                if (TBPassword.Text == TBRepeatPassword.Text)
                {
                    EFClass.Context.User.Add(newUser);
                    EFClass.Context.SaveChanges();

                    MessageBox.Show("Пользователь добавлен!");

                    OrganizerWindow organizerWindow = new OrganizerWindow(user);
                    organizerWindow.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Некоторые данные указаны неправильно!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            OrganizerWindow organizerWindow = new OrganizerWindow(user);
            organizerWindow.Show();

            this.Close();
        }

        private void CheckEvent_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckEvent.IsChecked == true)
            {
                CBEvent.Visibility = Visibility.Visible;
            } else
            {
                CBEvent.Visibility = Visibility.Hidden;
            }
        }

        private void CheckShowPassword_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
