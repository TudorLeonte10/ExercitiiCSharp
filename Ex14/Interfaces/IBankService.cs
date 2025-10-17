using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex14.Models;

namespace Ex14.Interfaces
{
    public interface IBankService
    {
        decimal GetBalance(BankAccount account);
        void Deposit(BankAccount account, decimal amount);
        void Withdraw(BankAccount account, decimal amount);
    }
}
