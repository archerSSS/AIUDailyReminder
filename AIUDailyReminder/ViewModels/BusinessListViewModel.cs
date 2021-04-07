using AIUDailyReminder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIUDailyReminder.ViewModels
{
    public class BusinessListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BusinessUnit> businessList;
        private BusinessUnit business;
        private Stack<BusinessUnit> newBusinesses;
        private bool threadRunning;
        private DateTime currentDate;
        private BusinessUnit alertBusiness;
        private bool isDescriptionEnabled;
        
        public ObservableCollection<BusinessUnit> BusinessList { get { return businessList; } set { businessList = value; } }
        public BusinessUnit Business { get { return business; }set { business = value; } }
        public BusinessUnit AlertBusiness { get { return alertBusiness; } set { alertBusiness = value; OnPropertyChanged("AlertBusiness"); } }
        public bool ThreadRunning { get; set; }
        public bool IsDescriptionEnabled { get { return isDescriptionEnabled; } set { isDescriptionEnabled = value; OnPropertyChanged("IsDescriptionEnabled"); } }

        public BusinessListViewModel()
        {
            BusinessList = new ObservableCollection<BusinessUnit>();
            newBusinesses = new Stack<BusinessUnit>();
            IsDescriptionEnabled = true;

            threadRunning = true;
            currentDate = DateTime.Now;
            Thread t = new Thread(UpdateBusiness);
            t.Start();
        }


        private void UpdateBusiness()
        {
            Thread.Sleep(20000);

            if (IsDescriptionEnabled) IsDescriptionEnabled = false;

            foreach (BusinessUnit BU in BusinessList)
            {
                if (BU.RemindDate.Year == currentDate.Year && BU.RemindDate.Month == currentDate.Month && BU.RemindDate.Day == currentDate.Day)
                    AlertBusiness = BU;
            }
            new Thread(UpdateBusiness).Start();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string pn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pn));
            }
        }
    }
}
