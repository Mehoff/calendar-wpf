using CalendarWPF.Classes;
using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();   
        }

        private void MonthRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;


            LoadMonth((MonthName)Convert.ToInt32(button.Tag));
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Year = new Year();
        }
        private void LoadMonth(MonthName month) 
        {
            StringBuilder sb = new StringBuilder();

            var _month = Year.Months[(int)month];

            sb.Append(_month.Name + "\n");
            foreach (var day in _month.Days) 
            {
                sb.Append($" {day.Number} | {day.DayOfWeek}\n");
            }

            MessageBox.Show(sb.ToString());
        }


    }
}
