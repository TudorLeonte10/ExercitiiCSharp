using Ex14.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex14.Models;

namespace Ex14.Services
{
    public class BankService : IBankService
    {
        public void Deposit(BankAccount account, decimal amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            account.AddFunds(amount);
        }

        public decimal GetBalance(BankAccount account)
        {
            return account.Balance;
        }

        public void Withdraw(BankAccount account, decimal amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }

            if(account.Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds for this withdrawal.");
            }

            account.RemoveFunds(amount);
        }
    }
}
