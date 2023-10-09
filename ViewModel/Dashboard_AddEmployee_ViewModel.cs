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
    [QueryProperty(nameof(EmployeeID), "id")]
    public partial class Dashboard_AddEmployee_ViewModel : Dashboard_ViewModel
    {
        //Entry From Login
        private readonly Employee_Services employee_Services;
        public Dashboard_AddEmployee_ViewModel()
        {
            NewEmployee = new Employee();
            employee_Services = new Employee_Services();
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
            get { return _EmployeeIDEntry; }
            set
            {
                _EmployeeIDEntry = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeeIDEntry));
                if (EmployeeIDEntry.All(char.IsDigit) || string.IsNullOrEmpty(EmployeeIDEntry))
                {
                    NewEmployee.EmployeeID = EmployeeIDEntry;
                }
                else
                {
                    Shell.Current.DisplayAlert("Employee ID", "Required. Numeric values only", "okay");
                }
            }
        }
        private bool ExistingID()
        {
            foreach (var employee in employee_Services.GetEmployees())
            {
                if (NewEmployee.EmployeeID == employee.EmployeeID)
                {
                    Shell.Current.DisplayAlert("Employee ID", "Employee ID has been found in the database. Register new ID", "Okay");
                    return true;
                }
            }
            return false;
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

        private bool ValidateEntries()
        {
            if (string.IsNullOrEmpty(NewEmployee.EmployeeID) || string.IsNullOrEmpty(NewEmployee.Password) || string.IsNullOrEmpty(NewEmployee.FullName) || string.IsNullOrEmpty(NewEmployee.ContactNumber) || string.IsNullOrEmpty(NewEmployee.Gender)  || string.IsNullOrEmpty(NewEmployee.JobPosition) || string.IsNullOrEmpty(NewEmployee.Country) || string.IsNullOrEmpty(NewEmployee.HomeAddress) || string.IsNullOrEmpty(NewEmployee.ProvincialAddress) || (NewEmployee.BirthDate == DateToday))
            {
                return false;
            }
            if (ExistingID())
            {
                return false;
            }
            return true;
        }
        private void AddEmployee()
        {
            if (ValidateEntries())
            {
                employee_Services.AddEmployee(NewEmployee);
                Shell.Current.DisplayAlert("Adding Employee Sucess", "The Employee has been added to the database", "Okay");
                ClearEntries();
            }
            else
            {
                Shell.Current.DisplayAlert("Entries not filled", "Fill in all entries to add employee", "Okay");
            }
        }
        public ICommand AddEmployeeCommand => new Command(AddEmployee);

        private void ClearEntries()
        {
            EmployeeIDEntry = string.Empty;
            NewEmployee.FullName = string.Empty;
            NewEmployee.Email = string.Empty;
            NewEmployee.Password = string.Empty;
            EmployeeMobileNOEntry = string.Empty;
            NewEmployee.Gender = string.Empty;
            NewEmployee.JobPosition = string.Empty;
            NewEmployee.Country = string.Empty;
            NewEmployee.HomeAddress = string.Empty;
            NewEmployee.ProvincialAddress = string.Empty;
            NewEmployee.BirthDate = DateToday;
        }
        public ICommand ClearEntriesCommand => new Command(ClearEntries);
    }
}
