namespace Payment.Domain
{
    public class DebitCardPaymentStrategy : IPaymentStrategy
    {
        public bool Pay(double amount)
        {
            Console.WriteLine("Customer pays Rs " + amount + " using Debit Card");
            return true;
        }
    }
}