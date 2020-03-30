using System;
using System.Collections.Generic;
using System.Text;
using BankAppUpc.Service;

namespace BankAppUpc.Entity
{
    public class BankAccount
    {
        public string Number { get; }

        public string Owner { get; set; }

        private List<Transaction> transactions = new List<Transaction>();

        private static int accountNumberSeed = 1234567890;

        public List<Transaction> Transactions
        {
            get { return transactions; }
        }

        public decimal Balance {
            get 
            {
                decimal balance = 0;
                foreach(var item in transactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            this.Owner = name;
            TransactionService.MakeDeposit(this, initialBalance, DateTime.Now, "Initial balance");
        }
    }
}
