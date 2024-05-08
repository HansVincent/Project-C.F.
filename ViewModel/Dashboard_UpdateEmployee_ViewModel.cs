using System;
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
            SetUpdates();
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
            EmployeeList = Employee_Services.GetEmployees();
            EnableEdit = false;
        }
        private Employee highlightedEmployeee;
        public Employee HighlightedEmployeee
        {
            get { return highlightedEmployeee; }
            set { highlightedEmployeee = value; OnPropertyChanged(); OnPropertyChanged(nameof(highlightedEmployeee)); SetEmployee();  }
        }

        private Employee editableEmployee;
        public Employee EditableEmployee
        {
            get { return editableEmployee; }
            set { editableEmployee = value; OnPropertyChanged(); OnPropertyChanged(nameof(editableEmployee)); }
        }
        private bool enableEdit;
        public bool EnableEdit
        {
            get { return enableEdit; }
            set { enableEdit = value; OnPropertyChanged(); OnPropertyChanged(nameof(enableEdit)); }
        }
        private void SetEmployee()
        {
            EditableEmployee = new Employee
            {
                EmployeeID = HighlightedEmployeee.EmployeeID,
                FullName = HighlightedEmployeee.FullName,
                Email = HighlightedEmployeee.Email,
                Password = HighlightedEmployeee.Password,
                ContactNumber = HighlightedEmployeee.ContactNumber,
                Gender = HighlightedEmployeee.Gender,
                Image = HighlightedEmployeee.Image,
                ActivtiyStatus = HighlightedEmployeee.ActivtiyStatus,
                JobPosition = HighlightedEmployeee.JobPosition,
                DateJoined = HighlightedEmployeee.DateJoined,
                BirthDate = HighlightedEmployeee.BirthDate,
                Country = HighlightedEmployeee.Country,
                HomeAddress = HighlightedEmployeee.HomeAddress,
                ProvincialAddress = HighlightedEmployeee.ProvincialAddress,
                Worktimes = HighlightedEmployeee.Worktimes
            };
            EnableEdit = true;
            SetUpdates();
        }
        public List<string> Genders { get; } = new()
        {
            "Male",
            "Female"
        };
        private bool showPassword;
        public bool ShowPassword
        {
            get { return showPassword; }
            set { showPassword = value; OnPropertyChanged(); OnPropertyChanged(nameof(showPassword)); }
        }

        private string passwordIcon;
        public string PasswordIcon
        {
            get { return passwordIcon; }
            set {  passwordIcon = value; OnPropertyChanged(); OnPropertyChanged(nameof(passwordIcon)); }
        }

        private void SetPassword()
        {
            if(ShowPassword == true)
            {
                PasswordIcon = "updateemployee_visibilityon.png";
                ShowPassword = false;
            }
            else if (ShowPassword == false)
            {
                PasswordIcon = "updateemployee_visibilityoff.png";
                ShowPassword = true;
            }
        }
        public ICommand SetPasswordCommand => new Command(SetPassword);
        private string writeIcon;
        public string WriteIcon
        {
            get { return writeIcon; }
            set { writeIcon = value; OnPropertyChanged(); OnPropertyChanged(nameof(writeIcon)); }
        }

        private bool enableUpdate;
        public bool EnableUpdate
        {
            get { return enableUpdate; }
            set { enableUpdate = value; OnPropertyChanged(); OnPropertyChanged(nameof(enableUpdate)); }
        }
        private bool genderEditEnable;
        public bool GenderEditEnable
        {
            get { return genderEditEnable; }
            set { genderEditEnable = value; OnPropertyChanged(); OnPropertyChanged(nameof(genderEditEnable)); }
        }
        private void SetUpdates()
        {
            ShowPassword = true;
            PasswordIcon = "updateemployee_visibilityoff.png";

            EnableUpdate = true;
            WriteIcon = "updateemployee_editon.png";
            GenderEditEnable = false;
        }
        private void SetEnable()
        {
            if (EnableUpdate == true)
            {   WriteIcon = "updateemployee_editoff.png";
                EnableUpdate = false;
                GenderEditEnable = true;
            }
            else if (EnableUpdate == false)
            {
                SetEmployee();
                WriteIcon = "updateemployee_editon.png";
                EnableUpdate = true;
                genderEditEnable = false;
            }
        }
        public ICommand SetEnableCommand => new Command(SetEnable);
        private void UpdateEmployee()
        {
            if(editableEmployee.JobPosition == "Human Resource")
            {
                editableEmployee.SalaryGrade = 10.00;
            }
            else if(editableEmployee.JobPosition == "Employee")
            {
                editableEmployee.SalaryGrade = 5.00;    
            }
            Employee_Services.UpdateEmployeeCollection(editableEmployee);
            Shell.Current.DisplayAlert("Update Employee", "Employee Update Successful", "Okay");
            HighlightedEmployeee = new Employee();
            SetEmployee();
            GetEmployee();
        }
        public ICommand UpdateEmployeeCommand => new Command(UpdateEmployee);
    }
}
