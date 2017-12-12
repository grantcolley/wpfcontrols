﻿//-----------------------------------------------------------------------
// <copyright file="MessageBoxText.cs" company="Development In Progress Ltd">
//     Copyright © Development In Progress Ltd 2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;

namespace DevelopmentInProgress.WPFControls.Messaging
{
    /// <summary>
    /// Settings for the text area of the message box.
    /// </summary>
    public class MessageBoxText
    {
        /// <summary>
        /// Gets or sets the text alignment. Default is Center aligned.
        /// </summary>
        public TextAlignment TextAlignment { get; set; } = TextAlignment.Center;

        /// <summary>
        /// Gets or sets the max width of the text area. Default is 250.
        /// </summary>
        public int MaxWidth { get; set; } = 250;
    }
}
