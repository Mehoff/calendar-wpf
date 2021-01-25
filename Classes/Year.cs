using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarWPF.Classes
{
   
    public class Year
    {
        const int MONTHS_COUNT = 12;
        public List<Month> Months { get; set; }

        public Year() 
        {
            GenerateYear();
        }

        private void GenerateYear() 
        {
            Months = new List<Month>(MONTHS_COUNT);

            Month[] months = new Month[MONTHS_COUNT];
            
            int DayOfWeekCount = 0;
            int MonthNameCounter = 0;

            for (int MONTH_INDEX = 0; MONTH_INDEX < MONTHS_COUNT; MONTH_INDEX++) 
            {
                months[MONTH_INDEX] = new Month();
                months[MONTH_INDEX].Name = (MonthName)MonthNameCounter;

                int DaysInMonth = Day.GetMonthDaysCount((MonthName)MonthNameCounter);

                months[MONTH_INDEX].Days = new List<Day>(DaysInMonth);

                Day[] days = new Day[DaysInMonth];

                for (int DAY_COUNT = 1; DAY_COUNT <= months[MONTH_INDEX].Days.Capacity; DAY_COUNT++) 
                {
                    days[DAY_COUNT - 1] = new Day();
                    days[DAY_COUNT - 1].Number = DAY_COUNT;
                    days[DAY_COUNT - 1].DayOfWeek = (DayOfWeek)DayOfWeekCount;

                    DayOfWeekCount++;

                    if (DayOfWeekCount > 6)
                        DayOfWeekCount = 0;
                }
                months[MONTH_INDEX].Days.AddRange(days);
                MonthNameCounter++;
            }
            Months.AddRange(months);
        }
    }
}
