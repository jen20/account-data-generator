using System;

namespace AccountDataGenerator
{
    internal class FundsDeposited
    {
        public readonly string AccountNumber;
        public readonly DateTime DepositDate;
        public readonly decimal Amount;

        public FundsDeposited(string accountNumber, DateTime depositDate, decimal amount)
        {
            AccountNumber = accountNumber;
            DepositDate = depositDate;
            Amount = amount;
        }
    }
}