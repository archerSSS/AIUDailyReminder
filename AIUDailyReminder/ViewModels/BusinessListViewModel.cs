using AIUDailyReminder.Actions;
using AIUDailyReminder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace AIUDailyReminder.ViewModels
{
    public class BusinessListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BusinessUnit> businessList;
        private BusinessUnit business;
        private BusinessUnit newBusiness;
        private Stack<BusinessUnit> newBusinesses;
        private DateTime currentDate;
        private BusinessUnit alertBusiness;
        private bool isDescriptionEnabled;
        private bool isAlertVisible;
        private ICommand relayCommand;
        
        public ObservableCollection<BusinessUnit> BusinessList { get { return businessList; } set { businessList = value; } }
        public BusinessUnit Business { get { return business; }set { business = value; } }
        public BusinessUnit NewBusiness { get { return newBusiness; } set { newBusiness = value; OnPropertyChanged("NewBusiness"); } }
        public BusinessUnit AlertBusiness { get { return alertBusiness; } set { alertBusiness = value; OnPropertyChanged("AlertBusiness"); } }
        public bool ThreadRunning { get; set; }
        public bool IsDescriptionEnabled { get { return isDescriptionEnabled; } set { isDescriptionEnabled = value; OnPropertyChanged("IsDescriptionEnabled"); } }
        public ICommand RelayCommand { get { if (relayCommand == null) relayCommand = new BusinessCommand(Executable, AddBusiness); return relayCommand; } set { relayCommand = value; OnPropertyChanged("RelayCommand"); } }


        public BusinessListViewModel()
        {
            BusinessList = new ObservableCollection<BusinessUnit>();
            newBusinesses = new Stack<BusinessUnit>();
            NewBusiness = new BusinessUnit() { RemindDate = DateTime.Now };
            IsDescriptionEnabled = true;
            isAlertVisible = false;

            currentDate = DateTime.Now;
            Thread t = new Thread(UpdateBusiness);
            t.Start();
        }


        private void UpdateBusiness()
        {
            Thread.Sleep(10000);

            if (!isAlertVisible)
            {
                if (newBusinesses.Count != 0)
                {
                    foreach (BusinessUnit BU in newBusinesses)
                    {
                        AddBusiness(BU);
                    }
                    newBusinesses.Clear();
                }


                if (AlertBusiness != null)
                {
                    IsDescriptionEnabled = false;
                    isAlertVisible = true;
                    //System.Windows.MessageBox.Show("dasssssssss");

                    //System.Windows.MessageBoxButton BUTT = System.Windows.MessageBoxButton;
                    //System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show(AlertBusiness.RemindDescription, AlertBusiness.Name, System.Windows.MessageBoxButton.YesNo);
                }


                foreach (BusinessUnit BU in BusinessList)
                {
                    if (BU.RemindDate.Year == currentDate.Year && BU.RemindDate.Month == currentDate.Month && BU.RemindDate.Day == currentDate.Day)
                    {
                        AlertBusiness = BU;
                        IsDescriptionEnabled = true;
                    }

                }
            }
            
            new Thread(UpdateBusiness).Start();
        }

        private void AddBusiness(BusinessUnit BU)
        {
            DateTime NewBusinessDate = BU.RemindDate;
            int index = 0;
            foreach (BusinessUnit B in BusinessList)
            {
                if (NewBusinessDate < B.RemindDate)
                {
                    index = BusinessList.IndexOf(B);
                    break;
                }
            }
            BusinessList.Insert(index, BU);
        }

        // Command Action Method
        private void AddBusiness(object o)
        {
            if (!string.IsNullOrEmpty(NewBusiness.Name) && !string.IsNullOrEmpty(NewBusiness.RemindDescription))
            {
                newBusinesses.Push(new BusinessUnit() { 
                    Name = NewBusiness.Name, 
                    RemindDescription = NewBusiness.RemindDescription, 
                    RemindDate = NewBusiness.RemindDate });
            }
        }

        // Command Func Method
        private bool Executable()
        {
            return true;
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
