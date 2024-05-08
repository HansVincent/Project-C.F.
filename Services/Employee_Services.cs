using Project_C.F_.Model;
using System.Collections.ObjectModel;
using System.Text.Json;


namespace Project_C.F_.Services
{
    class Employee_Services
    {
        public static ObservableCollection<Employee> GetEmployees()
        {
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Employee.json");
            if (!File.Exists(filePath))
            {
                return [];
            }
            string FileUsers = File.ReadAllText(filePath);
            var EmployeeList = JsonSerializer.Deserialize<ObservableCollection<Employee>>(FileUsers);
            return EmployeeList;
        }

        public static void UpdateEmployeeCollection(Employee employee)
        {
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Employee.json");
            ObservableCollection<Employee> EmployeeCollection = Employee_Services.GetEmployees();
            for (int loop = 0; loop < EmployeeCollection.Count; loop++)
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
        public static ObservableCollection<Employee> GetHumanResources()
        {
            ObservableCollection<Employee> EmployeeCollection = [];
            foreach (var employee in Employee_Services.GetEmployees())
            {
                if (employee.JobPosition == "Human Resource")
                {
                    EmployeeCollection.Add(employee);
                }
            }
            return EmployeeCollection;
        }
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
        public static Employee InitializeCurrentEmployee()
        {
            string employeeID = Preferences.Get("employeeID", "Unknown");
            foreach (var employee in Employee_Services.GetEmployees())
            {
                if (employeeID == employee.EmployeeID)
                {
                    return employee;
                }
            }
            return new();
        }
    }
}
