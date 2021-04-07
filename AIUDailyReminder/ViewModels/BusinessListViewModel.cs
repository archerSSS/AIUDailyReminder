using AIUDailyReminder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUDailyReminder.ViewModels
{
    class BusinessListViewModel
    {
        private ObservableCollection<BusinessUnit> businessList;
        public ObservableCollection<BusinessUnit> BusinessList { get { return businessList; } set { businessList = value; } }

        BusinessListViewModel()
        {

        }
    }
}
