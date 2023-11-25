using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class Dashboard_ViewEmployeeWorktime : ContentPage
{
	public Dashboard_ViewEmployeeWorktime()
	{
		InitializeComponent();
		BindingContext = new Dashboard_ViewEmployeeWorktime_ViewModel();
		Shell.Current.Title = "Employee Worktime";
	}
}