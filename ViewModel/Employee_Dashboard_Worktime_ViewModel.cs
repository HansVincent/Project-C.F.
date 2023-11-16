using Project_C.F_.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_C.F_.ViewModel
{
    public partial class Employee_Dashboard_Worktime_ViewModel : Dashboard_ViewModel
    {
        private ObservableCollection<Employee_Worktimes> _EmployeeWorktimes;
        public ObservableCollection<Employee_Worktimes> EmployeeWorktimes
        {
            get { return _EmployeeWorktimes; }
            set { _EmployeeWorktimes = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeeWorktimes)); }
        }
        public Employee_Dashboard_Worktime_ViewModel()
        {
            DateToday = DateOnly.FromDateTime(DateTime.Today);
            TimeNow = TimeOnly.FromDateTime(DateTime.Now);
            EmployeeWorktimes = CurrentEmployee.Worktimes;
        }

        private DateOnly dateToday;
        public DateOnly DateToday
        {
            get { return dateToday; }
            set { dateToday = value; OnPropertyChanged(); OnPropertyChanged(nameof(dateToday)); }
        }
        private TimeOnly timeNow;
        public TimeOnly TimeNow
        {
            get { return timeNow; }
            set { timeNow = value; OnPropertyChanged(); OnPropertyChanged(nameof(timeNow)); }
        }
    }
}
