namespace ATM.Domain
{
    public class WithdrawCommand : ICommand
    {
        Account _account;
        decimal _amount;
        public WithdrawCommand(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }
        public void Execute()
        {
            _account.Withdraw(_amount);
        }
    }
}