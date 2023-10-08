using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_C.F_.ViewModel
{
    public partial class AddEmployee_ViewModel : MainViewModel
    {
        public List<string> JobPositions { get; } = new()
        {
            "Employee",
            "Human Resource"
        };
        public List<string> Genders { get; } = new()
        {
            "Male",
            "Female"
        };
    }
}
