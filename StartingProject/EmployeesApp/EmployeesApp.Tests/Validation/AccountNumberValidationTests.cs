using EmployeesApp.Validaton;
using Xunit;

namespace EmployeesApp.Tests.Validation
{
    public class AccountNumberValidationTests
    {
        private readonly AccountNumberValidation _validation;
        public AccountNumberValidationTests()
        {
            _validation = new AccountNumberValidation();
        }

        [Fact]
        public void IsValid_ValidAccountNumber_ReturnsTrue()
        {
            Assert.True(_validation.IsValid("123-4543234576-23"));
        }

        [Theory]
        [InlineData("1234-3454565676-23")]
        [InlineData("12-3454565676-23")]
        public void IsValid_AccountNumberFirstPartWrong_ReturnsFalse(string accountNumber)
        {
            Assert.False(_validation.IsValid(accountNumber));
        }
    }
}
