using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreditCard.Tests.CreditCardEvaluator
{
    [TestClass]
    public class IsMasterCardShould
    {
        [DataTestMethod]
        [DataRow("5100001111111111")]
        [DataRow("5599991111111111")]
        [DataRow("2221001111111111")]
        [DataRow("2720991111111111")]
        public void ReturnTrueForMasterCardNumbers(string creditCardNumber)
        {
            // Act
            var isMasterCard = CreditCard.CreditCardEvaluator.IsMasterCard(creditCardNumber);

            // Assert
            Assert.IsTrue(isMasterCard);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("                ")]
        [DataRow("1111111111111111")]
        [DataRow("510000111111111")] // starts with valid prefix but too short
        [DataRow("559999111111111")] // starts with valid prefix but too short
        [DataRow("222100111111111")] // starts with valid prefix but too short
        [DataRow("272099111111111")] // starts with valid prefix but too short
        [DataRow("51000011111111111")] // starts with valid prefix but too long
        [DataRow("55999911111111111")] // starts with valid prefix but too long
        [DataRow("22210011111111111")] // starts with valid prefix but too long
        [DataRow("27209911111111111")] // starts with valid prefix but too long
        [DataRow("6011000000000000")] // Discover card number
        [DataRow("6500000000000000")] // Discover card number
        [DataRow("4111111111111111")] // Visa card number
        [DataRow("4111111111111")] // Visa card number
        [DataRow("340000000000000")] // American Express card number
        [DataRow("370000000000000")] // American Express card number
        public void ReturnFalseForNonMasterCardNumbers(string creditCardNumber)
        {
            // Act
            var isMasterCard = CreditCard.CreditCardEvaluator.IsMasterCard(creditCardNumber);

            // Assert
            Assert.IsFalse(isMasterCard);
        }
    }
}
