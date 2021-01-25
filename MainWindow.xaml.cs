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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Year Year { get; set; }
        public Month CurrentMonth { get; set; }

        public ObservableCollection<Week> Weeks { get; set; }

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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Year = new Year();
        }

        private void LoadWeeks(Month month) 
        {
            Weeks = new ObservableCollection<Week>();

            var week = new Week();
            int dayC = 0;
            for (int i = 0; i < month.Days.Count; i++) 
            {
                switch (month.Days[i].DayOfWeek) 
                {
                    case CalendarWPF.Classes.DayOfWeek.Monday:
                        week.Monday = month.Days[i].Number;
                        break;
                    case CalendarWPF.Classes.DayOfWeek.Tuesday:
                        week.Tuesday = month.Days[i].Number;
                        break;
                    case CalendarWPF.Classes.DayOfWeek.Wednesday:
                        week.Wednesday = month.Days[i].Number;
                        break;
                    case CalendarWPF.Classes.DayOfWeek.Thursday:
                        week.Thursday = month.Days[i].Number;
                        break;
                    case CalendarWPF.Classes.DayOfWeek.Friday:
                        week.Friday = month.Days[i].Number;
                        break;
                    case CalendarWPF.Classes.DayOfWeek.Saturday:
                        week.Saturday = month.Days[i].Number;
                        break;
                    case CalendarWPF.Classes.DayOfWeek.Sunday:
                        week.Sunday = month.Days[i].Number;
                        break;
                }
                dayC++;
                if (dayC == 7) 
                {
                    Weeks.Add(week);
                    week = new Week();
                    dayC = 0;
                }
                    
            }

        }
        private void LoadMonth(MonthName month) 
        {
            CurrentMonth = Year.Months[(int)month];
        }


    }
}
