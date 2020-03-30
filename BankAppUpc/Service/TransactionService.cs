using System;
using System.Collections.Generic;
using System.Text;
using BankAppUpc.Entity;

namespace BankAppUpc.Service
{
    public class TransactionService
    {
        public static void MakeDeposit(BankAccount account, decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            account.Transactions.Add(deposit);
        }

        public static void MakeWithdrawal(BankAccount account, decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (account.Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for thus withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            account.Transactions.Add(withdrawal);
        }
    }
}
