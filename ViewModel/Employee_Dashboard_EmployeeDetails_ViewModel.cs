using Project_C.F_.Model;
using Project_C.F_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_C.F_.ViewModel
{
    [QueryProperty(nameof(CollectCurrentEmployeeFullName), "id")]
    public partial class Employee_Dashboard_EmployeeDetails_ViewModel : Dashboard_ViewModel
    {
        private Employee highlightedEmployeee;
        public Employee HighlightedEmployeee
        {
            get { return highlightedEmployeee; }
            set { highlightedEmployeee = value; OnPropertyChanged(); OnPropertyChanged(nameof(highlightedEmployeee)); SetDateDetails(); }
        }

        public Employee_Dashboard_EmployeeDetails_ViewModel()
        {
            employee_Services = new Employee_Services();
            SetEmployee();
        }

        private void SetDateDetails()
        {
            HighlightEmployeeBirthday = HighlightedEmployeee.BirthDate.ToString("MM/dd/yyyy");
            HighlightEmployeeDateJoined = HighlightedEmployeee.DateJoined.ToString("MM/dd/yyyy");
        }
        private readonly Employee_Services employee_Services;


        private string _CollectCurrentEmployeeFullName;
        public string CollectCurrentEmployeeFullName
        {
            get { return _CollectCurrentEmployeeFullName; }
            set
            {
                _CollectCurrentEmployeeFullName = value; OnPropertyChanged(); OnPropertyChanged(nameof(_CollectCurrentEmployeeFullName));
            }
        }


        private void SetEmployee()
        {
            foreach (var employee in Employee_Services.GetEmployees())
            {
                if (employee.FullName == CollectCurrentEmployeeFullName)
                {
                    HighlightedEmployeee = new Employee
                    {
                        EmployeeID = employee.EmployeeID,
                        FullName = employee.FullName,
                        Email = employee.Email,
                        Password = employee.Password,
                        ContactNumber = employee.ContactNumber,
                        Gender = employee.Gender,
                        Image = employee.Image,
                        ActivtiyStatus = employee.ActivtiyStatus,
                        JobPosition = employee.JobPosition,
                        DateJoined = employee.DateJoined,
                        BirthDate = employee.BirthDate,
                        Country = employee.Country,
                        HomeAddress = employee.HomeAddress,
                        ProvincialAddress = employee.ProvincialAddress,
                        Worktimes = employee.Worktimes
                    };
                }
            }
        }

        private string highlightEmployeeBirthday;
        public string HighlightEmployeeBirthday
        {
            get { return highlightEmployeeBirthday; }
            set { highlightEmployeeBirthday = value; OnPropertyChanged(); OnPropertyChanged(nameof(highlightEmployeeBirthday)); }
        }
        private string highlightEmployeeDateJoined;
        public string HighlightEmployeeDateJoined
        {
            get { return highlightEmployeeDateJoined; }
            set { highlightEmployeeDateJoined = value; OnPropertyChanged(); OnPropertyChanged(nameof(highlightEmployeeDateJoined)); }
        }
    }
}
