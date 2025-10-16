using Ex20.Interfaces;
using Ex20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ex20.Repositories
{
    public class JsonAttendanceRepository : IAttendanceRepository
    {
        private readonly string _filePath;
        private List<AttendanceRecord> _records = new();

        public JsonAttendanceRepository()
        {
            string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "AttendanceSystem");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            _filePath = Path.Combine(folder, "attendance.json");
            Console.WriteLine($"Data file: {_filePath}");

            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _records = JsonSerializer.Deserialize<List<AttendanceRecord>>(json) ?? new();
            }
        }

        public List<AttendanceRecord> GetAll() => _records;

        public void Add(AttendanceRecord record)
        {
            _records.Add(record);
            SaveChanges();
        }

        public void SaveChanges()
        {
            string json = JsonSerializer.Serialize(_records, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
