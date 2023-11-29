using Project_C.F_.View;
using Project_C.F_.ViewModel;

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
            Routing.RegisterRoute(nameof(Dashboard_UpdateEmployee), typeof(Dashboard_UpdateEmployee));
            Routing.RegisterRoute(nameof(Dashboard_ViewWorktime), typeof(Dashboard_ViewWorktime));
            Routing.RegisterRoute(nameof(Employee_Dashboard_Home), typeof(Employee_Dashboard_Home));
            Routing.RegisterRoute(nameof(Employee_Dashboard_EmployeeDetails), typeof(Employee_Dashboard_EmployeeDetails));
            Routing.RegisterRoute(nameof(Employee_Dashboard_Worktime), typeof(Employee_Dashboard_Worktime));
            Routing.RegisterRoute(nameof(Dashboard_ViewEmployeeWorktime), typeof(Dashboard_ViewEmployeeWorktime));
            Routing.RegisterRoute(nameof(Dashboard_ViewEmployeePayslips), typeof(Dashboard_ViewEmployeePayslips));
            Routing.RegisterRoute(nameof(Dashboard_ViewEmployeePayslipsSecondPage), typeof(Dashboard_ViewEmployeePayslipsSecondPage));
        }
    }
}