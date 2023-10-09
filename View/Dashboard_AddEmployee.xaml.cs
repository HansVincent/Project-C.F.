using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class Dashboard_AddEmployee : ContentPage
{
	public Dashboard_AddEmployee()
	{
		InitializeComponent();
		BindingContext = new Dashboard_AddEmployee_ViewModel();
		Shell.Current.Title = "Add Employee";
	}
}