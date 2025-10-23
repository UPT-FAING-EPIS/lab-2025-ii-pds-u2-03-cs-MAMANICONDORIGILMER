using System;
namespace ATM.Domain
{
    public class Account
    {
        public const decimal MAX_INPUT_AMOUNT = 10000;
        public int AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }

        public void Withdraw(decimal amount)
        {
            if (amount > AccountBalance) 
                throw new ArgumentException("The input amount is greater than balance.");
            AccountBalance -= amount;            
        }
        public void Deposit(decimal amount)
        {
            if (amount > MAX_INPUT_AMOUNT) 
                throw new ArgumentException("The input amount is greater than maximum allowed.");
            AccountBalance += amount;            
        }
    }
}