using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class AddEmployee : ContentPage
{
	public AddEmployee()
	{
		InitializeComponent();
		BindingContext = new AddEmployee_ViewModel();
        Shell.Current.Title = "Add Employee";
    }
}