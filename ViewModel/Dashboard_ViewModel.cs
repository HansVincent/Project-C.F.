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
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Project_C.F_.ViewModel
{
    [QueryProperty(nameof(EmployeeID), "id")]
    public partial class Dashboard_ViewModel: MainPage_ViewModel
    {
        private bool IsAdmin = false;
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
                IsAdmin = true;
                CurrentEmployee = new Employee()
                {
                    FullName = "Administrator",
                    JobPosition = "Human Resource"
                };
            }
            else
            {
                foreach (var employee in Employee_Services.GetEmployees())
                {
                    if (EmployeeID == employee.EmployeeID)
                    {
                        CurrentEmployee = employee;
                    }
                }
            }
        }
        private void GoOnline()
        {
            if(!IsAdmin) 
            {
                CurrentEmployee.ActivtiyStatus = "Active";
                Employee_Services.UpdateEmployeeCollection(CurrentEmployee);
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
            if(!IsAdmin)
            {
                CurrentEmployee.ActivtiyStatus = "Inactive";
                Employee_Services.UpdateEmployeeCollection(CurrentEmployee);
            }
            Shell.Current.Navigation.PopToRootAsync();
        }
        public ICommand LogoutIconCommand => new Command(LogoutIcon);

        private void AddEmployeePage()
        {
            Shell.Current.GoToAsync($"{nameof(Dashboard_AddEmployee)}?id={EmployeeID}",false);
        }
        public ICommand AddEmployeePageCommand => new Command(AddEmployeePage);
        private void EmployeeDetailsPage()
        {
            Shell.Current.GoToAsync($"{nameof(Dashboard_EmployeeDetails)}?id={EmployeeID}",false);
        }
        public ICommand EmployeeDetailsPageCommand => new Command(EmployeeDetailsPage);
        private void UpdateEmployeePage()
        {
            Shell.Current.GoToAsync($"{nameof(Dashboard_UpdateEmployee)}?id={EmployeeID}", false);
        }
        public ICommand UpdateEmployeePagePageCommand => new Command(UpdateEmployeePage);
        private void DashboardViewWorktimePage()
        {
            Shell.Current.GoToAsync($"{nameof(Dashboard_ViewWorktime)}?id={EmployeeID}", false);
        }
        public ICommand DashboardViewWorktimePageCommand => new Command(DashboardViewWorktimePage);

        private void DashboardViewPayslipsPage()
        {
            Shell.Current.GoToAsync($"{nameof(Dashboard_ViewEmployeePayslips)}?id={EmployeeID}", false);
        }
        public ICommand DashboardViewPayslipsPageCommand => new Command(DashboardViewPayslipsPage);
        [RelayCommand]
        private async Task GoToMessaging() => await Shell.Current.GoToAsync(nameof(Dashboard_ViewMessages), false);

        //Employee Commands
        private void EmployeeOnlyHomePage()
        {
            Shell.Current.GoToAsync($"{nameof(Employee_Dashboard_Home)}?id={EmployeeID}", false);
        }
        public ICommand EmployeeOnlyHomePageCommand => new Command(EmployeeOnlyHomePage);

        private void EmployeeOnlyDetailsPage()
        {
            Shell.Current.GoToAsync($"{nameof(Employee_Dashboard_EmployeeDetails)}?id={EmployeeID}", false);
        }
        public ICommand EmployeeOnlyDetailsPageCommand => new Command(EmployeeOnlyDetailsPage);
        private void EmployeeWorktimePage()
        {
            Shell.Current.GoToAsync($"{nameof(Employee_Dashboard_Worktime)}?id={EmployeeID}", false);
        }
        public ICommand EmployeeWorktimePageCommand => new Command(EmployeeWorktimePage);
        private void EmployeeOnlyPayslipPage()
        {
            Shell.Current.GoToAsync(nameof(Employee_Dashboard_Payslip), false);
        }
        public ICommand EmployeePayslipPageCommand => new Command(EmployeeOnlyPayslipPage);

    }
}
