namespace Payment.Domain
{
    public interface IPaymentStrategy
    {
        bool Pay(double amount);
    }
}