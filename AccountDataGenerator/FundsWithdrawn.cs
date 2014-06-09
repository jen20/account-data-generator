using System;

namespace AccountDataGenerator
{
    internal class FundsWithdrawn
    {
        public readonly string AccountNumber;
        public readonly DateTime WithdrawlDate;
        public readonly decimal Amount;

        public FundsWithdrawn(string accountNumber, DateTime withdrawlDate, decimal amount)
        {
            AccountNumber = accountNumber;
            WithdrawlDate = withdrawlDate;
            Amount = amount;
        }
    }
}