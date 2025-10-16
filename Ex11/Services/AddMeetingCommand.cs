using Ex11.Interfaces;
using Ex11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex11.Services
{
    public class AddMeetingCommand : ICommand
    {
        public string Name => "add";
        private readonly MeetingManager _manager;
        private readonly IUserInterface _ui;

        public AddMeetingCommand(MeetingManager manager, IUserInterface ui)
        {
            _manager = manager;
            _ui = ui;
        }

        public void Execute()
        {
            string personA = _ui.GetInput("Enter first person's name: ");
            string personB = _ui.GetInput("Enter second person's name: ");
            string dateInput = _ui.GetInput("Enter meeting date (yyyy-MM-dd): ");
            string timeInput = _ui.GetInput("Enter meeting time (HH:mm): ");

            if (!DateTime.TryParse($"{dateInput} {timeInput}", out DateTime dateTime))
            {
                _ui.ShowMessage("Invalid date/time format.");
                return;
            }

            var meeting = new Meeting
            {
                PersonA = personA,
                PersonB = personB,
                DateTime = dateTime
            };

            _manager.AddMeeting(meeting);
            _ui.ShowMessage($"Meeting scheduled between {personA} and {personB} on {dateTime:dddd, MMM dd yyyy HH:mm}");
        }
    }
}
