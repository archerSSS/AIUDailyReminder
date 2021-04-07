using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUDailyReminder.Models
{
    public class BusinessUnit
    {
        private DateTime remindDate;
        private string name;
        private string remindDescription;
        public DateTime RemindDate { get { return remindDate; } set { remindDate = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string RemindDescription { get { return remindDescription; } set { remindDescription = value; } }
    }
}
