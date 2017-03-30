//-----------------------------------------------------------------------
// <copyright file="MessagePanelView.cs" company="Development In Progress Ltd">
//     Copyright © Development In Progress Ltd 2017. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows.Controls;
using System.Windows.Input;

namespace DevelopmentInProgress.WPFControls.Messaging
{
    /// <summary>
    /// Partial class providing code-behind supporting for events raised in MessagePanelView.xaml.
    /// </summary>
    public partial class MessagePanelView
    {
        private void MessageMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            var contentControl = sender as ContentControl;
            if (contentControl == null)
            {
                return;
            }

            var mesage = contentControl.DataContext as Message;
            if (mesage == null)
            {
                return;
            }

            var messageBoxSettings = new MessageBoxSettings
            {
                Text = mesage.Text,
                Title = mesage.Title,
                MessageType = mesage.MessageType,
                MessageBoxButtons = MessageBoxButtons.Ok,
                CopyToClipboardEnabled = true
            };

            Messaging.ShowMessage(messageBoxSettings);
        }
    }
}
