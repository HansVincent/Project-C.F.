using Project_C.F_.Model;
using Project_C.F_.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_C.F_.ViewModel
{
    public partial class Dashboard_EmployeeDetails_ViewModel : Dashboard_ViewModel
    {
        public Dashboard_EmployeeDetails_ViewModel() 
        {
            employee_Services = new Employee_Services();
            GetEmployee();
        }
        private readonly Employee_Services employee_Services;

        private ObservableCollection<Employee> employeeList;
        public ObservableCollection<Employee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; OnPropertyChanged(); OnPropertyChanged(nameof(employeeList)); }
        }
        private void GetEmployee()
        {
            foreach(var person in employee_Services.GetEmployees()) 
            {
                if(person.JobPosition == "Employee")
                {
                    employeeList.Add(person);
                }
            }
        }
    }
}
