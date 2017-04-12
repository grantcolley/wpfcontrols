using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevelopmentInProgress.WPFControls.Messaging;

namespace DevelopmentInProgress.WPFControls.Test
{
    public class MainViewModel
    {

        public MainViewModel()
        {
            LoadMessages();
        }

        public ObservableCollection<Message> Messages { get; set; }

        private void LoadMessages()
        {
            var messageError = new Message()
            {
                MessageType = MessageType.Error,
                Text = "The role name is mandatory when creating or saving a role."
            };

            var messageWarn = new Message()
            {
                MessageType = MessageType.Warn,
                Text = "Cannot create a new role with the name 'Writer' as one already exists."
            };

            var messageInfo = new Message()
            {
                MessageType = MessageType.Info,
                Text = "User 'Joe Bloggs' has been granted the role 'Writer'."
            };

            Messages = new ObservableCollection<Message>(new List<Message> { messageError, messageWarn, messageInfo });
        }
    }
}
