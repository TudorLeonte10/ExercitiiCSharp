using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex20
{
    internal class AttendanceSystem
    {
        private readonly List<Timecard> _timecards = new();
        private readonly List<Employee> _employees = new();
        private readonly int _buldingCapacity;

        public AttendanceSystem(int buldingCapacity)
        {
            _buldingCapacity = buldingCapacity;
        }

        public void AddEmployee(string name)
        {
            if(_employees.Any(e => e.Name.Equals(name)))
            {
                Console.WriteLine($"Angajatul {name} exista deja.");
                return;
            }

            _employees.Add(new Employee(name));
            Console.WriteLine($"Angajat adaugat: {name}");
        }

        public void AddAttendance(string name, DateTime date)
        {
           var employee = _employees.FirstOrDefault(e => e.Name.Equals(name));
            if(employee == null)
            {
                Console.WriteLine($"Angajatul {name} nu exista.");
                return;
            }
            
            if(_timecards.Any(t => t.Employee == employee && t.Date.Date == date.Date))
            {
                Console.WriteLine($"Angajatul {name} si-a inregistrat deja prezenta pentru data {date:dd.MM.yyyy}.");
                return;
            }

            _timecards.Add(new Timecard(employee, date));
            Console.WriteLine($"Prezenta inregistrata pentru {name} la data {date:dd.MM.yyyy}.");
        }

        public void AttendanceReport()
        {
            if(_timecards.Count == 0)
            {
                Console.WriteLine("Nicio prezenta");
                return;
            }

            int totalEmployees = _employees.Count;
            int totalDays = _timecards.Select(t => t.Date).Distinct().Count();

            foreach(var emp in _employees)
            {
                int prezente = _timecards.Count(t => t.Employee == emp);
                Console.WriteLine($"{emp.Name}: {prezente} prezente");
            }

            double totalPrezente = _timecards.Count;
            double prezentePosibile = totalEmployees * totalDays;
            double procent = (totalPrezente / prezentePosibile) * 100;

            Console.WriteLine($"Total angajati: {totalEmployees}");
            Console.WriteLine($"Zile distincte de prezenta: {totalDays}");
            Console.WriteLine($"Capacitate maxima cladire: {_buldingCapacity}");
            Console.WriteLine($"Procent de ocupare: {procent:F2}%");

            var employeesBelowRequirement = _employees
                .Where(e => _timecards.Count(t => t.Employee == e) < Employee.DaysRequired)
                .ToList();

            if (employeesBelowRequirement.Count == 0)
                Console.WriteLine("Toti angajatii au respectat prezenta saptamanala");
            else
            {
                 Console.WriteLine("Angajatii care nu au respectat prezenta saptamanala:"); 
                 foreach(var emp in employeesBelowRequirement)
                     Console.WriteLine(emp.Name);
            }
        }
    }
}
