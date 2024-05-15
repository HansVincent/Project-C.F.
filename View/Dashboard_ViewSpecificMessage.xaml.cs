using Project_C.F_.ViewModel;
using Project_C.F_.Model;

namespace Project_C.F_.View;

public partial class Dashboard_ViewSpecificMessage : ContentPage
{
    public Dashboard_ViewSpecificMessage(Message value)
    {
        InitializeComponent();
        this.BindingContext = new Dashboard_ViewSpecificMessage_ViewModel(value);

    }
    public Dashboard_ViewSpecificMessage(Dashboard_ViewSpecificMessage_ViewModel vm)
    {

        InitializeComponent();
        BindingContext = vm;
    }
}