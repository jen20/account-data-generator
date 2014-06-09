using System;

namespace AccountDataGenerator
{
    internal class AccountOpened
    {
        public readonly string AccountNumber;
        public readonly DateTime OpenedDate;

        public AccountOpened(string accountNumber, DateTime openedDate)
        {
            AccountNumber = accountNumber;
            OpenedDate = openedDate;
        }
    }
}