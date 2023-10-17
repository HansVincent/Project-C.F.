using Project_C.F_.View;

namespace Project_C.F_
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(Dashboard_Home), typeof(Dashboard_Home));
            Routing.RegisterRoute(nameof(Dashboard_AddEmployee), typeof(Dashboard_AddEmployee));
            Routing.RegisterRoute(nameof(Dashboard_EmployeeDetails), typeof(Dashboard_EmployeeDetails));
        }
    }
}