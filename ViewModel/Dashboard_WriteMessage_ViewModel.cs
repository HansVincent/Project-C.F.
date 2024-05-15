using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project_C.F_.Services;
using Project_C.F_.Model;
using System.Collections.ObjectModel;

namespace Project_C.F_.ViewModel
{
    public partial class Dashboard_WriteMessage_ViewModel : ObservableObject
    {
        public Dashboard_WriteMessage_ViewModel()
        {
            NewMessage = new Message();
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
            ContactList = Employee_Services.GetHumanResources();
        }
        [ObservableProperty]
        private ObservableCollection<Employee> contactList;
        [ObservableProperty]
        private Message newMessage;
        [ObservableProperty]
        private Employee currentEmployee;
        private void InitializeMessage()
        {
            NewMessage.Sender = new Employee
            {
                EmployeeID = CurrentEmployee.EmployeeID,
                FullName = CurrentEmployee.FullName,
                Email = CurrentEmployee.Email,
                Password = CurrentEmployee.Password,
                ContactNumber = CurrentEmployee.ContactNumber,
                Gender = CurrentEmployee.Gender,
                Image = CurrentEmployee.Image,
                HoursWorked = CurrentEmployee.HoursWorked,
                ActivtiyStatus = CurrentEmployee.ActivtiyStatus,
                JobPosition = CurrentEmployee.JobPosition,
                DateJoined = CurrentEmployee.DateJoined,
                BirthDate = CurrentEmployee.BirthDate,
                Country = CurrentEmployee.Country,
                HomeAddress = CurrentEmployee.HomeAddress,
                ProvincialAddress = CurrentEmployee.ProvincialAddress
            };
            NewMessage.Tag = 0;
            NewMessage.TimeSent = DateTime.Now;
        }

        private bool ValidateEntries()
        {
            if (string.IsNullOrEmpty(NewMessage.Subject) || string.IsNullOrEmpty(NewMessage.MessageText) || NewMessage.Receiver == null)
            {
                return false;
            }
            return true;
        }
        [RelayCommand]
        private void SendMessage()
        {
            if (ValidateEntries())
            {
                InitializeMessage();
                Message_Services.SendMessage(NewMessage);
                Shell.Current.DisplayAlert("Email sent", "The email has been successfully sent to receiver", "Okay");
                Shell.Current.GoToAsync("..");
            }
            else
            {
                Shell.Current.DisplayAlert("Entries not filled", "Fill in all entries to send message", "Okay");
            }
        }
    }
}
