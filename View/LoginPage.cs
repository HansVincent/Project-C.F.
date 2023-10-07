namespace Project_C.F
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Tapped(object sender, TappedEventArgs e)
        {
            txtForgotPassword.Text = "You stupid";
        }

        private async void onNavigateToHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        //    private void OnSignInClicked(object sender, EventArgs e)
        //    {
        //
        //    }
    }
}
