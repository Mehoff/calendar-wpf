using CalendarWPF.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalendatWPF
{
    public struct MarkedDay 
    {
        public Month Month { get; set; }
        public int Number { get; set; }
    };
    public partial class MainWindow : Window
    {

        public Year Year { get; set; }
        public Month CurrentMonth { get; set; }
        public ObservableCollection<Week> Weeks { get; set; }

        public List<MarkedDay> MarkedDays = new List<MarkedDay>();

        public MainWindow()
        {
            InitializeComponent();   
        }

        private void MonthRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;

            LoadMonth((MonthName)Convert.ToInt32(button.Tag));

            LoadWeeks(CurrentMonth);

            lsView.ItemsSource = Weeks;

        }
        private void DayClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (button.Content.ToString() == string.Empty)
                return;

            int number = Convert.ToInt32(button.Content.ToString());

            MessageBox.Show($"Помечено: {CurrentMonth.Name} {number}");

            button.Background = new SolidColorBrush(Colors.Green);

            bool foundFlag = false;

            foreach (var item in MarkedDays)
                if (item.Number == number && item.Month == CurrentMonth) 
                {
                    MarkedDays.Remove(item); foundFlag = true;
                    button.Background = new SolidColorBrush(Colors.WhiteSmoke);
                    break;
                }
                    
            if(!foundFlag)
                MarkedDays.Add(new MarkedDay { Month = CurrentMonth, Number = number });
            

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Year = new Year();
        }

        private void LoadWeeks(Month month) 
        {
            Weeks = new ObservableCollection<Week>();

            var week = new Week();
            for (int i = 0; i < month.Days.Count; i++) 
            {
                if (MarkedDays.Count(day => day.Month == CurrentMonth && day.Number == i) > 0) 
                {
                    MessageBox.Show($"{CurrentMonth.Name} - {i}");
                }

                switch (month.Days[i].DayOfWeek) 
                {
                    case CalendarWPF.Classes.DayOfWeek.Monday:
                        week = new Week();
                        week.Monday = month.Days[i].Number.ToString();
                        break;
                    case CalendarWPF.Classes.DayOfWeek.Tuesday:
                        week.Tuesday = month.Days[i].Number.ToString();
                        break;
                    case CalendarWPF.Classes.DayOfWeek.Wednesday:
                        week.Wednesday = month.Days[i].Number.ToString();
                        break;
                    case CalendarWPF.Classes.DayOfWeek.Thursday:
                        week.Thursday = month.Days[i].Number.ToString();
                        break;
                    case CalendarWPF.Classes.DayOfWeek.Friday:
                        week.Friday = month.Days[i].Number.ToString();
                        break;
                    case CalendarWPF.Classes.DayOfWeek.Saturday:
                        week.Saturday = month.Days[i].Number.ToString();
                        break;
                    case CalendarWPF.Classes.DayOfWeek.Sunday:
                        week.Sunday = month.Days[i].Number.ToString();
                        Weeks.Add(week);
                        week = new Week();
                        break;
                }
                if (i == month.Days.Count - 1 
                    && month.Days[i].DayOfWeek 
                    != CalendarWPF.Classes.DayOfWeek.Sunday)
                {
                    Weeks.Add(week);
                    week = new Week();
                }
            }

        }
        private void LoadMonth(MonthName month) 
        {
            CurrentMonth = Year.Months[(int)month];
        }



    }
}
