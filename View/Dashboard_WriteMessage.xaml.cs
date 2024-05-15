using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class Dashboard_WriteMessage : ContentPage
{
	public Dashboard_WriteMessage()
	{
        InitializeComponent();
        BindingContext = new Dashboard_WriteMessage_ViewModel();
    }
    public Dashboard_WriteMessage(Dashboard_WriteMessage_ViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}