using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project_C.F_.Model;
using Project_C.F_.Services;

namespace Project_C.F_.ViewModel
{
    public partial class Dashboard_ViewSpecificMessage_ViewModel : ObservableObject
    {
        public Dashboard_ViewSpecificMessage_ViewModel(Message value)
        {
            SelectedMessage = value;
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
        }
        [ObservableProperty]
        private Employee currentEmployee;
        [ObservableProperty]
        private Message selectedMessage;

        [RelayCommand]
        private async Task UpdateTag()
        {
            if (CurrentEmployee.JobPosition.Equals("Human Resource"))
            {
                string action = await Shell.Current.DisplayActionSheet("Change Status?", "Cancel", null, "Unread", "Read", "Pending", "Approved", "Denied");
                if (action == "Unread")
                    SelectedMessage.Tag = 0; //Changes tag to READ
                Message_Services.UpdateMessageCollection(SelectedMessage);
                if (action == "Pending")
                    SelectedMessage.Tag = 2; //Changes tag to READ
                Message_Services.UpdateMessageCollection(SelectedMessage);
                if (action == "Approved")
                    SelectedMessage.Tag = 3; //Changes tag to READ
                Message_Services.UpdateMessageCollection(SelectedMessage);
                if (action == "Denied")
                    SelectedMessage.Tag = 4; //Changes tag to READ
                Message_Services.UpdateMessageCollection(SelectedMessage);
            }
        }
    }
}
