namespace Weesh.xUnitTests
{
    public class CheckTests
    {
        [Fact]
        public void Should_return_correct_filled_out_check()
        {
            //Arrange
            var check = new Check();

            //Act
            check.CreateCheck("123", "12:34", 300);

            //Assert
            Assert.Equal("Номер вашего самоката: 123. " +
                "Обратитесь в пункт выдачи в 12:34 для его получения. " +
                "Итого к оплате: 300. Всего доброго!", check.CheckForPerson);
        }
    }
}
