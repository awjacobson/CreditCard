using System.Text.RegularExpressions;

namespace CreditCard
{
    public enum CreditCardTypes
    {
        Unknown = 0,
        MasterCard = 1,
        Visa = 2,
        Discover = 3,
        AmericanExpress = 4,
        JCB = 5
    }

    public class CreditCardEvaluator
    {
        /// <summary>
        /// MasterCard numbers either start with the numbers 51 through 55 or with the numbers 2221 through 2720. All have 16 digits.
        /// </summary>
        private static string mastercardPattern = @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$";

        /// <summary>
        /// All Visa card numbers start with a 4. New cards have 16 digits. Old cards have 13.
        /// </summary>
        private static string visaPattern = @"^4[0-9]{12}(?:[0-9]{3})?$";

        /// <summary>
        /// Discover card numbers begin with 6011 or 65. All have 16 digits.
        /// </summary>
        private static string discoverPattern = @"^6(?:011|5[0-9]{2})[0-9]{12}$";

        /// <summary>
        /// American Express card numbers start with 34 or 37 and have 15 digits.
        /// </summary>
        private static string amexPattern = @"^3[47][0-9]{13}$";

        /// <summary>
        /// JCB cards beginning with 2131 or 1800 have 15 digits. JCB cards beginning with 35 have 16 digits.
        /// </summary>
        private static string jcbPattern = @"^(?:2131|1800|35\d{3})\d{11}$ ";

        public static CreditCardTypes GetType(string creditCardNumber)
        {
            if (IsMasterCard(creditCardNumber)) return CreditCardTypes.MasterCard;
            if (IsVisa(creditCardNumber)) return CreditCardTypes.Visa;
            if (IsDiscover(creditCardNumber)) return CreditCardTypes.Discover;
            if (IsAmericanExpress(creditCardNumber)) return CreditCardTypes.AmericanExpress;
            if (IsJcb(creditCardNumber)) return CreditCardTypes.JCB;

            return CreditCardTypes.Unknown;
        }

        /// <summary>
        /// Determines if the given credit card number is a MasterCard card or not.
        /// </summary>
        /// <param name="creditCardNumber">Credit card number to be evaluated.</param>
        /// <returns>Returns true if MasterCard. Otherwise, false.</returns>
        public static bool IsMasterCard(string creditCardNumber)
        {
            return string.IsNullOrWhiteSpace(creditCardNumber)
                ? false
                : new Regex(mastercardPattern, RegexOptions.IgnoreCase).IsMatch(creditCardNumber);
        }

        /// <summary>
        /// Determines if the given credit card number is a Visa card or not.
        /// </summary>
        /// <param name="creditCardNumber">Credit card number to be evaluated.</param>
        /// <returns>Returns true if Visa. Otherwise, false.</returns>
        public static bool IsVisa(string creditCardNumber)
        {
            return string.IsNullOrWhiteSpace(creditCardNumber)
                ? false
                : new Regex(visaPattern, RegexOptions.IgnoreCase).IsMatch(creditCardNumber);
        }

        /// <summary>
        /// Determines if the given credit card number is a Discover card or not.
        /// </summary>
        /// <param name="creditCardNumber">Credit card number to be evaluated.</param>
        /// <returns>Returns true if Discover. Otherwise, false.</returns>
        public static bool IsDiscover(string creditCardNumber)
        {
            return string.IsNullOrWhiteSpace(creditCardNumber)
                ? false
                : new Regex(discoverPattern, RegexOptions.IgnoreCase).IsMatch(creditCardNumber);
        }

        /// <summary>
        /// Determines if the given credit card number is an American Express card or not.
        /// </summary>
        /// <param name="creditCardNumber">Credit card number to be evaluated.</param>
        /// <returns>Returns true if American Express. Otherwise, false.</returns>
        public static bool IsAmericanExpress(string creditCardNumber)
        {
            return string.IsNullOrWhiteSpace(creditCardNumber)
                ? false
                : new Regex(amexPattern, RegexOptions.IgnoreCase).IsMatch(creditCardNumber);
        }

        /// <summary>
        /// Determines if the given credit card number is a JCB card or not.
        /// </summary>
        /// <param name="creditCardNumber">Credit card number to be evaluated.</param>
        /// <returns>Returns true if JCB. Otherwise, false.</returns>
        public static bool IsJcb(string creditCardNumber)
        {
            return string.IsNullOrWhiteSpace(creditCardNumber)
                ? false
                : new Regex(jcbPattern, RegexOptions.IgnoreCase).IsMatch(creditCardNumber);
        }
    }
}
