namespace Weesh.xUnitTests
{
    public class HireTests
    {
        [Fact]
        public void Should_add_new_user_in_dbUsers()
        {
            //Arrange
            var hire = new Hire(new Dictionary<Scooter, string>(), new List<User>());
            var newUser = new string[] { "TestLogin", "TestPassword"};

            //Act
            hire.RegistrationNewUser(newUser);

            //Assert
            Assert.Single(hire.DBUsers);
            Assert.Equal("TestLogin", hire.DBUsers.First().Login);
            Assert.Equal("TestPassword", hire.DBUsers.First().Password);
            Assert.Equal(0.0, hire.DBUsers.First().BonusQuantity);
            Assert.Equal("None", hire.DBUsers.First().TypeOfSub);
        }
        [Fact]
        public void Should_return_user_with_valid_password_and_login()
        {
            //Arrange
            var user = new User("TestLogin", "TestPassword", 0.0);
            var hire = new Hire(new Dictionary<Scooter, string>(), new List<User>() { user});
            var loginAndPassword = new string[] { "TestLogin", "TestPassword" };

            //Act
            var result = hire.AuthorizationUser(loginAndPassword);

            //Assert
            Assert.Equal(user.Login, result.Login);
            Assert.Equal(user.Password, result.Password);
            Assert.Equal(user.BonusQuantity, result.BonusQuantity);
            Assert.Equal(user.TypeOfSub, result.TypeOfSub);
        }
        [Fact]
        public void Should_throw_exception_when_user_not_found()
        {
            //Arrange
            var hire = new Hire(new Dictionary<Scooter, string>(), new List<User>());
            var user = new User("TestLogin", "TestPassword", 0.0);
            var notExistenLoginAndPassword = new string[] { "NotExistenLogin", "NotExistenPassword" };
            var existenLoginAndPassword = new string[] { "ExistenLogin", "ExistenPassword" };

            //Act
            hire.RegistrationNewUser(existenLoginAndPassword);

            //Assert
            Assert.Throws<Exception>(() => hire.AuthorizationUser(notExistenLoginAndPassword));
        }
        
        [Fact]
        public void Should_return_true_when_scooter_is_found()
        {
            //Arrange
            var hire = new Hire(new Dictionary<Scooter, string>
            {
                {new Scooter("125", new Equipment("075", "Adult", "No_Seat")), "Free" }
            }, new List<User>());
            var equipment = new Equipment("075", "Adult", "No_Seat");         

            //Act
            var result = hire.IsFindScooter(equipment);

            //Assert
            Assert.True(result);
        }
        [Fact]
        public void Should_return_true_when_duration_from_1_to_8_incorrect_when_value_is_outside()
        {
            //Arrange 
            var duration = -10;

            //Act 
            var result = Hire.IsCorrectDuration(duration);

            //Assert 
            Assert.False(result);

        }
        [Fact]
        public void Should_return_true_when_duration_from_1_to_8_incorrect()
        {
            //Arrange 
            var duration = 0;

            //Act 
            var result = Hire.IsCorrectDuration(duration);

            //Assert 
            Assert.False(result);

        }
        [Fact]
        public void Should_return_true_when_duration_from_1_to_8_correct()
        {
            //Arrange 
            var duration = 4;

            //Act 
            var result = Hire.IsCorrectDuration(duration);

            //Assert 
            Assert.True(result);

        }
        [Fact]
        public void Should_return_true_when_duration_from_1_to_8_correct_when_value_is_correct()
        {
            //Arrange 
            var duration = 8;

            //Act 
            var result = Hire.IsCorrectDuration(duration);

            //Assert 
            Assert.True(result);

        }
        [Fact]
        public void Should_return_false_when_duration_from_1_to_8_incorrect()
        {
            //Arrange 
            var duration = 9;

            //Act 
            var result = Hire.IsCorrectDuration(duration);

            //Assert 
            Assert.False(result);
        }

        [Fact]
        public void Should_return_true_when_age_is_within_range_from_14_to_120_correct_when_value_is_lower_boundary_conditions()
        {
            //Arrange 
            var age = 14;

            //Act 
            var result = Hire.IsCorrectAgeRange(age);

            //Assert.True0 
            Assert.True(result);
        }
        [Fact]
        public void Should_return_true_when_age_is_not_outside_range_from_14_to_120_incorrect()
        {
            //Arrange 
            var age = 120;

            //Act 
            var result = Hire.IsCorrectAgeRange(age);

            //Assert 
            Assert.True(result);
        }
        [Fact]
        public void Should_return_false_when_age_is_lower_boundary_conditions_age_from_14_to_120()
        {
            //Arrange 
            var age = -20;

            //Act 
            var result = Hire.IsCorrectAgeRange(age);

            //Assert 
            Assert.False(result);
        }
        [Fact]
        public void Should_return_true_when_age_is_within_range_from_14_to_120_correct()
        {
            //Arrange 
            var age = 19;

            //Act 
            var result = Hire.IsCorrectAgeRange(age);

            //Assert 
            Assert.True(result);
        }
        [Fact]
        public void Should_return_false_when_age_is_higher_boundary_conditions_age_from_14_to_120()
        {
            //Arrange 
            var age = 130;

            //Act 
            var result = Hire.IsCorrectAgeRange(age);

            //Assert 
            Assert.False(result);
        }
        [Fact]
        public void Should_return_false_when_scooter_is_not_found_when_data_is_not_in_bd()
        {
            //Arrange
            var hire = new Hire(new Dictionary<Scooter, string>(), new List<User>());
            var equipment = new Equipment("075", "Adult", "No_Seat");
            

            //Act
            var result = hire.IsFindScooter(equipment);

            //Assert
            Assert.False(result);
        }
        [Fact]
        public void Should_return_false_when_scooter_is_not_found_when_data_different()
        {
            //Arrange
            var hire = new Hire(new Dictionary<Scooter, string>
            {
                {new Scooter("125", new Equipment("075", "Adult", "No_Seat")), "Free" }
            }, new List<User>());
            var equipment = new Equipment("025", "Child", "Seat");


            //Act
            var result = hire.IsFindScooter(equipment);

            //Assert
            Assert.False(result);
        }
        [Fact]
        public void Should_return_valid_equipment_base_on_UserRequest()
        {
            //Arrange
            var hire = new Hire(new Dictionary<Scooter, string>(), new List<User>());
            var userRequest = new UserRequest(new TimeOnly(12, 34), 6, 18, "Seat");


            //Act
            var result = hire.GenerateUserEquipment(userRequest);

            //Assert
            Assert.Equal("100", result.BatteryCapacity);
            Assert.Equal("Adult", result.AgeTypeOfScooter);
            Assert.Equal("Seat", result.Seat);
        }
    }
}