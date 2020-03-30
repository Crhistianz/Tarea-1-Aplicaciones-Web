using System;
using BankAppUpc.Entity;
using BankAppUpc.Service;
using BankAppUpc.Common;

namespace BankAppUpc
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Jose Sanchez", 1000);
            Console.WriteLine($"Account {account.Number} was create for {account.Owner} " +
                $"with {account.Balance} initial balance");

            //Retiro
            TransactionService.MakeWithdrawal(account, 500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);

            //Depósito
            TransactionService.MakeDeposit(account, 100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

            var product = new Product
            {
                Id = 1,
                Name = "Electric Guitar",
                Status = Enums.Status.Disabled
            };

            //if (product.Status == Enums.Status.Disabled || product.Status == Enums.Status.Pending)
            //if(ValidationHelper.ProductPendingOrDisabled(product.Status))
            //{
            //    Console.WriteLine($"The current product is {product.Status}");
            //}
        }
    }
}
