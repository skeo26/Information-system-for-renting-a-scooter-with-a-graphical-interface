using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weesh.BusinessLogic;

namespace Weesh.UserInterface
{
    public class UserSurvey
    {
        private TimeOnly timeStart;
        private int hours;
        private int age;
        private string scooterType;

        public TimeOnly TimeStart { get { return timeStart; } set { timeStart = value; } }
        public int Hours { get { return hours; } set { hours = value; } }
        public int Age { get { return age; } set { age = value; } }
        public string ScooterType { get { return scooterType; } set { scooterType = value; } }

        public UserRequest CreateRequest()
        {
            return new UserRequest(TimeStart, Hours, Age, ScooterType);
        }

        public string[] GetLoginPassword()
        {
            string login = ConsoleInput.InputLogin();
            string password = ConsoleInput.InputPassword();
            return new string[] {login, password};
        }

        //public TimeOnly EnterTime(string inputTime)
        //{
        //    TimeOnly time;

        //    try
        //    {
        //        time =  TimeOnly.Parse(inputTime);
        //        return time;
        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        //public int EnterDuration()
        //{
        //    while (true)
        //    {

        //        string time = ConsoleInput.InputDuration();
        //        if (int.TryParse(time, out int Hours))
        //        {
        //            return Hours;
        //        }
        //        else
        //            ConsoleInput.DurationError();
        //    }
        //}

        //public int EnterAge()
        //{
        //    int age = 0;
        //    while (true)
        //    {
        //        var ageString = ConsoleInput.InputAge();
        //        if (int.TryParse(ageString, out age))
        //        {
        //            return age;
        //        }
        //        else
        //            ConsoleInput.AgeError();
        //    }
        //}

        //public string SelectTypeOfScooter()
        //{

        //    var key = ConsoleInput.InputSelectTypeOfScooter();
        //    while (true)
        //    {
        //        switch (key)
        //        {
        //            case ConsoleKey.D1:
        //                return "Seat";
        //            case ConsoleKey.D2:
        //                return "No_Seat";
        //        }
        //        key = ConsoleInput.InputSelectTypeOfScooter();
        //    }
        //}
    }
}
