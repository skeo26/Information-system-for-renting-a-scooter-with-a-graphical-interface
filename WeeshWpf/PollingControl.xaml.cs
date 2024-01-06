using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Weesh.UserInterface;
using Weesh.BusinessLogic;
using Weesh.DataAccess;
using System.Globalization;

namespace WeeshWpf
{
    /// <summary>
    /// Логика взаимодействия для PollingControl.xaml
    /// </summary>
    public partial class PollingControl : UserControl
    {
        UserSurvey userSurvey = new UserSurvey();
        UserRequest userRequest;
        Equipment equipment;
        Hire hire;
        Payment payment;
        WorkWithFile workWithFile;
        User user;

        public PollingControl(Hire hire, WorkWithFile workWithFile, User user)
        {
            InitializeComponent();
            this.hire = hire;
            this.workWithFile = workWithFile;
            this.user = user;
            payment = workWithFile.InitializationPayment("C:\\Users\\Денис\\Desktop\\ТехнологииПрограммирования\\Weesh\\Weesh\\bin\\Debug\\net7.0\\PricingPolicy.txt");
        }

        private void NextButton1_Click(object sender, RoutedEventArgs e)
        {

            TimeOnly temp = TimeOnly.Parse(TPicker.Value.ToString().Substring(11,5));
            userSurvey.TimeStart = temp;
            startTimePanel.Visibility = Visibility.Collapsed;
            durationPanel.Visibility = Visibility.Visible;            
        }

        private void NextButton2_Click(object sender, RoutedEventArgs e)
        {
            userSurvey.Hours = Convert.ToInt32(durationTextBox.Text);
            
            
            agePanel.Visibility = Visibility.Visible;
            
            durationPanel.Visibility = Visibility.Collapsed;
        }

        private void NextButton3_Click(object sender, RoutedEventArgs e)
        {
            userSurvey.Age = Convert.ToInt32(ageTextBox.Text);
            seatingPanel.Visibility = Visibility.Visible;
            
            agePanel.Visibility = Visibility.Collapsed;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TimePicker_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SubmitButton(object sender, RoutedEventArgs e)
        {
            seatingPanel.Visibility = Visibility.Collapsed;
            userSurvey.ScooterType = seatingComboBox.Text;
            ConfirmationTravel.Visibility = Visibility.Visible;
            TimeStartTextBlock.Text = userSurvey.TimeStart.ToString();
            DurationTextBlock.Text = userSurvey.Hours.ToString();
            if (userSurvey.Hours == 1)
                DurationTextBlock.Text += " час";
            else if (1 < userSurvey.Hours && userSurvey.Hours < 5)
                DurationTextBlock.Text += " часа";
            else
                DurationTextBlock.Text += " часов";
            TypeOfScooterTextBlock.Text = userSurvey.ScooterType.ToString();
            if (userSurvey.ScooterType == "С сиденьем")
            {
                userSurvey.ScooterType = "Seat";
            }
            else
            {
                userSurvey.ScooterType = "No_Seat";
            }
            userRequest = new UserRequest(userSurvey.TimeStart, userSurvey.Hours, userSurvey.Age, userSurvey.ScooterType);
            equipment = hire.GenerateUserEquipment(userRequest);
            // добавить messageBox
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (!hire.IsFindScooter(equipment))
            {
                MessageBox.Show("Самоката с выбранной комлектацией - нет");
                HomePage homepage = new HomePage();
                Content = homepage;
                return;
            }
            ConfirmationTravel.Visibility = Visibility.Collapsed;
            if (user.Subscription != null)
            {
                payment.CalculatePrice(userRequest);
                ConfirmBonusDebit.Visibility = Visibility.Visible;
                PriceWithoutBonusTextBlock.Text = payment.ResultPrice.ToString();
                BonusQuantityTextBlock.Text = user.BonusQuantity.ToString();
            }
            else
            {
                Check.Visibility = Visibility.Visible;
                payment.CalculatePrice(userRequest);
                ScooterIDTextBlock.Text = hire.IdOfScooter.ToString();
                TimeToGoTextBlock.Text = string.Format("Обратитесь в пункт выдачи в {0} для его получения.", userRequest.TimeStart.ToString());
                FinalPriceTextBlock.Text = payment.ResultPrice.ToString();
                Check check = new Check();
                check.CreateCheck(hire.IdOfScooter, userRequest.TimeStart.ToString(), payment.ResultPrice);
                workWithFile.UpdateAllDataBasesAndCreateCheckFile(hire, check, "./Check.txt");
            }
        }

        private void Unconfirm_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            Content = homePage;
        }

        private void ConfirmBonusDebit_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBonusDebit.Visibility = Visibility.Collapsed;
            payment.CalculatePrice(userRequest, user);
            Check.Visibility = Visibility.Visible;
            ScooterIDTextBlock.Text = hire.IdOfScooter.ToString();
            TimeToGoTextBlock.Text = string.Format("Обратитесь в пункт выдачи в {0} для его получения.", userRequest.TimeStart.ToString());
            FinalPriceTextBlock.Text = payment.ResultPrice.ToString();
            Check check = new Check();
            check.CreateCheck(hire.IdOfScooter, userRequest.TimeStart.ToString(), payment.ResultPrice);
            workWithFile.UpdateAllDataBasesAndCreateCheckFile(hire, check, "./Check.txt");
        }

        private void UnconfirmBonusDebit_Click(object sender, RoutedEventArgs e)
        {
            ConfirmBonusDebit.Visibility = Visibility.Collapsed;
            payment.CalculatePrice(userRequest);
            payment.CalculateDiscount(user.Subscription);
            user.GetBonusForTrip(payment.CalculateBonusForTrip(user.Subscription));
            Check.Visibility = Visibility.Visible;
            BonusForTripPanel.Visibility = Visibility.Visible;
            ScooterIDTextBlock.Text = hire.IdOfScooter.ToString();
            TimeToGoTextBlock.Text = string.Format("Обратитесь в пункт выдачи в {0} для его получения.", userRequest.TimeStart.ToString());
            BonusForTripTextBlock.Text = payment.CalculateBonusForTrip(user.Subscription).ToString();
            FinalPriceTextBlock.Text = payment.ResultPrice.ToString();
            Check check = new Check();
            check.CreateCheck(hire.IdOfScooter, userRequest.TimeStart.ToString(), payment.ResultPrice);
            workWithFile.UpdateAllDataBasesAndCreateCheckFile(hire, check, "./Check.txt");
        }
    }
}
