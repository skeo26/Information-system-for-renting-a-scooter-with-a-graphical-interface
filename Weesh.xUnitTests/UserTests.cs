using Weesh.BusinessLogic;

namespace Weesh.xUnitTests
{
    public class UserTests
    {
        [Fact]
        public void Should_correctly_add_bonuses()
        {
            //Arrange
            var user = new User("test", "test1", 0);

            //Act
            user.GetBonusForTrip(1);

            //Assert
            Assert.Equal(1, user.BonusQuantity);
        }
        [Fact]
        public void Should_correctly_spent_bonuses()
        {
            //Arrange
            var user = new User("test", "test1", 1);

            //Act
            user.SpentBonusForTrip(1);

            //Assert
            Assert.Equal(0, user.BonusQuantity);
        }
    }
}
