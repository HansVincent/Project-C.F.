using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls.Internals;
using Project_C.F_.Model;
using Project_C.F_.Services;
using Project_C.F_.View;

namespace Project_C.F_.ViewModel
{
    public partial class LoginPage_ViewModel : MainViewModel
    {
        public LoginPage_ViewModel() 
        {
            employee_Services = new Employee_Services();
        }
        private readonly Employee_Services employee_Services;
        private void BackImage()
        {
            Shell.Current.Navigation.PopToRootAsync();
        }
        public ICommand BackImageCommand => new Command(BackImage);
        private string _EmployeeIDEntry;
        public string EmployeeIDEntry
        {
            get { return _EmployeeIDEntry; } 
            set 
            {
                _EmployeeIDEntry = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeeIDEntry));
            }
        }
        private string _EmployeePassword;
        public string EmployeePassword
        {
            get { return _EmployeePassword; }
            set
            {
                _EmployeePassword = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeePassword));
            }
        }
        private bool IDExisting()
        {
            bool existing = false;
            foreach(var employee in employee_Services.GetEmployees())
            {
                if (EmployeeIDEntry == employee.EmployeeID && EmployeePassword == employee.Password)
                {
                    existing = true;
                }
            }
            return existing;
        }
        private void SignIn()
        {
            bool IsEmployee = false;
            string EmployeeID = string.Empty;
            if(EmployeeIDEntry == "00000" && EmployeePassword == "admin101")
            {
                Shell.Current.DisplayAlert("Login Sucess", "Logging into your account...", "Okay");
                EmployeeID = "00000";
                Shell.Current.GoToAsync($"{nameof(Dashboard_Home)}?id={EmployeeID}");
            }
            else if(IDExisting())
            {
                Shell.Current.DisplayAlert("Login Sucess", "Logging into your account...", "Okay");
                EmployeeID = EmployeeIDEntry;
                foreach (var employee in employee_Services.GetEmployees())
                {
                    if (employee.JobPosition == "Employee" && employee.EmployeeID == EmployeeID)
                    {
                        IsEmployee = true;
                    }
                }
                if(IsEmployee) 
                {
                    Shell.Current.GoToAsync($"{nameof(Employee_Dashboard_Home)}?id={EmployeeID}");
                }
                else
                {
                    Shell.Current.GoToAsync($"{nameof(Dashboard_Home)}?id={EmployeeID}");
                }
            }
            else
            {
                Shell.Current.DisplayAlert("Account Not Found", "Your Account was not found in the database", "Okay");
            }
         }
        public ICommand SignInCommand => new Command(SignIn);
    }
}