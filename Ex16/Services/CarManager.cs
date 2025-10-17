using Ex16.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex16.Models;

namespace Ex16.Services
{
    public class CarManager
    {
        private readonly IUserInterface _ui;
        private readonly ICarEvaluator _evaluator;

        public CarManager(IUserInterface ui, ICarEvaluator evaluator)
        {
            _ui = ui;
            _evaluator = evaluator;
        }

        public void Run()
        {
            _ui.ShowMessage("Car Information System\n");

            string model = _ui.GetInput("Enter car model: ");
            string yearInput = _ui.GetInput("Enter year of manufacture: ");
            if (!int.TryParse(yearInput, out int year) || year < 1900 || year > DateTime.Now.Year)
            {
                _ui.ShowMessage("Invalid year.");
                return;
            }

            string engineType = _ui.GetInput("Enter engine type (Petrol/Diesel/Hybrid/Electric): ");
            string consumptionInput = _ui.GetInput("Enter fuel consumption (liters/100km): ");
            string emissionInput = _ui.GetInput("Enter CO2 emissions (g/km): ");

            if (!double.TryParse(consumptionInput, out double consumption) || consumption < 0)
            {
                _ui.ShowMessage("Invalid consumption value.");
                return;
            }

            if (!double.TryParse(emissionInput, out double emissions) || emissions < 0)
            {
                _ui.ShowMessage("Invalid emission value.");
                return;
            }

            var car = new Car
            {
                Model = model,
                Year = year,
                EngineType = engineType,
                Consumption = consumption,
                Emissions = emissions
            };

            _ui.ShowMessage("\n--- Car Details ---");
            _ui.ShowMessage(car.ToString());

            string category = _evaluator.DetermineRablaCategory(car);
            _ui.ShowMessage($"\nRabla Program Evaluation: {category}");
        }
    }
}
