using DEMO.Database;
using Microsoft.Win32;
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
using System.Windows.Threading;

namespace DEMO.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public AuthWindow()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            int number = -1;
            string password = TBPassword.Text;
            int.TryParse(TBNumber.Text, out number);

            RegistryKey auth = Registry.CurrentUser.CreateSubKey("DEMO_WPF");

            if (timer.IsEnabled == false)
            {
                User user = EFClass.Context.User.FirstOrDefault(p => p.UserID == number && p.Pasword == password);

                if (user != null)
                {
                    switch (user.RoleID)
                    {
                        case 1:
                            ParticipantWindow participantWindow = new ParticipantWindow();
                            participantWindow.Show();
                            break;
                        case 2:
                            OrganizerWindow organizerWindow = new OrganizerWindow(user);
                            organizerWindow.Show();
                            break;
                        case 3:
                            ModeratorWindow moderatorWindow = new ModeratorWindow();
                            moderatorWindow.Show();
                            break;
                        case 4:
                            JuryWindow juryWindow = new JuryWindow();
                            juryWindow.Show();
                            break;
                        default:
                            break;
                    }

                    auth.SetValue("USER_ID", user.UserID);
                    auth.Close();

                    this.Close();
                } else
                {
                    MessageBox.Show("Неправильные логин и пароль!");
                }

                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = new TimeSpan(0, 0, 10);
                timer.Start();
            } else
            {
                MessageBox.Show("Подождите 10 секунд!");
            }
        }
    }
}
