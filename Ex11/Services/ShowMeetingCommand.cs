using Ex11.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex11.Services
{
    public class ShowMeetingsCommand : ICommand
    {
        public string Name => "show";
        private readonly MeetingManager _manager;
        private readonly IUserInterface _ui;

        public ShowMeetingsCommand(MeetingManager manager, IUserInterface ui)
        {
            _manager = manager;
            _ui = ui;
        }

        public void Execute()
        {
            var meetings = _manager.GetAllMeetings();

            if (!meetings.Any())
            {
                _ui.ShowMessage("No meetings scheduled.");
                return;
            }

            _ui.ShowMessage("\nList of meetings:");
            _ui.ShowMessage(" ID | Participants           | Date & Time         | Status");
            _ui.ShowMessage("----+------------------------+---------------------+---------");
            foreach (var meeting in meetings)
            {
                _ui.ShowMessage(meeting.ToString());
            }
        }
    }
}
