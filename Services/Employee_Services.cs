using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Project_C.F_.Model;

namespace Project_C.F_.Services
{
    class Employee_Services
    {
        string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Employee.json");

        public void AddEmployee(Employee employee)
        {
            ObservableCollection<Employee> EmployeeCollection = GetEmployees();
            if (employee != null)
            {
                EmployeeCollection.Add(employee);
                var EmployeeList = JsonSerializer.Serialize<ObservableCollection<Employee>>(EmployeeCollection);
                File.WriteAllText(filePath, EmployeeList);
            }
        }

        public void UpdateEmployeeCollection(Employee employee)
        {
            ObservableCollection<Employee> EmployeeCollection = GetEmployees();
            for(int loop = 0; loop < EmployeeCollection.Count; loop++)
            {
                if (employee.EmployeeID == EmployeeCollection[loop].EmployeeID)
                {
                    EmployeeCollection[loop] = employee;
                    var EmployeeList = JsonSerializer.Serialize<ObservableCollection<Employee>>(EmployeeCollection);
                    File.WriteAllText(filePath, EmployeeList);
                    return;
                }
            }
        }

        public ObservableCollection<Employee> GetEmployees()
        {
            if (!File.Exists(filePath))
            {
                return new ObservableCollection<Employee>();
            }

            string FileUsers = File.ReadAllText(filePath);
            var EmployeeList = JsonSerializer.Deserialize<ObservableCollection<Employee>>(FileUsers);

            return EmployeeList;
        }
    }
}
