using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project_C.F_.Model;
using Project_C.F_.Services;
using Project_C.F_.View;
using System.Collections.ObjectModel;

namespace Project_C.F_.ViewModel
{
    public partial class Dashboard_ViewMessages_ViewModel : ObservableObject
    {
        public Dashboard_ViewMessages_ViewModel()
        {
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
            MessageList = Message_Services.EmployeeMessageList(CurrentEmployee);
        }
        [ObservableProperty]
        private Employee currentEmployee;
        [ObservableProperty]
        private ObservableCollection<Message> messageList;
        [ObservableProperty]
        private Message selectedMessage;
        partial void OnSelectedMessageChanged(Message value)
        {
            if (value.Receiver.EmployeeID == CurrentEmployee.EmployeeID)
            {
                value.Tag = 1; //Changes tag to READ
                Message_Services.UpdateMessageCollection(value);
            }
            Shell.Current.Navigation.PushAsync(new Dashboard_ViewSpecificMessage(value));
        }

        [RelayCommand]
        private async static Task GoToWriteMessage() => await Shell.Current.Navigation.PushAsync(new Dashboard_WriteMessage());
    }
}
