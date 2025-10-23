using NUnit.Framework;
namespace ATM.Domain.Tests
{
    public class ATMTests
    {
        [Test]
        public void GivenAccountAndWithdraw_ThenExecute_ReturnsCorrectAmount()
        {
            var account = new Account() { AccountBalance = 300 };
            decimal amount = 100;
            var withdraw = new WithdrawCommand(account, amount);
            new ATM(withdraw).Action();
            Assert.That(account.AccountBalance.Equals(200));
        }
        [Test]
        public void GivenAccountAndDeposit_ThenExecute_ReturnsCorrectAmount()
        {
            var account = new Account() { AccountBalance = 200 };
            decimal amount = 100;
            var deposit = new DepositCommand(account, amount);
            new ATM(deposit).Action();
            Assert.That(account.AccountBalance.Equals(300));
        }
    }
}