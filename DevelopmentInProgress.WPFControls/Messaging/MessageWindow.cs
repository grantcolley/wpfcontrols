//-----------------------------------------------------------------------
// <copyright file="MessageWindow.cs" company="Development In Progress Ltd">
//     Copyright © Development In Progress Ltd 2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DevelopmentInProgress.WPFControls.Messaging
{
    /// <summary>
    /// Shows a message and returns the users response.
    /// </summary>
    public static class MessageWindow
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
        public static MessageWindowResult Show(string text, string title, MessageType messageType,
            MessageWindowButtons buttons, bool copyToClipboardEnabled = false)
        {
            var message = new Message()
            {
                Text = text,
                Title = title,
                MessageType = messageType
            };

            return Show(message, buttons, copyToClipboardEnabled);
        }

        /// <summary>
        /// Shows a message and returns the users response.
        /// </summary>
        /// <param name="message">The message to show including text, title and message type.</param>
        /// <param name="buttons">The buttons to display.</param>
        /// <param name="copyToClipboardEnabled">Enable copying message to the clipboard. Defaults is false.</param>
        /// <returns>The users response to the message.</returns>
        public static MessageWindowResult Show(Message message, MessageWindowButtons buttons, bool copyToClipboardEnabled = false)
        {
            var messageWindowSettings = new MessageWindowSettings()
            {
                Message = message,
                MessageWindowButtons = buttons,
                CopyToClipboardEnabled = copyToClipboardEnabled
            };

            return Show(messageWindowSettings);
        }

        /// <summary>
        /// Shows a message and returns the users response.
        /// </summary>
        /// <param name="messageWindowSettings">The message to show including text, title and 
        /// message type, buttons and whether to enable copying the message to a clipboard</param>
        /// <returns>The users response to the message.</returns>
        public static MessageWindowResult Show(MessageWindowSettings messageWindowSettings)
        {
            var model = new MessageWindowViewModel(messageWindowSettings);
            var view = new MessageWindowView();
            view.DataContext = model;
            view.ShowDialog();
            var result = model.MessageWindowResult;
            return result;
        }
    }
}
