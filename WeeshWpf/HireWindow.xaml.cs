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
using Weesh.BusinessLogic;
using Weesh.DataAccess;

namespace WeeshWpf
{
    /// <summary>
    /// Логика взаимодействия для HireWindow.xaml
    /// </summary>

    
    public partial class HireWindow : Window
    {
        Hire hire;
        User user;
        WorkWithFile workWithFile;
        public HireWindow(Hire hire, User user, WorkWithFile workWithFile)
        {
            InitializeComponent();
            this.hire = hire;
            this.user = user;
            this.workWithFile = workWithFile;
            HomePage homePage = new HomePage();
            contentControl.Content = homePage;
        }

        private void RentScooter_Click(object sender, RoutedEventArgs e)
        {
            PollingControl pollingControl = new PollingControl(hire, workWithFile, user);
            contentControl.Content = pollingControl;
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            contentControl.Content = homePage;
        }

        private void UserAccount_Click(object sender, RoutedEventArgs e)
        {
            UserAccountControl userAccount = new UserAccountControl(user);
            contentControl.Content = userAccount;
        }

        private void WeeshScooters_Click(object sender, RoutedEventArgs e)
        {
            ScooterRange scooterRange = new ScooterRange();
            contentControl.Content = scooterRange;
        }
    }
}
