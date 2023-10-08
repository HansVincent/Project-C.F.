using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project_C.F_.Model;
using Project_C.F_.Services;
using Project_C.F_.View;

namespace Project_C.F_.ViewModel
{
    public partial class LoginPage_ViewModel : MainViewModel
    {
        private readonly Employee_Services Employee_Services;
        private void BackImage()
        {
            Shell.Current.GoToAsync("..");
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

        private void SignIn()
        {
            string EmployeeID = string.Empty;
            if(EmployeeIDEntry == "00000" && EmployeePassword == "admin101")
            {
                EmployeeID = "00000";
                Shell.Current.GoToAsync($"{nameof(Dashboard)}?id={EmployeeID}");
            }
        }
    }
}
