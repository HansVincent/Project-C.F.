using Project_C.F_.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_C.F_.Model
{
    public partial class Employee_Worktimes : MainViewModel
    {
        private DateTime _TimeIn;
        private DateTime _TimeOut;

        public DateTime TimeIn
        {
            get { return _TimeIn; }
            set { _TimeIn = value; OnPropertyChanged(); OnPropertyChanged(nameof(_TimeIn)); }
        }
        public DateTime TimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; OnPropertyChanged(); OnPropertyChanged(nameof(_TimeOut)); }
        }
    }
}
