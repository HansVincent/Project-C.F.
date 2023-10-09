using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class Dashboard_Home : ContentPage
{
	public Dashboard_Home()
	{
		InitializeComponent();
		BindingContext = new Dashboard_ViewModel();
        Shell.Current.Title = "Dashboard Announcements";
    }
}