using Project_C.F_.ViewModel;

namespace Project_C.F_
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPage_ViewModel();
            Shell.Current.Title = "Main Page";
        }
    }
}