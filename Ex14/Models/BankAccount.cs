using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex14.Models
{
    public class BankAccount
    {
        public string AccountNumber { get; set; } = string.Empty;
        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void AddFunds(decimal amount)
        {
            Balance += amount;
        }

        public void RemoveFunds(decimal amount)
        {
            Balance -= amount;
        }

        public override string ToString()
        {
            return $"Account: {AccountNumber} | Balance: {Balance:F2} RON";
        }
    }
}
