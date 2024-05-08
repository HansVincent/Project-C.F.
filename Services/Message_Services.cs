using Project_C.F_.Model;
using System.Collections.ObjectModel;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace Project_C.F_.Services
{
    class Message_Services
    {
        public static void SendMessage(Message message)
        {
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Message.json");
            ObservableCollection<Message> MessageCollection = Message_Services.GetMessages();
            if (message != null)
            {
                MessageCollection.Add(message);
                var MessageList = JsonSerializer.Serialize<ObservableCollection<Message>>(MessageCollection);
                File.WriteAllText(filePath, MessageList);
            }
        }

        public static ObservableCollection<Message> GetMessages()
        {
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Message.json");
            if (!File.Exists(filePath))
            {
                return [];
            }
            string FileUsers = File.ReadAllText(filePath);
            var MessageList = JsonSerializer.Deserialize<ObservableCollection<Message>>(FileUsers);
            return MessageList;
        }

        public static void UpdateMessageCollection(Message message)
        {
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Message.json");
            ObservableCollection<Message> MessageCollection = Message_Services.GetMessages();
            for (int loop = 0; loop < MessageCollection.Count; loop++)
            {
                if (message.MessageText == MessageCollection[loop].MessageText && message.Sender == MessageCollection[loop].Sender && message.Receiver == MessageCollection[loop].Receiver)
                {
                    MessageCollection[loop] = message;
                    var MessageList = JsonSerializer.Serialize<ObservableCollection<Message>>(MessageCollection);
                    File.WriteAllText(filePath, MessageList);
                    return;
                }
            }
        }

        public static ObservableCollection<Message> EmployeeMessageList(Employee employee)
        {
            ObservableCollection<Message> MessageList = [];
            foreach (var message in Message_Services.GetMessages().Reverse())
            {
                if (message.Sender.EmployeeID == employee.EmployeeID || message.Receiver.EmployeeID == employee.EmployeeID)
                {
                    MessageList.Add(message);
                }
            }
            return MessageList;
        }
    }
}
