using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreditCard.Tests.CreditCardEvaluator
{
    [TestClass]
    public class IsDiscoverShould
    {
        [DataTestMethod]
        [DataRow("6011000000000000")]
        [DataRow("6500000000000000")]
        public void ReturnTrueForDiscoverNumbers(string creditCardNumber)
        {
            // Act
            var isDiscover = CreditCard.CreditCardEvaluator.IsDiscover(creditCardNumber);

            // Assert
            Assert.IsTrue(isDiscover);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("                ")]
        [DataRow("1111111111111111")]
        [DataRow("601100000000000")]
        [DataRow("650000000000000")]
        [DataRow("60110000000000000")]
        [DataRow("65000000000000000")]
        public void ReturnFalseForNonDiscoverNumbers(string creditCardNumber)
        {
            // Act
            var isDiscover = CreditCard.CreditCardEvaluator.IsDiscover(creditCardNumber);

            // Assert
            Assert.IsFalse(isDiscover);
        }
    }
}
