//-----------------------------------------------------------------------
// <copyright file="Message.cs" company="Development In Progress Ltd">
//     Copyright © Development In Progress Ltd 2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using DevelopmentInProgress.WPFControls.Converters;

namespace DevelopmentInProgress.WPFControls.Messaging
{
    /// <summary>
    /// Details of the message to be displayed.
    /// </summary>
    public class MessageSettings
    {
        /// <summary>
        /// Gets or sets the type of message to display.
        /// </summary>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// Gets or sets the message text to display.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the title of the message to display.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets a text representation of the message to be 
        /// converted to image by <see cref="MessageTextToImageConverter"/>.
        /// </summary>
        public string Type
        {
            get
            {
                return MessageType == MessageType.Error ? "Error"
                    : MessageType == MessageType.Warn ? "Warn"
                    : MessageType == MessageType.Question ? "Question" : "Info";
            }
        }
    }
}
