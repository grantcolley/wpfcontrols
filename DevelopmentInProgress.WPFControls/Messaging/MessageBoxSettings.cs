﻿//-----------------------------------------------------------------------
// <copyright file="MessageBoxSettings.cs" company="Development In Progress Ltd">
//     Copyright © Development In Progress Ltd 2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DevelopmentInProgress.WPFControls.Messaging
{
    /// <summary>
    /// Details settings for the message to be displayed.
    /// </summary>
    public class MessageBoxSettings : Message
    {
        /// <summary>
        /// Gets or sets the message box button to be displayed.
        /// </summary>
        public MessageBoxButtons MessageBoxButtons { get; set; }

        /// <summary>
        /// Gets or sets the message result returned to the calling code.
        /// </summary>
        public MessageBoxResult MessageBoxResult { get; set; }

        /// <summary>
        /// Gets or sets a value to indicate whether the message can be copied to the clipboard.
        /// </summary>
        public bool CopyToClipboardEnabled { get; set; }
    }
}
