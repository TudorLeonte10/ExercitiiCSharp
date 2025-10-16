using Ex20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex20.Interfaces
{
    public interface IAttendanceRepository
    {
        List<AttendanceRecord> GetAll();
        void Add(AttendanceRecord record);
        void SaveChanges();
    }
}
