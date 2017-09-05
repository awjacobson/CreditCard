Credit Card Type
================

.Net library for determining a credit card type.

## Example

```c#
public static string GetCreditCardType(string creditCardNumber)
{
    var cardType = CreditCard.CreditCardEvaluator.GetType(creditCardNumber);

    switch(cardType)
    {
        case CreditCard.CreditCardTypes.MasterCard:
            return "mastercard";

        case CreditCard.CreditCardTypes.Visa:
            return "visa";

        case CreditCard.CreditCardTypes.Discover:
            return "discover";

        case CreditCard.CreditCardTypes.AmericanExpress:
            return "amex";
    }

    return null;
}
```