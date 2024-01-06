using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weesh.BusinessLogic
{
    public class UserRequest
    {

        public TimeOnly TimeStart { get; }
        public int Hours { get; }
        public int Age { get; }
        public string ScooterType { get; }

        public UserRequest(TimeOnly timeStart, int hours, int age, string scooterType)
        {
            TimeStart = timeStart;
            Hours = hours;
            Age = age;
            ScooterType = scooterType;
        }
    }
}
