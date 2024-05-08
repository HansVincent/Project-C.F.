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
        [ObservableProperty]
        private Employee currentEmployee;
        [ObservableProperty]
        private ObservableCollection<Message> messageList;
        [ObservableProperty]
        private Message selectedMessage;
        partial void OnSelectedMessageChanged(Message value)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "selectedmessage", value }
            };
            if (value.Receiver.EmployeeID == CurrentEmployee.EmployeeID)
            {
                value.Tag = 1; //Changes tag to READ
                Message_Services.UpdateMessageCollection(value);
            }
            Shell.Current.GoToAsync($"{nameof(Dashboard_ViewSpecificMessage_ViewModel)}", navigationParameter);
        }

        [RelayCommand]
        private void GoToWriteMessage() => Shell.Current.GoToAsync(nameof(Dashboard_WriteMessage), false);
        public void OnAppearing()
        {
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
            MessageList = Message_Services.EmployeeMessageList(CurrentEmployee);
        }
        public void OnDisappearing()
        {
            SelectedMessage = null;
        }
    }
}
