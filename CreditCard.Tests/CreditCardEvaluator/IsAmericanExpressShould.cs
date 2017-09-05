using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreditCard.Tests.CreditCardEvaluator
{
    [TestClass]
    public class IsAmericanExpressShould
    {
        [DataTestMethod]
        [DataRow("340000000000000")]
        [DataRow("370000000000000")]
        public void ReturnTrueForAmericanExpressNumbers(string creditCardNumber)
        {
            // Act
            var isAmericanExpress = CreditCard.CreditCardEvaluator.IsAmericanExpress(creditCardNumber);

            // Assert
            Assert.IsTrue(isAmericanExpress);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("                ")]
        [DataRow("34000000000000")] // starts with valid prefix but too short
        [DataRow("37000000000000")] // starts with valid prefix but too short
        [DataRow("3400000000000000")] // starts with valid prefix but too long
        [DataRow("3400000000000000")] // starts with valid prefix but too long
        [DataRow("6011000000000000")] // Discover card number
        [DataRow("6500000000000000")] // Discover card number
        [DataRow("4111111111111111")] // Visa card number
        [DataRow("4111111111111")] // Visa card number
        [DataRow("5100001111111111")] // MasterCard card number
        [DataRow("5599991111111111")] // MasterCard card number
        [DataRow("2221001111111111")] // MasterCard card number
        [DataRow("2720991111111111")] // MasterCard card number
        public void ReturnFalseForNoAmericanExpressNumbers(string creditCardNumber)
        {
            // Act
            var isAmericanExpress = CreditCard.CreditCardEvaluator.IsAmericanExpress(creditCardNumber);

            // Assert
            Assert.IsFalse(isAmericanExpress);
        }
    }
}
