using Ex14.Interfaces;
using Ex14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex14.Services
{
    public class AccountManager
    {
        private readonly IUserInterface _ui;
        private readonly IBankService _service;
        public readonly BankAccount _account;

        public AccountManager(IUserInterface ui, IBankService service)
        {
            _ui = ui;
            _service = service;

            string accNum = _ui.GetInput("Enter account number: ");
            _account = new BankAccount(accNum, 0);
        }

        public void Run()
        {
            while (true)
            {
                _ui.ShowMessage("\nAvailable commands: deposit | withdraw | balance | exit");
                string command = _ui.GetInput("> ").Trim().ToLower();

                if (command == "exit")
                {
                    _ui.ShowMessage("Program ended.");
                    break;
                }

                switch (command)
                {
                    case "deposit":
                        HandleDeposit();
                        break;
                    case "withdraw":
                        HandleWithdraw();
                        break;
                    case "balance":
                        _ui.ShowMessage(_account.ToString());
                        break;
                    default:
                        _ui.ShowMessage("Unknown command.");
                        break;
                }
            }
        }

        private void HandleDeposit()
        {
            string amountInput = _ui.GetInput("Enter amount to deposit: ");
            if (!decimal.TryParse(amountInput, out decimal amount))
            {
                _ui.ShowMessage("Invalid amount.");
                return;
            }

            try
            {
                _service.Deposit(_account, amount);
                _ui.ShowMessage($"Deposit successful. Current balance: {_account.Balance:F2} RON");
            }
            catch (Exception ex)
            {
                _ui.ShowMessage($"Error: {ex.Message}");
            }
        }

        private void HandleWithdraw()
        {
            string amountInput = _ui.GetInput("Enter amount to withdraw: ");
            if (!decimal.TryParse(amountInput, out decimal amount))
            {
                _ui.ShowMessage("Invalid amount.");
                return;
            }

            try
            {
                _service.Withdraw(_account, amount);
                _ui.ShowMessage($"Withdrawal successful. Current balance: {_account.Balance:F2} RON");
            }
            catch (Exception ex)
            {
                _ui.ShowMessage($"Error: {ex.Message}");
            }
        }
    }

}

