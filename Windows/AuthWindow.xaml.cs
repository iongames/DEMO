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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
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

            Participants participant = EFClass.Context.Participants.FirstOrDefault(p => p.ParticipantID == number && p.Password == password);

            if (participant != null)
            {
                ParticipantWindow participantWindow = new ParticipantWindow();  
                participantWindow.Show();

                this.Close();
            } else
            {
                Moderators moderator = EFClass.Context.Moderators.FirstOrDefault(p => p.ModeratorID == number && p.Password == password);

                if (moderator != null)
                {
                    ModeratorWindow moderatorWindow = new ModeratorWindow();
                    moderatorWindow.Show();

                    this.Close();
                } else
                {
                    Organizers organizer = EFClass.Context.Organizers.FirstOrDefault(p => p.OrganizerID == number && p.Password == password);

                    if (organizer != null) {
                        OrganizerWindow organizerWindow = new OrganizerWindow(organizer);
                        organizerWindow.Show();

                        this.Close();
                    }
                    else
                    {
                        Jury jury = EFClass.Context.Jury.FirstOrDefault(p => p.JuryID == number && p.Password == password);

                        if (jury != null) {
                            JuryWindow juryWindow = new JuryWindow();
                            juryWindow.Show();

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Неправильные логин и пароль!");
                        }
                    }
                }
            }
        }
    }
}
