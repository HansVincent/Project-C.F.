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
    public partial class Employee_Dashboard_Payslip_ViewModel : Dashboard_ViewModel
    {
        public Employee_Dashboard_Payslip_ViewModel()
        {
            employee_Services = new Employee_Services();
            totalOvertime = TimeSpan.Zero;
            totalLate = TimeSpan.Zero;
            totalHoursWorked = TimeSpan.Zero;
            MonthPicker =
            [
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            ];
        }
        private readonly Employee_Services employee_Services;
        private TimeSpan totalOvertime;
        private TimeSpan totalLate;
        private TimeSpan totalHoursWorked;
        private TimeSpan totalUndertime;
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
        private double underTimes;
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

        private DateTime chosenMonth;
        public DateTime ChosenMonth
        {
            get
            {
                return chosenMonth;
            }
            set
            {
                chosenMonth = value; OnPropertyChanged(); OnPropertyChanged(nameof(chosenMonth)); Total(); Calculate(); SetDisplayValues();
            }
        }

        private ObservableCollection<string> monthPicker;
        public ObservableCollection<string> MonthPicker
        {
            get { return monthPicker; }
            set { monthPicker = value; OnPropertyChanged(); OnPropertyChanged(nameof(monthPicker)); }
        }
        
        public TimeSpan TotalUndertime
        {
            get { return totalUndertime; }
            set { totalUndertime = value; OnPropertyChanged(); OnPropertyChanged(nameof(totalUndertime)); }
        }

        public double UnderTimes
        { get { return underTimes; } set {  underTimes = value; OnPropertyChanged(); OnPropertyChanged(nameof(underTimes)); } }
        private void Total()
        {
            foreach (Employee_Worktimes worktimes in CurrentEmployee.Worktimes)
            {
                if (worktimes.Month.Month == ChosenMonth.Month && worktimes.Year.Year == ChosenMonth.Year)
                {
                    TotalOvertime += worktimes.Overtimes.TimeOfDay;
                    TotalLate += worktimes.Lates.TimeOfDay;
                    TotalHoursWorked += worktimes.HoursWorked.TimeOfDay;
                    TotalUndertime += worktimes.Undertimes.TimeOfDay;
                }
            }
        }
        private void Calculate()
        {
            TotalHoursWorked -= TotalOvertime;
            TemporarySalary = CurrentEmployee.SalaryGrade * TotalHoursWorked.TotalHours;
            OvertimeBonus = (CurrentEmployee.SalaryGrade + 2.0) * TotalOvertime.TotalHours;
            LateDeductions = (CurrentEmployee.SalaryGrade + 5.0) * TotalLate.TotalHours;
            UnderTimes = (CurrentEmployee.SalaryGrade + 5.0) * TotalUndertime.TotalHours;
            Taxes = TemporarySalary * 0.0116;
            PagIbig = TemporarySalary * 0.03;
            PhilHealth = TemporarySalary * 0.04;
            SSS = TemporarySalary * 0.045;
            TotalEarnings = ((TemporarySalary + OvertimeBonus) - UnderTimes) - LateDeductions;
            TotalDeductions = Taxes + PagIbig + PhilHealth + SSS;
            FinalSalary = TotalEarnings - TotalDeductions;
        }
        private void SetDisplayValues()
        {
            DisplayTotalOvertime = TotalOvertime.TotalHours.ToString();
            DisplayTotalLate = TotalLate.TotalHours.ToString();
            DisplayTotalHoursWorked = TotalHoursWorked.TotalHours.ToString();
        }
        private void ResetValues()
        {
            TemporarySalary = 0;
            OvertimeBonus = 0;
            LateDeductions = 0;
            UnderTimes = 0;
            TotalOvertime = TimeSpan.Zero;
            TotalLate = TimeSpan.Zero;
            TotalUndertime = TimeSpan.Zero;
            Taxes = 0;
            PagIbig = 0;
            PhilHealth = 0;
            SSS = 0;
            TotalHoursWorked = TimeSpan.Zero;
            TotalEarnings = 0;
            TotalDeductions = 0;
            FinalSalary = 0;
        }
        private int selectedMonth = DateTime.Now.Month - 1;
        public int SelectedMonth
        {
            get { return selectedMonth; }
            set { selectedMonth = value; OnPropertyChanged(); OnPropertyChanged(nameof(selectedMonth)); PickerMonth_SelectedIndexChanged(); }
        }
        private void PickerMonth_SelectedIndexChanged()
        {
            ChosenMonth = new DateTime(DateTime.Now.Year, SelectedMonth + 1, DateTime.DaysInMonth(DateTime.Now.Year, selectedMonth + 1));
            ResetValues();
            Total();
            Calculate();
            SetDisplayValues();
        }
        public void OnAppearing() => CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
    }
}