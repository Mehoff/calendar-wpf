using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarWPF.Classes
{
    public enum DayOfWeek
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }
    public class Day
    {
        public int Number { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public static int GetMonthDaysCount(MonthName month) 
        {
            switch (month) 
            {
                case MonthName.January:
                    return 31;
                case MonthName.February:
                    return 28;
                case MonthName.March:
                    return 31;
                case MonthName.April:
                    return 30;
                case MonthName.May:
                    return 31;
                case MonthName.June:
                    return 30;
                case MonthName.July:
                    return 31;
                case MonthName.August:
                    return 31;
                case MonthName.Septemeber:
                    return 30;
                case MonthName.October:
                    return 31;
                case MonthName.November:
                    return 30;
                case MonthName.December:
                    return 31;
                default: throw new Exception("Undefined month name exception");
            }
        }
    }
}
