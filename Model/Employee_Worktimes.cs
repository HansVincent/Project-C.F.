using CommunityToolkit.Mvvm.ComponentModel;
using Project_C.F_.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_C.F_.Model
{
    public partial class Employee_Worktimes : ObservableObject
    {
        [ObservableProperty]
        private DateTime timeIn;
        [ObservableProperty]
        private DateTime timeOut;
        [ObservableProperty]
        private DateTime overtimes;
        [ObservableProperty]
        private DateTime undertimes;
        [ObservableProperty]
        private DateTime lates;
        [ObservableProperty]
        private DateTime hoursWorked;
        [ObservableProperty]
        private DateTime month;
        [ObservableProperty]
        private DateTime year;
    }
}
