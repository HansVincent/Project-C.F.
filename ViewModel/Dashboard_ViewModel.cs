using Project_C.F_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_C.F_.ViewModel
{
    [QueryProperty(nameof(EmployeeID), "id")]
    public partial class Dashboard_ViewModel: MainViewModel
    {
        //Entry From Login
        private string _EmployeeID;
        public string EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeeID)); }
        }
        public Dashboard_ViewModel()
        {
            NewEmployee = new Employee();
        }

        //Add Employee
        private Employee _NewEmployee;
        public Employee NewEmployee
        {
            get { return _NewEmployee; }
            set { _NewEmployee = value; OnPropertyChanged(); OnPropertyChanged(nameof(_NewEmployee)); }
        }

        public List<string> JobPositions { get; } = new()
        {
            "Employee",
            "Human Resource"
        };
        public List<string> Genders { get; } = new()
        {
            "Male",
            "Female"
        };
        private string _EmployeeIDEntry;
        public string EmployeeIDEntry
        {
            get { return _EmployeeID; }
            set
            {
                _EmployeeID = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeeIDEntry));
                if(EmployeeIDEntry.All(char.IsDigit) || string.IsNullOrEmpty(EmployeeIDEntry))
                {
                    NewEmployee.EmployeeID = EmployeeIDEntry;
                }
                else
                {
                    Shell.Current.DisplayAlert("Employee ID", "Required. Numeric values only", "okay");
                }
            }
        }
        private string _EmployeeMobileNOEntry;
        public string EmployeeMobileNOEntry
        {
            get { return _EmployeeMobileNOEntry; }
            set
            {
                _EmployeeMobileNOEntry = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeeMobileNOEntry));
                if (EmployeeMobileNOEntry.All(char.IsDigit) || string.IsNullOrEmpty(EmployeeMobileNOEntry))
                {
                    NewEmployee.ContactNumber = EmployeeMobileNOEntry;
                }
                else
                {
                    Shell.Current.DisplayAlert("Employee ID", "Required. Numeric values only", "okay");
                }
            }
        }
        private DateTime _DateToday = DateTime.Today;
        public DateTime DateToday
        {
            get { return _DateToday; }
            set { _DateToday = value; }
        }
    }
}
