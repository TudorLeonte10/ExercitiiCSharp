using Ex11.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex11.Services
{
    public class ConfirmMeetingCommand : ICommand
    {
        public string Name => "confirm";
        private readonly MeetingManager _manager;
        private readonly IUserInterface _ui;

        public ConfirmMeetingCommand(MeetingManager manager, IUserInterface ui)
        {
            _manager = manager;
            _ui = ui;
        }

        public void Execute()
        {
            string idInput = _ui.GetInput("Enter meeting ID to confirm: ");
            if (!int.TryParse(idInput, out int id))
            {
                _ui.ShowMessage("Invalid ID.");
                return;
            }

            var meeting = _manager.FindById(id);
            if (meeting == null)
            {
                _ui.ShowMessage("Meeting not found.");
                return;
            }

            string name = _ui.GetInput("Enter your name to confirm: ").Trim();

            if (name.Equals(meeting.PersonA, StringComparison.OrdinalIgnoreCase))
                meeting.ConfirmedByA = true;
            else if (name.Equals(meeting.PersonB, StringComparison.OrdinalIgnoreCase))
                meeting.ConfirmedByB = true;
            else
            {
                _ui.ShowMessage("You are not part of this meeting.");
                return;
            }

            if (meeting.IsConfirmed)
            {
                _ui.ShowMessage($"Meeting confirmed by both {meeting.PersonA} and {meeting.PersonB}.");
                _ui.ShowMessage($"Scheduled for: {meeting.DateTime:dddd, MMMM dd yyyy, HH:mm}");
            }
            else
            {
                _ui.ShowMessage($"Meeting confirmed by {name}. Waiting for the other person to confirm.");
            }
        }
    }
}
