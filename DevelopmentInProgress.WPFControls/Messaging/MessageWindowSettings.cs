//-----------------------------------------------------------------------
// <copyright file="MessageWindowSettings.cs" company="Development In Progress Ltd">
//     Copyright © Development In Progress Ltd 2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DevelopmentInProgress.WPFControls.Messaging
{
    /// <summary>
    /// Details settings for the message to be displayed.
    /// </summary>
    public class MessageWindowSettings
    {
        /// <summary>
        /// Gets or sets the message object.
        /// </summary>
        public Message Message { get; set; }

        /// <summary>
        /// Gets or sets the message window button to be displayed.
        /// </summary>
        public MessageWindowButtons MessageWindowButtons { get; set; }

        /// <summary>
        /// Gets or sets the message result returned to the calling code.
        /// </summary>
        public MessageWindowResult MessageWindowResult { get; set; }

        /// <summary>
        /// Gets or sets a value to indicate whether the message can be copied to the clipboard.
        /// </summary>
        public bool CopyToClipboardEnabled { get; set; }
    }
}
