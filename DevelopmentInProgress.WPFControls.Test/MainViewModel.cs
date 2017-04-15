using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevelopmentInProgress.WPFControls.Messaging;
using DevelopmentInProgress.WPFControls.Test.Models;

namespace DevelopmentInProgress.WPFControls.Test
{
    public class MainViewModel : NotifyChange
    {

        public MainViewModel()
        {
            LoadMessages();
            LoadUsers();
            ShowMessageBoxes();
        }

        public ObservableCollection<Message> Messages { get; set; }

        public ObservableCollection<User> Users { get; set; }

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

        public void LoadUsers()
        {
            var read = new Activity {Text = "Read", Image = @"..\Images\Activities.png"};
            var write = new Activity { Text = "Write", Image = @"..\Images\Activity_Write.png" };
            var accept = new Activity { Text = "Accept", Image = @"..\Images\Activity_Accept.png" };
            var reject = new Activity { Text = "Reject", Image = @"..\Images\Activity_Reject.png" };
            var email = new Activity { Text = "Email", Image = @"..\Images\Activity_email.png" };

            var writer = new Role {Text = "Writer", Image = @"..\Images\Role_Writer.png"};
            var reviewer = new Role { Text = "Reviewer", Image = @"..\Images\Role_Reviewer.png" };
            var administrator = new Role { Text = "Administrator", Image = @"..\Images\Role_Administrator.png" };

            var joe = new User {Text = "Joe Bloggs", Image = @"..\Images\user.png"};
            var jane = new User {Text = "Jane Masters", Image = @"..\Images\user.png"};
            var john = new User {Text = "Jack Smith", Image = @"..\Images\user.png"};

            writer.Activities.Add(read);
            writer.Activities.Add(write);
            
            reviewer.Activities.Add(read);
            reviewer.Activities.Add(accept);
            reviewer.Activities.Add(reject);

            administrator.Activities.Add(read);
            administrator.Activities.Add(write);
            administrator.Activities.Add(accept);
            administrator.Activities.Add(reject);
            administrator.Activities.Add(email);

            joe.Roles.Add(writer);
            jane.Roles.Add(reviewer);
            john.Roles.Add(administrator);

            Users = new ObservableCollection<User>(new[] {joe, jane, john});
        }

        private void ShowMessageBoxes()
        {
            var info = new MessageBoxSettings
            {
                Title = "Grant User Role",
                Text = "User 'Joe Bloggs' has been granted the role 'Writer'. Do you wish to continue?",
                MessageType = MessageType.Info,
                MessageBoxButtons = MessageBoxButtons.OkCancel
            };

            var infoResult = Dialog.ShowMessage(info);

            var warn = new MessageBoxSettings
            {
                Title = "Create Role",
                Text = "A role with the name 'Writer' already exists.\nDo you want to replace it?",
                MessageType = MessageType.Warn,
                MessageBoxButtons = MessageBoxButtons.YesNoCancel
            };

            var warnResult = Dialog.ShowMessage(warn);

            var question = new MessageBoxSettings
            {
                Title = "Remove User From Role",
                Text = "Do you want to remove user 'Jane Master' from the 'Reviewer' role?",
                MessageType = MessageType.Question,
                MessageBoxButtons = MessageBoxButtons.YesNo
            };

            var questionResult = Dialog.ShowMessage(question);

            var error = new MessageBoxSettings
            {
                Title = "Create Role",
                Text = "The role name is mandatory when creating or saving a role.",
                MessageType = MessageType.Error,
                MessageBoxButtons = MessageBoxButtons.Ok
            };

            Dialog.ShowMessage(error);

            try
            {
                int zero = 0;
                var result = 1/zero;
            }
            catch (Exception ex)
            {
                Dialog.ShowException(ex);
            }
        }
    }
}
