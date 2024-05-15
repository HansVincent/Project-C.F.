using Project_C.F_.Model;
using Project_C.F_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project_C.F_.ViewModel
{
    [QueryProperty(nameof(HighlightedEmployeeEmployeeID), "highlightedemployeeid")]
    public partial class Dashboard_ViewEmployeeWorktime_ViewModel : Dashboard_ViewModel
    {
        public Dashboard_ViewEmployeeWorktime_ViewModel()
        {
            employee_Services = new Employee_Services();
            optimalTimeIn = DateTime.Today.AddHours(7);
            optimalTimeOut = DateTime.Today.AddHours(16);
            DateToday = DateOnly.FromDateTime(DateTime.Today);
            timeCompare = TimeOnly.MinValue;
            TimeNow = TimeOnly.FromDateTime(DateTime.Now);
            DateSimulation = DateToday.ToDateTime(TimeOnly.MinValue);
            TimeInSimulated = DateTime.Now;
            TimeOutSimulated = DateTime.Now;
        }
        private DateTime optimalTimeIn;
        private DateTime optimalTimeOut;
        private TimeOnly timeCompare;
        private DateTime dateException;
        private readonly Employee_Services employee_Services;

        private string _HighlightedEmployeeEmployeeID;
        public string HighlightedEmployeeEmployeeID
        {
            get { return _HighlightedEmployeeEmployeeID; }
            set
            {
                _HighlightedEmployeeEmployeeID = value; OnPropertyChanged(); OnPropertyChanged(nameof(_HighlightedEmployeeEmployeeID)); InitializeCurrentEmployee();
            }
        }
        private void InitializeCurrentEmployee()
        {
            foreach (var employee in Employee_Services.GetEmployees())
            {
                if (HighlightedEmployeeEmployeeID == employee.EmployeeID)
                {
                    HighlightedEmployee = employee;
                }
            }
            
        }
        private Employee highlightedEmployee;
        public Employee HighlightedEmployee
        {
            get { return highlightedEmployee; }
            set { highlightedEmployee = value; OnPropertyChanged(); OnPropertyChanged(nameof(highlightedEmployee)); }
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
        private DateTime _DateSimulation;
        public DateTime DateSimulation
        {
            get { return _DateSimulation; }
            set { _DateSimulation = value; OnPropertyChanged(); OnPropertyChanged(nameof(_DateSimulation)); }
        }
        private TimeSpan _TimeInSimulation;
        public TimeSpan TimeInSimulation
        {
            get { return _TimeInSimulation; }
            set { _TimeInSimulation = value; OnPropertyChanged(); OnPropertyChanged(nameof(_TimeInSimulation)); }
        }
        private TimeSpan _TimeOutSimulation;
        public TimeSpan TimeOutSimulation
        {
            get { return _TimeOutSimulation; }
            set { _TimeOutSimulation = value; OnPropertyChanged(); OnPropertyChanged(nameof(_TimeOutSimulation)); }
        }
        private DateTime _TimeIn;
        public DateTime TimeInSimulated
        {
            get { return _TimeIn; }
            set { _TimeIn = value; OnPropertyChanged(); OnPropertyChanged(nameof(_TimeIn)); }
        }
        private DateTime _TimeOut;
        public DateTime TimeOutSimulated
        {
            get { return _TimeOut; }
            set { _TimeOut = value; OnPropertyChanged(); OnPropertyChanged(nameof(_TimeOut)); }
        }

        private Employee_Worktimes SimulationWorkTimes = new();

        private void Simulate()
        {
            SetDates();
            TimeSpan theduration;
            if (TimeOutSimulated.Hour == timeCompare.Hour)
            {
                dateException = TimeOutSimulated;
                dateException = dateException.AddDays(1);
                theduration = dateException - TimeInSimulated;
            }
            else
            {
                theduration = TimeOutSimulated - TimeInSimulated;
            }    
            SimulationWorkTimes.HoursWorked = SimulationWorkTimes.HoursWorked.Add(theduration);
            if(optimalTimeIn < TimeInSimulated)
            {
                theduration = TimeInSimulated - optimalTimeIn;
                SimulationWorkTimes.Lates = SimulationWorkTimes.Lates.Add(theduration);
            }
            if(optimalTimeOut < TimeOutSimulated && TimeOutSimulated.Hour != timeCompare.Hour)
            {
                theduration = TimeOutSimulated - optimalTimeOut;
                SimulationWorkTimes.Overtimes = SimulationWorkTimes.Overtimes.Add(theduration);
            }
            else if(TimeOutSimulated.Hour == timeCompare.Hour)
            {
                dateException = TimeOutSimulated;
                dateException = dateException.AddDays(1);
                theduration = dateException - optimalTimeOut;
                SimulationWorkTimes.Overtimes = SimulationWorkTimes.Overtimes.Add(theduration);
            }
            SimulationWorkTimes.TimeIn = TimeInSimulated;
            SimulationWorkTimes.TimeOut = TimeOutSimulated;
            HighlightedEmployee.Worktimes.Add(SimulationWorkTimes);
            Shell.Current.DisplayAlert("Simulate Worktime", "Worktime Simulation Successful", "Okay");
            Employee_Services.UpdateEmployeeCollection(HighlightedEmployee);
            SimulationWorkTimes = new Employee_Worktimes();
        }
        public ICommand SimulateCommand => new Command(Simulate);
        private void SetDates()
        {
            TimeInSimulated = DateSimulation;
            TimeInSimulated += TimeInSimulation;
            TimeOutSimulated = DateSimulation;
            TimeOutSimulated += TimeOutSimulation;
        }
    }
}
