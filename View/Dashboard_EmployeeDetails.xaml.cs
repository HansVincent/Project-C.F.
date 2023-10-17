using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class Dashboard_EmployeeDetails : ContentPage
{
	public Dashboard_EmployeeDetails()
	{
		InitializeComponent();
		BindingContext = new Dashboard_EmployeeDetails_ViewModel();
		Shell.Current.Title = "Employee Details";
	}
}