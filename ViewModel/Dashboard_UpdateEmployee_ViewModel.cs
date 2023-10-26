﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project_C.F_.Model;
using Project_C.F_.Services;

namespace Project_C.F_.ViewModel
{
    public partial class Dashboard_UpdateEmployee_ViewModel : Dashboard_ViewModel
    {
        public Dashboard_UpdateEmployee_ViewModel()
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
        private void GetEmployee()
        {
            foreach (var person in employee_Services.GetEmployees())
            {
                if (person.JobPosition == "Employee")
                {
                    EmployeeList.Add(person);
                }
            }
        }
        private Employee highlightedEmployeee;
        public Employee HighlightedEmployeee
        {
            get { return highlightedEmployeee; }
            set { highlightedEmployeee = value; OnPropertyChanged(); OnPropertyChanged(nameof(highlightedEmployeee)); SetDateDetails(); }
        }

        private void SetDateDetails()
        {
            HighlightEmployeeBirthday = HighlightedEmployeee.BirthDate.ToString("MM/dd/yyyy");
            HighlightEmployeeDateJoined = HighlightedEmployeee.DateJoined.ToString("MM/dd/yyyy");
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


        private void UpdateEmployee()
        {
            
        }
        public ICommand UpdateEmployeeCommand => new Command(UpdateEmployee);
    }
}