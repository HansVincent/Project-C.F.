using Project_C.F_.ViewModel;

namespace Project_C.F_.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginPage_ViewModel();
        Shell.Current.Title = "Login Page";
    }
}