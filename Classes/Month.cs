using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarWPF.Classes
{
    public enum MonthName
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        Septemeber,
        October,
        November,
        December
    };
    public class Month
    {
        public List<Day> Days { get; set; }
        public MonthName Name { get; set; }
    }
}
