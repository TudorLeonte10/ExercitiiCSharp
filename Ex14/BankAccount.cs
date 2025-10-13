using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ex14
{
    internal class BankAccount
    {
        public string AccNumber {  get; set; }
        public string Owner { get; set; }
        public decimal Sold { get; set; }

        public BankAccount(string accNumber, string owner, decimal sold = 0)
        {
            AccNumber = accNumber;
            Owner = owner;
            Sold = sold;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("suma depusa trebuie sa fie pozitiva");
            }
            else
            {
                Sold += amount;
            }
        }

        public void WithDraw(decimal amount)
        {
            if (amount > Sold)
            {
                throw new ArgumentException("suma retrasa trebuie sa fie cel putin egala cu soldul");
            }
            else
            {
                Sold -= amount;
            }
        }

        public void DisplaySold()
        {
            Console.WriteLine($"Contul are {Sold} lei");
        }
    }
}
