using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class Dashboard_ViewMessages : ContentPage
{
    public Dashboard_ViewMessages(Dashboard_ViewMessages_ViewModel vm)
    {
            InitializeComponent();
            BindingContext = vm;
    }
}