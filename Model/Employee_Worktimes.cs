﻿using Project_C.F_.ViewModel;
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
        private DateTime overtimes;
        private DateTime lates;
        private DateTime hoursWorked;

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
        public DateTime Overtimes
        {
            get { return overtimes; }
            set { overtimes = value; OnPropertyChanged(); OnPropertyChanged(nameof(overtimes)); }
        }
        public DateTime Lates
        {
            get { return lates; }
            set { lates = value; OnPropertyChanged(); OnPropertyChanged(nameof(lates)); }
        }
        public DateTime HoursWorked
        {
            get { return hoursWorked; }
            set { hoursWorked = value; OnPropertyChanged(); OnPropertyChanged(nameof(hoursWorked)); }
        }
    }
}
