using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class Employee_Dashboard_EmployeeDetails : ContentPage
{
	public Employee_Dashboard_EmployeeDetails()
	{
		InitializeComponent();
		BindingContext = new Employee_Dashboard_EmployeeDetails_ViewModel();
		Shell.Current.Title = "Employee Details";
	}
}