using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class Dashboard_ViewWorktime : ContentPage
{
	public Dashboard_ViewWorktime()
	{
		InitializeComponent();
		BindingContext = new Dashboard_ViewWorktime_ViewModel();
		Shell.Current.Title = "View Worktime";
	}
}