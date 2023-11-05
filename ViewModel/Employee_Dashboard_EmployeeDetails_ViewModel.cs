using Project_C.F_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_C.F_.ViewModel
{
    public partial class Employee_Dashboard_EmployeeDetails_ViewModel : Dashboard_ViewModel
    {
        private Employee highlightedEmployeee;
        public Employee HighlightedEmployeee
        {
            get { return highlightedEmployeee; }
            set { highlightedEmployeee = value; OnPropertyChanged(); OnPropertyChanged(nameof(highlightedEmployeee)); SetDateDetails(); }
        }
        private void SetDateDetails()
        {
            HighlightEmployeeBirthday = CurrentEmployee.BirthDate.ToString("MM/dd/yyyy");
            HighlightEmployeeDateJoined = CurrentEmployee.DateJoined.ToString("MM/dd/yyyy");
        }

        private string highlightEmployeeBirthday;
        public string HighlightEmployeeBirthday
        {
            get { return highlightEmployeeBirthday; }
            set { highlightEmployeeBirthday = value; OnPropertyChanged(); OnPropertyChanged(nameof(highlightEmployeeBirthday)); }
        }
        private string highlightEmployeeDateJoined;
        public string HighlightEmployeeDateJoined
        {
            get { return highlightEmployeeDateJoined; }
            set { highlightEmployeeDateJoined = value; OnPropertyChanged(); OnPropertyChanged(nameof(highlightEmployeeDateJoined)); }
        }
    }
}
