using CommunityToolkit.Mvvm.ComponentModel;
using Project_C.F_.Model;

namespace Project_C.F_.ViewModel
{
    [QueryProperty(nameof(SelectedMessage), "selectedmessage")]
    public partial class Dashboard_ViewSpecificMessage_ViewModel : ObservableObject
    {
        [ObservableProperty]
        private Message selectedMessage;
    }
}
