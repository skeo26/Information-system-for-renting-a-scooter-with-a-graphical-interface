using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using Weesh.BusinessLogic;
using Weesh.DataAccess;
using Weesh.UserInterface;
public class Program
{
    public static void Main(string[] args)
    {
        //if (!Verification.IsArgsEmpty(args))
        //    Environment.Exit(0);
        //foreach (var item in args)
        //{
        //    if (!Verification.IsPathExists(item))
        //        Environment.Exit(0);
        //}

        //WorkWithFile workWithFile = new WorkWithFile();
        //Hire hire = workWithFile.InitializationHire(args[0], args[1]);
        //UserSurvey userSurvey = new UserSurvey();
        //User user;
        //if (ConsoleInput.IsUserNotRegistered())
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            hire.RegistrationNewUser(userSurvey.GetLoginPassword());
        //            break;
        //        }
        //        catch (InvalidCreateNewUserException)
        //        {
        //            ConsoleInput.IncorrectLogin();
        //        }
        //    }
        //}
        //while (true)
        //{
        //    try
        //    {
        //        user = hire.AuthorizationUser(userSurvey.GetLoginPassword());
        //        break;
        //    }
        //    catch (InvalidAuthorisationException)
        //    {
        //        ConsoleInput.IncorrectLoginOrPassword();
        //    }
        //}
        //UserRequest userRequest = userSurvey.CreateRequest();
        //Equipment equipment = hire.GenerateUserEquipment(userRequest);
        //ConsoleInput.ShowConfig(equipment);
        //if (!UserConfirmation.ConfirmTravel())
        //{
        //    ConsoleInput.OrderCancel();
        //    Environment.Exit(0);
        //}
        //if (!hire.IsFindScooter(equipment))
        //{
        //    ConsoleInput.ScooterNotFound();
        //    Environment.Exit(0);
        //}
        //Payment payment = workWithFile.InitializationPayment(args[2]);
        //if (user.Subscription != null && UserConfirmation.ConfirmBonusDebit())
        //{
        //    payment.CalculatePrice(userRequest, user);
        //}
        //else if (user.Subscription != null)
        //{
        //    payment.CalculatePrice(userRequest);
        //    payment.CalculateDiscount(user.Subscription);
        //    user.GetBonusForTrip(payment.CalculateBonusForTrip(user.Subscription));
        //}
        //else
        //    payment.CalculatePrice(userRequest);
        //Check check = new Check();
        //check.CreateCheck(hire.IdOfScooter, userRequest.TimeStart.ToString(), payment.ResultPrice);
        //workWithFile.UpdateAllDataBasesAndCreateCheckFile(hire, check, "./Check.txt");

        //ConsoleInput.WishUserLuck();
    }
}