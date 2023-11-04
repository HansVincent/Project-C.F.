using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class Employee_Dashboard_Home : ContentPage
{
	public Employee_Dashboard_Home()
	{
		InitializeComponent();
		BindingContext = new Employee_Dashboard_Home_ViewModel();
        Shell.Current.Title = "Dashboard Announcements";
    }
}