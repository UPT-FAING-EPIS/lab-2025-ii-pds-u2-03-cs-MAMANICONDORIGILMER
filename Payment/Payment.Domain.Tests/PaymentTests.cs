using System;
using NUnit.Framework;
using Payment.Domain;
namespace Payment.Domain.Tests
{
    public class PaymentTests
    {
        [TestCase(1, 1000)]
        [TestCase(2, 2000)]
        [TestCase(3, 3000)]
        public void GivenAValidPaymentTypeAndAmount_WhenProcessPayment_ResultIsSuccesful(int paymentType, double amount)
        {
            bool PaymentResult = new PaymentService().ProcessPayment(paymentType, amount);
            Assert.That(PaymentResult);
        }
        [TestCase(4, 4000)]
        public void GivenAnUnknownPaymentTypeAndAmount_WhenProcessPayment_ResultIsError(int paymentType, double amount)
        {
            //bool PaymentResult = new PaymentService().ProcessPayment(paymentType, amount);
            var ex = Assert.Throws<ArgumentException>(
                () => new PaymentService().ProcessPayment(paymentType, amount));
            Assert.That(ex.Message, Is.EqualTo("You Select an Invalid Payment Option"));
        }   
    }
}