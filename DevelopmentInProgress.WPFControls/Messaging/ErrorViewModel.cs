﻿namespace DevelopmentInProgress.WPFControls.Messaging
{
    /// <summary>
    /// The view model for the <see cref="ErrorView"/> class.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Initializes a new insatance of the <see cref="ErrorViewModel"/> class.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="stackTrace">The stacktrace to display.</param>
        public ErrorViewModel(string message, string stackTrace)
        {
            Message = message;
            StackTrace = stackTrace;
        }

        /// <summary>
        /// Gets the type of image to display for the error once 
        /// converted to image by <see cref="MessageTextToImageConverter"/>.
        /// </summary>
        public string Type { get { return "Error"; } }

        /// <summary>
        /// Gets the type of image to display for the clipboard
        /// once converted to image by <see cref="MessageTextToImageConverter"/>.
        /// </summary>
        public string Clipboard { get { return "Clipboard"; } }

        /// <summary>
        /// Gets the message to display.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Gets the stacktrace to display.
        /// </summary>
        public string StackTrace { get; private set; }
    }
}
