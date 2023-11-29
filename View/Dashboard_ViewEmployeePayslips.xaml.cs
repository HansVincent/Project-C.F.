using Project_C.F_.ViewModel;
namespace Project_C.F_.View;

public partial class Dashboard_ViewEmployeePayslips : ContentPage
{
    public Dashboard_ViewEmployeePayslips()
    {
        InitializeComponent();
        BindingContext = new Dashboard_ViewEmployeePayslips_ViewModel();
        Shell.Current.Title = "Employee Payslips";
    }
}