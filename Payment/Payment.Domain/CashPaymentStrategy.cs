namespace Payment.Domain
{
    public class CashPaymentStrategy : IPaymentStrategy
    {
        public bool Pay(double amount)
        {
            Console.WriteLine("Customer pays Rs " + amount + " By Cash");
            return true;
        }
    }
}