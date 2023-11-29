using Project_C.F_.Model;
using Project_C.F_.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace Project_C.F_.ViewModel
{
    [QueryProperty(nameof(HighlightedEmployeeEmployeeID), "highlightedemployeeid")]
    public partial class Dashboard_ViewEmployeePayslipsSecondPage_ViewModel : Dashboard_ViewModel
    {
        public Dashboard_ViewEmployeePayslipsSecondPage_ViewModel()
        {
            employee_Services = new Employee_Services();
            totalOvertime = TimeSpan.Zero;
            totalLate = TimeSpan.Zero;
            totalHoursWorked = TimeSpan.Zero;
            taxes = HighlightedEmployee.SalaryGrade;
        }
        private readonly Employee_Services employee_Services;
        private TimeSpan totalOvertime;
        private TimeSpan totalLate;
        private TimeSpan totalHoursWorked;
        private double overtimeBonus;
        private double lateDeductions;
        private double temporarySalary;
        private double finalSalary;
        private double totalEarnings;
        private double totalDeductions;
        private double taxes;
        private double pagibig;
        private double philHealth;
        private double sss;
        public double OvertimeBonus
        {
            get { return overtimeBonus; }
            set { overtimeBonus = value; OnPropertyChanged(); OnPropertyChanged(nameof(overtimeBonus)); }
        }
        public double LateDeductions
        {
            get { return lateDeductions; }
            set { lateDeductions = value; OnPropertyChanged(); OnPropertyChanged(nameof(lateDeductions)); }
        }
        public double TemporarySalary
        {
            get { return temporarySalary; }
            set { temporarySalary = value; OnPropertyChanged(); OnPropertyChanged(nameof(temporarySalary)); }
        }
        public double FinalSalary
        {
            get { return finalSalary; }
            set { finalSalary = value; OnPropertyChanged(); OnPropertyChanged(nameof(finalSalary)); }
        }
        public TimeSpan TotalOvertime
        {
            get { return totalOvertime; }
            set { totalOvertime = value; OnPropertyChanged(); OnPropertyChanged(nameof(totalOvertime)); }
        }

        public TimeSpan TotalLate
        {
            get { return totalLate; }
            set { totalLate = value; OnPropertyChanged(); OnPropertyChanged(nameof(totalLate)); }
        }
        public double TotalEarnings
        {
            get { return totalEarnings; }
            set { totalEarnings = value; OnPropertyChanged(); OnPropertyChanged(nameof(totalEarnings)); }
        }
        public double TotalDeductions
        {
            get { return totalDeductions; }
            set { totalDeductions = value; OnPropertyChanged(); OnPropertyChanged(nameof(totalDeductions)); }
        }
        public double Taxes
        {
            get { return taxes; }
            set { taxes = value; OnPropertyChanged(); OnPropertyChanged(nameof(taxes)); }
        }
        public double PagIbig
        {
            get { return pagibig; }
            set { pagibig = value; OnPropertyChanged(); OnPropertyChanged(nameof(pagibig)); }
        }
        public double PhilHealth
        {
            get { return philHealth; }
            set { philHealth = value; OnPropertyChanged(); OnPropertyChanged(nameof(philHealth)); }
        }
        public double SSS
        {
            get { return sss; }
            set { sss = value; OnPropertyChanged(); OnPropertyChanged(nameof(sss)); }
        }
        private string _HighlightedEmployeeEmployeeID;
        public string HighlightedEmployeeEmployeeID
        {
            get { return _HighlightedEmployeeEmployeeID; }
            set
            {
                _HighlightedEmployeeEmployeeID = value; OnPropertyChanged(); OnPropertyChanged(nameof(_HighlightedEmployeeEmployeeID)); InitializeCurrentEmployee();
            }
        }

        private Employee highlightedEmployee;
        public Employee HighlightedEmployee
        {
            get { return highlightedEmployee; }
            set { highlightedEmployee = value; OnPropertyChanged(); OnPropertyChanged(nameof(highlightedEmployee)); }
        }
        private void InitializeCurrentEmployee()
        {
            foreach (var employee in employee_Services.GetEmployees())
            {
                if (HighlightedEmployeeEmployeeID == employee.EmployeeID)
                {
                    HighlightedEmployee = employee;
                }
            }
        }
        private Employee editableEmployee;
        public Employee EditableEmployee
        {
            get { return editableEmployee; }
            set { editableEmployee = value; OnPropertyChanged(); OnPropertyChanged(nameof(editableEmployee)); }
        }

        private void SetEmployee()
        {
            EditableEmployee = new Employee
            {
                EmployeeID = HighlightedEmployee.EmployeeID,
                FullName = HighlightedEmployee.FullName,
                Email = HighlightedEmployee.Email,
                Password = HighlightedEmployee.Password,
                ContactNumber = HighlightedEmployee.ContactNumber,
                Gender = HighlightedEmployee.Gender,
                Image = HighlightedEmployee.Image,
                ActivtiyStatus = HighlightedEmployee.ActivtiyStatus,
                JobPosition = HighlightedEmployee.JobPosition,
                DateJoined = HighlightedEmployee.DateJoined,
                BirthDate = HighlightedEmployee.BirthDate,
                Country = HighlightedEmployee.Country,
                HomeAddress = HighlightedEmployee.HomeAddress,
                ProvincialAddress = HighlightedEmployee.ProvincialAddress,
                Worktimes = HighlightedEmployee.Worktimes
            };
        }
        private void Total()
        {
            foreach (Employee_Worktimes worktimes in HighlightedEmployee.Worktimes)
            {
                totalOvertime += worktimes.Overtimes.TimeOfDay;
                totalLate += worktimes.Lates.TimeOfDay;
                totalHoursWorked += worktimes.HoursWorked.TimeOfDay;
            }
        }

        private void Calculate()
        {
            totalHoursWorked -= totalOvertime;
            temporarySalary = HighlightedEmployee.SalaryGrade * totalHoursWorked.TotalHours;
            overtimeBonus = (HighlightedEmployee.SalaryGrade + 2.0) * totalOvertime.TotalHours;
            lateDeductions = (HighlightedEmployee.SalaryGrade + 5.0) * totalLate.TotalHours;
            taxes = temporarySalary * 0.0116;
            pagibig = temporarySalary * 0.03;
            philHealth = temporarySalary * 0.04;
            sss = temporarySalary * 0.045;
            totalEarnings = temporarySalary + overtimeBonus;
            totalDeductions = lateDeductions + taxes + pagibig + philHealth + sss;
        }
    }
}