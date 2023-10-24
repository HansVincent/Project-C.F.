using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class Dashboard_UpdateEmployee : ContentPage
{
	public Dashboard_UpdateEmployee()
	{
		InitializeComponent();
		BindingContext = new Dashboard_UpdateEmployee_ViewModel();	
		Shell.Current.Title = "Update Employee";
	}
}