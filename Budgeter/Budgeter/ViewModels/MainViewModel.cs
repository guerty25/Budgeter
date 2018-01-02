using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Budgeter;

namespace ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Account> Accounts { get; private set; }

        public ObservableCollection<RecurringBill> RecurringBills { get; private set; }

        public MainViewModel()
        {
            Accounts = new ObservableCollection<Account>(XMLConfig.Instance.Accounts);
            
            RecurringBills = new ObservableCollection<RecurringBill>();
        }

    }
}
