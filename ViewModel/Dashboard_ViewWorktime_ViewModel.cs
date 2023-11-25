using Project_C.F_.Model;
using Project_C.F_.Services;
using Project_C.F_.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project_C.F_.ViewModel
{
    public partial class Dashboard_ViewWorktime_ViewModel  : Dashboard_ViewModel
    {
        public Dashboard_ViewWorktime_ViewModel() 
        {
            employee_Services = new Employee_Services();
            EmployeeList = new ObservableCollection<Employee>();
            GetEmployee();
        }
        private readonly Employee_Services employee_Services;
        private ObservableCollection<Employee> employeeList;
        public ObservableCollection<Employee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; OnPropertyChanged(); OnPropertyChanged(nameof(employeeList)); }
        }
        private Employee highlightedEmployee;
        public Employee HighlightedEmployee
        {
            get { return highlightedEmployee; }
            set { highlightedEmployee = value; OnPropertyChanged(); OnPropertyChanged(nameof(highlightedEmployee)); }
        }
        private void GetEmployee()
        {
            EmployeeList = employee_Services.GetEmployees();
        }

        private void ViewEmployeeWorktime()
        {
            string HighlightedEmployeeEmployeeID = HighlightedEmployee.EmployeeID;
            Shell.Current.GoToAsync($"{nameof(Dashboard_ViewEmployeeWorktime)}?id={EmployeeID}&highlightedemployeeid={HighlightedEmployeeEmployeeID}");
        }
        public ICommand ViewEmployeeWorktimeCommand => new Command(ViewEmployeeWorktime);
    }
}
