using Ex11.Interfaces;
using Ex11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex11.Services
{
    public class MeetingManager
    {
        private readonly IUserInterface _ui;
        private readonly List<Meeting> _meetings = new();

        public MeetingManager(IUserInterface ui)
        {
            _ui = ui;
        }

        public void AddMeeting(Meeting meeting)
        {
            meeting.Id = _meetings.Any() ? _meetings.Max(m => m.Id) + 1 : 1;
            _meetings.Add(meeting);
        }

        public List<Meeting> GetAllMeetings() => _meetings;

        public Meeting? FindById(int id) => _meetings.FirstOrDefault(m => m.Id == id);
    }
}
