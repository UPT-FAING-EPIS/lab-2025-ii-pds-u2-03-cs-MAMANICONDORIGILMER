namespace Payment.Domain
{
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public bool Pay(double amount)
        {
            Console.WriteLine("Customer pays Rs " + amount + " using Credit Card");
            return true;
        }
    }
}