using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project_C.F_.View;

namespace Project_C.F_.ViewModel
{
    public partial class LoginPage_ViewModel : MainViewModel
    {
        private void BackImage()
        {
            Shell.Current.GoToAsync("..");
        }
        public ICommand BackImageCommand => new Command(BackImage);
    }
}
