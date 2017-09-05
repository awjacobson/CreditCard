using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreditCard.Tests.CreditCardEvaluator
{
    [TestClass]
    public class IsVisaShould
    {
        [DataTestMethod]
        [DataRow("4111111111111111")]
        [DataRow("4111111111111")]
        public void ReturnTrueForVisaNumbers(string creditCardNumber)
        {
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("                ")]
        [DataRow("1111111111111111")]
        [DataRow("4")]
        [DataRow("41")]
        [DataRow("411")]
        [DataRow("4111")]
        [DataRow("41111")]
        [DataRow("411111")]
        [DataRow("4111111")]
        public void ReturnFalseForNonVisaNumbers(string creditCardNumber)
        {
            // Act
            var isVisa = CreditCard.CreditCardEvaluator.IsVisa(creditCardNumber);

            // Assert
            Assert.IsFalse(isVisa);
        }
    }
}
