using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class Employee_Dashboard_Worktime : ContentPage
{
	public Employee_Dashboard_Worktime()
	{
		InitializeComponent();
		BindingContext = new Employee_Dashboard_Worktime_ViewModel();
		Shell.Current.Title = "Employee Worktime";
	}
}