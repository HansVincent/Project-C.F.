using Project_C.F_.ViewModel;
namespace Project_C.F_.View;

public partial class Employee_Dashboard_Payslip : ContentPage
{
    public Employee_Dashboard_Payslip()
    {
        InitializeComponent();
        BindingContext = new Employee_Dashboard_Payslip_ViewModel();
        Shell.Current.Title = "Employee Payslips";
    }
}