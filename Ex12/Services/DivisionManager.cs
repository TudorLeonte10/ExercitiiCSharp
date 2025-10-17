using Ex12.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Services
{
    public class DivisionManager
    {
        private readonly IDivisionService _service;
        private readonly IUserInterface _ui;

        public DivisionManager(IDivisionService service, IUserInterface ui)
        {
            _service = service;
            _ui = ui;
        }

        public void Run()
        {
            string num1Input = _ui.GetInput("Enter numerator (decimal): ");
            string num2Input = _ui.GetInput("Enter denominator (decimal): ");

            if (!decimal.TryParse(num1Input, out decimal numerator) ||
                !decimal.TryParse(num2Input, out decimal denominator))
            {
                _ui.ShowMessage("Invalid input. Please enter valid decimal numbers.");
                return;
            }

            try
            {
                decimal result = _service.Divide(numerator, denominator);
                _ui.ShowMessage($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                _ui.ShowMessage($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                _ui.ShowMessage($"An unexpected error occurred: {ex.Message}");
            }

        }
    }
}
