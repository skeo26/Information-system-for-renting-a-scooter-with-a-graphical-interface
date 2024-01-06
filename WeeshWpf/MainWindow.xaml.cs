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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Weesh;
using Weesh.BusinessLogic;
using Weesh.DataAccess;

namespace WeeshWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class YourDataType
    {
        public string ScooterPhoto { get; set; }
        public string BatteryCapacity { get; set; }
        public string Range { get; set; }
    }
    public partial class MainWindow : Window
    {
        User user;
        WorkWithFile workWithFile = new WorkWithFile();
        Hire hire;
        public MainWindow()
        {
            InitializeComponent();
            BackGroundVideo.Play();
            string[] path = new string[]
            {
                "C:\\Users\\Денис\\Desktop\\ТехнологииПрограммирования\\Weesh\\Weesh\\bin\\Debug\\net7.0\\samokat.txt",
                "C:\\Users\\Денис\\Desktop\\ТехнологииПрограммирования\\Weesh\\Weesh\\bin\\Debug\\net7.0\\Users.txt",
                "C:\\Users\\Денис\\Desktop\\ТехнологииПрограммирования\\Weesh\\Weesh\\bin\\Debug\\net7.0\\PricingPolicy.txt"
            };
            hire = workWithFile.InitializationHire(path[0], path[1]);
        }

        private void GoToRegistration_Click(object sender, RoutedEventArgs e)
        {
            Authorisation.Visibility = Visibility.Collapsed;
            Registration.Visibility = Visibility.Visible;
        }

        private void RegistrationComplete_Click(object sender, RoutedEventArgs e)
        {
            if (RegistrationPasswordPasswordBox.Password == RegistrationRepeatPasswordPasswordBox.Password)
            {
                hire.RegistrationNewUser(new string[] { RegistrationLoginTextBox.Text, RegistrationPasswordPasswordBox.Password });
                Registration.Visibility = Visibility.Collapsed;
                Authorisation.Visibility = Visibility.Visible;
            }
            else
            {
                InvalidConfirmPassword.Visibility = Visibility.Visible;
            }
        }

        private void BackGroundVideo_Ended(object sender, RoutedEventArgs e)
        {
            BackGroundVideo.Position = TimeSpan.Zero;
            BackGroundVideo.Play();
        }

        private void AuthorisationButton_Click(object sender, RoutedEventArgs e)
        {
            SuccessPanel.Visibility = Visibility.Collapsed;
            InvalidPanel.Visibility = Visibility.Collapsed;

            try
            {
                user = hire.AuthorizationUser(new string[] { AuthorisationLoginTextBox.Text, AuthorisationPasswordPasswordBox.Password });
                SuccessPanel.Visibility = Visibility.Visible;
                var timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    this.Hide();
                    HireWindow hireWindow = new HireWindow(hire, user, workWithFile);
                    hireWindow.Show();
                };
                timer.Start();
            }
            catch (InvalidAuthorisationException)
            {
                InvalidPanel.Visibility = Visibility.Visible;
                var timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    InvalidPanel.Visibility = Visibility.Collapsed;
                };
                timer.Start();
            }           
        }
    }
}
