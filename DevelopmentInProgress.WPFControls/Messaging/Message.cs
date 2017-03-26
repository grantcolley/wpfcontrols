//-----------------------------------------------------------------------
// <copyright file="Message.cs" company="Development In Progress Ltd">
//     Copyright © Development In Progress Ltd 2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DevelopmentInProgress.WPFControls.Messaging
{
    /// <summary>
    /// Shows a message and returns the users response.
    /// </summary>
    public static class Message
    {
        /// <summary>
        /// Shows a message and returns the users response.
        /// </summary>
        /// <param name="text">The message text.</param>
        /// <param name="title">The message title.</param>
        /// <param name="messageType">The message type.</param>
        /// <param name="buttons">The buttons to display.</param>
        /// <param name="copyToClipboardEnabled">Enable copying message to the clipboard. Defaults is false.</param>
        /// <returns>The users response to the message.</returns>
        public static MessageBoxResult ShowBox(string text, string title, MessageType messageType,
            MessageBoxButtons buttons, bool copyToClipboardEnabled = false)
        {
            var message = new MessageBoxSettings()
            {
                Text = text,
                Title = title,
                MessageType = messageType,
                MessageBoxButtons = buttons,
                CopyToClipboardEnabled = copyToClipboardEnabled
            };

            return ShowBox(message);
        }

        /// <summary>
        /// Shows a message and returns the users response.
        /// </summary>
        /// <param name="message">The message to show including text, title and message type.</param>
        /// <param name="buttons">The buttons to display.</param>
        /// <param name="copyToClipboardEnabled">Enable copying message to the clipboard. Defaults is false.</param>
        /// <returns>The users response to the message.</returns>
        public static MessageBoxResult ShowBox(MessageSettings messageSettings, MessageBoxButtons buttons, bool copyToClipboardEnabled = false)
        {
            var messageBoxSettings = new MessageBoxSettings(messageSettings)
            {
                MessageBoxButtons = buttons,
                CopyToClipboardEnabled = copyToClipboardEnabled
            };

            return ShowBox(messageBoxSettings);
        }

        /// <summary>
        /// Shows a message and returns the users response.
        /// </summary>
        /// <param name="messageBoxSettings">The message to show including text, title and 
        /// message type, buttons and whether to enable copying the message to a clipboard</param>
        /// <returns>The users response to the message.</returns>
        public static MessageBoxResult ShowBox(MessageBoxSettings messageBoxSettings)
        {
            var model = new MessageBoxViewModel(messageBoxSettings);
            var view = new MessageBoxView();
            view.DataContext = model;
            view.ShowDialog();
            var result = model.MessageBoxResult;
            return result;
        }
    }
}
