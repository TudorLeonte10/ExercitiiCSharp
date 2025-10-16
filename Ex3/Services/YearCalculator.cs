using Ex3.Interfaces;
using Ex3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Services
{
    public class YearCalculator
    {
        private readonly IYearRule _leapRule;
        private readonly IHolidayProvider _holidayProvider;

        public YearCalculator(IYearRule leapRule, IHolidayProvider holidayProvider)
        {
            _leapRule = leapRule;
            _holidayProvider = holidayProvider;
        }

        public YearInfo Analyze(int year)
        {
            var info = new YearInfo
            {
                Year = year,
                IsLeapYear = _leapRule.Evaluate(year),
                TotalDays = DateTime.IsLeapYear(year) ? 366 : 365
            };

            var holidays = _holidayProvider.GetHolidays(year).ToList();
            info.Holidays = holidays;

            int workDays = 0;
            var start = new DateTime(year, 1, 1);
            var end = new DateTime(year, 12, 31);

            for (var date = start; date <= end; date = date.AddDays(1))
            {
                bool isWeekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
                bool isHoliday = holidays.Any(h => h.Date.Date == date.Date);

                if (!isWeekend && !isHoliday)
                    workDays++;
            }

            info.WorkDays = workDays;
            info.Weeks = (int)Math.Ceiling(info.TotalDays / 7.0);

            return info;
        }
    }
}
