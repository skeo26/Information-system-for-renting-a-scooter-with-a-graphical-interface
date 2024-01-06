using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Weesh.BusinessLogic
{
    public class Hire
    {
        private Dictionary<Scooter, string> dbScooter;
        private List<User> dbUsers;
        private string idOfScooter;

        public string IdOfScooter { get { return idOfScooter; } }

        public List<User> DBUsers { get { return dbUsers; } }

        public Dictionary<Scooter, string> DBScooter { get { return dbScooter; } }


        public Hire(Dictionary<Scooter, string> scooters, List<User> users) 
        {
            dbScooter = scooters;
            dbUsers = users;
        }

        public void RegistrationNewUser(string[] inputLoginPassword)
        { 
            dbUsers.Add(AddNewUser(inputLoginPassword));
        }

        public User AuthorizationUser(string[] inputLoginPassword)
        {
            string login = inputLoginPassword[0];
            string password = inputLoginPassword[1];
            var foundUser = dbUsers.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (foundUser == null)
                throw new InvalidAuthorisationException();
            else
                return foundUser;
        }

        private User AddNewUser(string[] inputLoginPassword)
        {
            string login = inputLoginPassword[0];
            string password = inputLoginPassword[1];
            var foundUser = dbUsers.SingleOrDefault(x => x.Login == login);
            if (foundUser == null)
            {
                return new User(login, password, 0);
            }
            else
            {
                throw new InvalidCreateNewUserException();
            }
        }

        public static bool IsCorrectDuration(int hours)
        {
            if (hours > 0 && hours <= 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsCorrectAgeRange(int age)
        {
            return (age > 14 || age < 120);
        }


        public bool IsFindScooter(Equipment equipment)
        {
            foreach (Scooter item in dbScooter.Keys)
            {
                if (IsScooterFits(item, equipment))
                {
                    idOfScooter = item.ID;
                    dbScooter[item] = "Busy";
                    return true;
                }
            }
            return false;
        }

        private bool IsScooterFits(Scooter scooter, Equipment equipment)
        {
            return scooter.Equipment.AgeTypeOfScooter == equipment.AgeTypeOfScooter 
                && scooter.Equipment.Seat == equipment.Seat 
                && scooter.Equipment.BatteryCapacity == equipment.BatteryCapacity;
        }

        public Equipment GenerateUserEquipment(UserRequest userRequest)
        {
            return new Equipment(SelectBattery(userRequest.Hours), 
                EnterAdultOrChild(userRequest.Age), 
                userRequest.ScooterType);
        }

        private string SelectBattery(int hours)
        {
            if (hours < 4)
            {
                return "050";
            }
            if (hours >= 4 && hours < 6)
            {
                return "075";
            }
            else
            {
                return "100";
            }
        }

        private string EnterAdultOrChild(int age)
        {
            if (age < 18)
            {
                return "Child";
            }
            else
            {
                return "Adult";
            }
        }
    }
}
