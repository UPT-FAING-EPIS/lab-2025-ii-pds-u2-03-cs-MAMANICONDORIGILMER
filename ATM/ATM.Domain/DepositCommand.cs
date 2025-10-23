namespace ATM.Domain
{
    public class DepositCommand : ICommand
    {
        Account _account;
        decimal _amount;
        public DepositCommand(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }
        public void Execute()
        {
            _account.Deposit(_amount);
        }        
    }
}