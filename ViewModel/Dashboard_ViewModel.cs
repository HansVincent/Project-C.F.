using Microsoft.Maui.Controls.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_C.F_.View;
using System.Windows.Input;
using Project_C.F_.Model;
using Project_C.F_.Services;

namespace Project_C.F_.ViewModel
{
    [QueryProperty(nameof(EmployeeID), "id")]
    public partial class Dashboard_ViewModel: MainViewModel
    {

        private string _EmployeeID;
        public string EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeeID)); InitializeCurrentEmployee();
            }
        }
        public Dashboard_ViewModel()
        {
            employee_Services = new Employee_Services();
        }
        private readonly Employee_Services employee_Services;
        private void InitializeCurrentEmployee()
        {
            if(EmployeeID == "00000")
            {
                CurrentEmployee = new Employee()
                {
                    FullName = "Administrator"
                };
            }
            else
            {
                foreach (var employee in employee_Services.GetEmployees())
                {
                    if (EmployeeID == employee.EmployeeID)
                    {
                        CurrentEmployee = employee;
                    }
                }
            }
        }
        private Employee _CurrentEmployee;
        public Employee CurrentEmployee
        {
            get { return _CurrentEmployee; }
            set { _CurrentEmployee = value; OnPropertyChanged(); OnPropertyChanged(nameof(_CurrentEmployee)); } 
        }
        private void HomeIcon()
        {
            Shell.Current.GoToAsync($"{nameof(Dashboard_Home)}?id={EmployeeID}");
        }
        public ICommand HomeIconCommand => new Command(HomeIcon);
        private void LogoutIcon()
        {
            Shell.Current.Navigation.PopToRootAsync();
        }
        public ICommand LogoutIconCommand => new Command(LogoutIcon);
        private void AddEmployeePage()
        {
            Shell.Current.GoToAsync($"{nameof(Dashboard_AddEmployee)}?id={EmployeeID}", false);
        }
        public ICommand AddEmployeePageCommand => new Command(AddEmployeePage);
    }
}
