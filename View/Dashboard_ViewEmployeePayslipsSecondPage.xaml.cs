using Project_C.F_.ViewModel;
namespace Project_C.F_.View;

public partial class Dashboard_ViewEmployeePayslipsSecondPage : ContentPage
{
    public Dashboard_ViewEmployeePayslipsSecondPage()
    {
        InitializeComponent();
        BindingContext = new Dashboard_ViewEmployeePayslipsSecondPage_ViewModel();
        Shell.Current.Title = "Employee Payslips";
    }
}