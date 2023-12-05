using Project_C.F_.ViewModel;
namespace Project_C.F_.View;

public partial class Employee_Dashboard_PayslipFirstPage : ContentPage
{
    public Employee_Dashboard_PayslipFirstPage()
    {
        InitializeComponent();
        BindingContext = new Employee_Dashboard_PayslipFirstPage_ViewModel();
        Shell.Current.Title = "Employee Payslips";
    }
}