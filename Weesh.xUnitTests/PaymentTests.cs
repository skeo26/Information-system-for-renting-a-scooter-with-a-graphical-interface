namespace Weesh.xUnitTests
{
    public class PaymentTests
    {
        [Fact]
        public void Should_calculate_price_with_bonus_without_seat()
        {
            //Arrange
            var userRequest = new UserRequest(new TimeOnly(12, 34), 1, 14, "No_Seat"); 
            //timestart = 12:34, duration = 1, age = 14, typeOfScooter = "No_Seat" 
            var user = new User("test", "test1", 10);
            user.GetCard(new Subscription(50, 0.05), "SubForWeek");
            var payment = new Payment(new Dictionary<string, double>
            {
                { "PricePerHour", 300 },
                { "SeatAllowance", 1.1}
            }) ;

            //Act
            payment.CalculatePrice(userRequest, user);

            //Assert
            Assert.Equal(240, payment.ResultPrice);
            Assert.Equal(10, payment.SpentBonus);
        }
        [Fact]
        public void Should_calculate_price_without_bonus_without_seat()
        {
            //Arrange
            var userRequest = new UserRequest(new TimeOnly(12, 34), 1, 14, "No_Seat");
            //timestart = 12:34, duration = 1, age = 14, typeOfScooter = "No_Seat" 
            var payment = new Payment(new Dictionary<string, double>
            {
                { "PricePerHour", 300 },
                { "SeatAllowance", 1.1}
            });

            //Act
            payment.CalculatePrice(userRequest);

            //Assert
            Assert.Equal(300, payment.ResultPrice);
        }
        [Fact]
        public void Should_calculate_price_with_bonus_with_seat()
        {
            //Arrange
            var userRequest = new UserRequest(new TimeOnly(12, 34), 1, 14, "Seat"); 
            //timestart = 12:34, duration = 1, age = 14, typeOfScooter = "Seat" 
            var user = new User("test", "test1", 10);
            user.GetCard(new Subscription(50, 0.05), "SubForWeek");
            var payment = new Payment(new Dictionary<string, double>
            {
                { "PricePerHour", 300 },
                { "SeatAllowance", 1.1}
            }) ;

            //Act
            payment.CalculatePrice(userRequest, user);

            //Assert
            Assert.Equal(270, payment.ResultPrice);
            Assert.Equal(10, payment.SpentBonus);
        }
        [Fact]
        public void Should_calculate_price_without_bonus_with_seat()
        {
            //Arrange
            var userRequest = new UserRequest(new TimeOnly(12, 34), 1, 14, "Seat");
            //timestart = 12:34, duration = 1, age = 14, typeOfScooter = "Seat" 
            var payment = new Payment(new Dictionary<string, double>
            {
                { "PricePerHour", 300 },
                { "SeatAllowance", 1.1}
            });

            //Act
            payment.CalculatePrice(userRequest);

            //Assert
            Assert.Equal(330, payment.ResultPrice);
        }
    }
}
