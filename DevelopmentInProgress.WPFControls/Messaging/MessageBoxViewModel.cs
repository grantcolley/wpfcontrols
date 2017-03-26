//-----------------------------------------------------------------------
// <copyright file="MessageBoxViewModel.cs" company="Development In Progress Ltd">
//     Copyright © Development In Progress Ltd 2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using DevelopmentInProgress.WPFControls.Converters;

namespace DevelopmentInProgress.WPFControls.Messaging
{
    /// <summary>
    /// The view model for the <see cref="MessageBoxView"/>.
    /// </summary>
    internal class MessageBoxViewModel
    {
        private const string OK = "Ok";
        private const string CANCEL = "Cancel";
        private const string YES = "Yes";
        private const string NO = "No";

        private readonly MessageBoxSettings messageBoxSettings;

        private bool isClosing;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxViewModel"/>.
        /// </summary>
        /// <param name="messageBoxSettings">The settings of the messsage to display.</param>
        internal MessageBoxViewModel(MessageBoxSettings messageBoxSettings)
        {
            this.messageBoxSettings = messageBoxSettings;

            CopyToClipboardEnabled = messageBoxSettings.CopyToClipboardEnabled;

            switch (messageBoxSettings.MessageBoxButtons)
            {
                case MessageBoxButtons.Ok:
                    ButtonLeftVisible = false;
                    ButtonLeftText = String.Empty;
                    ButtonCentreVisible = true;
                    ButtonCentreText = OK;
                    ButtonRightVisible = false;
                    ButtonRightText = String.Empty;
                    break;
                case MessageBoxButtons.OkCancel:
                    ButtonLeftVisible = true;
                    ButtonLeftText = OK;
                    ButtonCentreVisible = false;
                    ButtonCentreText = String.Empty;
                    ButtonRightVisible = true;
                    ButtonRightText = CANCEL;
                    break;
                case MessageBoxButtons.YesNo:
                    ButtonLeftVisible = true;
                    ButtonLeftText = YES;
                    ButtonCentreVisible = false;
                    ButtonCentreText = String.Empty;
                    ButtonRightVisible = true;
                    ButtonRightText = NO;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    ButtonLeftVisible = true;
                    ButtonLeftText = YES;
                    ButtonCentreVisible = true;
                    ButtonCentreText = NO;
                    ButtonRightVisible = true;
                    ButtonRightText = CANCEL;
                    break;
            }
        }

        /// <summary>
        /// Gets the type of message that is converted to an image by the <see cref="MessageTextToImageConverter"/>.
        /// </summary>
        internal string Type { get { return messageBoxSettings.Type; } }

        /// <summary>
        /// Gets the message to display.
        /// </summary>
        internal string Message { get { return messageBoxSettings.Text ?? String.Empty; } }

        /// <summary>
        /// Gets the message title.
        /// </summary>
        internal string Title { get { return messageBoxSettings.Title ?? String.Empty; } }

        /// <summary>
        /// Gets or sets a value indicating whether you can copy the message to a clipboard.
        /// </summary>
        internal bool CopyToClipboardEnabled { get; private set; }

        /// <summary>
        /// Gets the type of image to display for the clipboard
        /// once converted to image by <see cref="MessageTextToImageConverter"/>.
        /// </summary>
        internal string Clipboard { get { return "Clipboard"; } }

        /// <summary>
        /// Gets the message result.
        /// </summary>
        internal MessageBoxResult MessageBoxResult { get; set; }

        /// <summary>
        /// Gets text for the left button.
        /// </summary>
        internal string ButtonLeftText { get; set; }

        /// <summary>
        /// Gets the value to indicate whether the left button is visible.
        /// </summary>
        internal bool ButtonLeftVisible { get; set; }

        /// <summary>
        /// Gets text for the centre button.
        /// </summary>
        internal string ButtonCentreText { get; set; }

        /// <summary>
        /// Gets the value to indicate whether the centre button is visible.
        /// </summary>
        internal bool ButtonCentreVisible { get; set; }

        /// <summary>
        /// Gets text for the right button.
        /// </summary>
        internal string ButtonRightText { get; set; }

        /// <summary>
        /// Gets the value to indicate whether the right button is visible.
        /// </summary>
        internal bool ButtonRightVisible { get; set; }

        /// <summary>
        /// Handles the button click.
        /// </summary>
        /// <param name="button">The type of button clicked.</param>
        internal void OnButtonClick(string button)
        {
            if (!isClosing)
            {
                switch (button)
                {
                    case OK:
                        MessageBoxResult = MessageBoxResult.Ok;
                        break;
                    case CANCEL:
                        MessageBoxResult = MessageBoxResult.Cancel;
                        break;
                    case YES:
                        MessageBoxResult = MessageBoxResult.Yes;
                        break;
                    case NO:
                        MessageBoxResult = MessageBoxResult.No;
                        break;
                }
            }

            isClosing = true;
        }

        /// <summary>
        /// Copies the message and stack trace to the clipboard.
        /// </summary>
        internal void OnCopyClick()
        {
            string text = String.Format("{0}\r\n{1}", messageBoxSettings.Title, messageBoxSettings.Text);
            System.Windows.Clipboard.Clear();
            System.Windows.Clipboard.SetText(text);
        }
    }
}
