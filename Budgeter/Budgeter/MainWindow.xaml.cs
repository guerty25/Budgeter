using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Budgeter;
using ViewModels;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Budgeter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MainTab.DataContext = new MainViewModel();
            UpdateDaysBillsListBox();
            this.BillsCalendar.SelectedDatesChanged += BillsCalendar_SelectedDatesChanged;
  
        }

        private void BillsCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDaysBillsListBox();
        }

        private void UpdateDaysBillsListBox()
        {
            this.DayBillsListBox.Items.Clear();
            var selectedDate = this.BillsCalendar.SelectedDate;

            if (selectedDate == null)
            {
                selectedDate = DateTime.Today;
            }


            var daysBills = from bill in XMLConfig.Instance.RecurringBills
                            where bill.Date.Equals(selectedDate.Value.Date.Day)
                            select bill;

            foreach (var Bill in daysBills)
            {
                var listBoxItem = Bill.Name + ": " + Bill.Amount.ToString("C");
                this.DayBillsListBox.Items.Add(listBoxItem);
            }
        }

        private void UpdateDayBillsCalendar()
        {
            foreach(var Bill in XMLConfig.Instance.RecurringBills)
            {

            }
        }
    }
}
