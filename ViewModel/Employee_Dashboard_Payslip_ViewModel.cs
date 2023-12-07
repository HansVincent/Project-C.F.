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
    [QueryProperty(nameof(HighlightedEmployee), "id")]
    public partial class Employee_Dashboard_Payslip_ViewModel : Dashboard_ViewModel
    {
        public Employee_Dashboard_Payslip_ViewModel()
        {
            employee_Services = new Employee_Services();
            totalOvertime = TimeSpan.Zero;
            totalLate = TimeSpan.Zero;
            totalHoursWorked = TimeSpan.Zero;
            SetEmployee();
        }
        private readonly Employee_Services employee_Services;
        private TimeSpan totalOvertime;
        private TimeSpan totalLate;
        private TimeSpan totalHoursWorked;
        private String displayTotalOvertime;
        private String displayTotalLate;
        private String displayTotalHoursWorked;
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
        public string DisplayTotalOvertime
        {
            get { return displayTotalOvertime; }
            set { displayTotalOvertime = value; OnPropertyChanged(); OnPropertyChanged(nameof(displayTotalOvertime)); }
        }
        public string DisplayTotalLate
        {
            get { return displayTotalLate; }
            set { displayTotalLate = value; OnPropertyChanged(); OnPropertyChanged(nameof(displayTotalLate)); }
        }
        public string DisplayTotalHoursWorked
        {
            get { return displayTotalHoursWorked; }
            set { displayTotalHoursWorked = value; OnPropertyChanged(); OnPropertyChanged(nameof(displayTotalHoursWorked)); }
        }
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
        public TimeSpan TotalHoursWorked
        {
            get { return totalHoursWorked; }
            set { totalHoursWorked = value; OnPropertyChanged(); OnPropertyChanged(nameof(totalHoursWorked)); }
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

        private Employee highlightedEmployee;
        public Employee HighlightedEmployee
        {
            get { return highlightedEmployee; }
            set { highlightedEmployee = value; OnPropertyChanged(); OnPropertyChanged(nameof(highlightedEmployee)); Total(); Calculate(); SetDisplayValues(); }
        }

        private void SetEmployee()
        {
            string employeeID = CurrentEmployee.EmployeeID;
            foreach (var employee in employee_Services.GetEmployees())
            {
                if (employeeID == employee.EmployeeID)
                {
                    HighlightedEmployee = new Employee
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
        private void Total()
        {
            foreach (Employee_Worktimes worktimes in HighlightedEmployee.Worktimes)
            {
                TotalOvertime += worktimes.Overtimes.TimeOfDay;
                TotalLate += worktimes.Lates.TimeOfDay;
                TotalHoursWorked += worktimes.HoursWorked.TimeOfDay;
            }
        }

        private void Calculate()
        {
            TotalHoursWorked -= totalOvertime;
            TemporarySalary = HighlightedEmployee.SalaryGrade * totalHoursWorked.TotalHours;
            OvertimeBonus = (HighlightedEmployee.SalaryGrade + 2.0) * totalOvertime.TotalHours;
            LateDeductions = (HighlightedEmployee.SalaryGrade + 5.0) * totalLate.TotalHours;
            Taxes = temporarySalary * 0.0116;
            PagIbig = temporarySalary * 0.03;
            PhilHealth = temporarySalary * 0.04;
            SSS = temporarySalary * 0.045;
            TotalEarnings = temporarySalary + overtimeBonus;
            TotalDeductions = lateDeductions + taxes + pagibig + philHealth + sss;
            FinalSalary = TotalEarnings - TotalDeductions;
        }

        private void SetDisplayValues()
        {
            DisplayTotalOvertime = TotalOvertime.TotalHours.ToString();
            DisplayTotalLate = TotalLate.TotalHours.ToString();
            DisplayTotalHoursWorked = TotalHoursWorked.TotalHours.ToString();
        }
    }
}