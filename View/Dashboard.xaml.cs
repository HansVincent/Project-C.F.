using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class Dashboard : TabbedPage
{
	public Dashboard()
	{
		InitializeComponent();
        BindingContext = new Dashboard_ViewModel();
	}
}