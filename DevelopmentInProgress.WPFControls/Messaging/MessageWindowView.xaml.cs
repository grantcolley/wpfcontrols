//-----------------------------------------------------------------------
// <copyright file="MessageWindowView.cs" company="Development In Progress Ltd">
//     Copyright © Development In Progress Ltd 2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace DevelopmentInProgress.WPFControls.Messaging
{
    /// <summary>
    /// Interaction logic for MessageWindowView.xaml for displaying a message.
    /// </summary>
    partial class MessageWindowView : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageWindowView"/> class.
        /// </summary>
        public MessageWindowView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a button click on the view and raises the 
        /// OnButtonClicked event handler on the <see cref="MessageWindowViewModel"/>.
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var messageWindowViewModel = (MessageWindowViewModel)this.DataContext;
            messageWindowViewModel.OnButtonClick(button.Content.ToString());
            this.Close();
        }

        /// <summary>
        /// Copies the message and stack trace to the clipboard.
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">Event arguments.</param>
        public void CopyClick(object sender, RoutedEventArgs e)
        {
            var messageWindowViewModel = (MessageWindowViewModel)this.DataContext;
            messageWindowViewModel.OnCopyClick();
        }

        /// <summary>
        /// Handles windows closing event on the view and raises the 
        /// OnButtonClicked event handler for a cancel action 
        /// on the <see cref="MessageWindowViewModel"/>.
        /// </summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">Event arguments.</param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var messageWindowViewModel = (MessageWindowViewModel)this.DataContext;
            messageWindowViewModel.OnButtonClick("Cancel");
        }
    }
}
