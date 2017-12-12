﻿//-----------------------------------------------------------------------
// <copyright file="MessagePanel.cs" company="Development In Progress Ltd">
//     Copyright © Development In Progress Ltd 2017. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DevelopmentInProgress.WPFControls.Messaging
{
    public class MessagePanel : Control
    {
        private static readonly DependencyProperty HeaderTextProperty;
        private static readonly DependencyProperty MessagesProperty;
        private static readonly DependencyProperty IsExpandedProperty;
        private static readonly DependencyProperty HeaderBackgroundProperty;
        private static readonly DependencyProperty PanelBackgroundProperty;
        private static readonly DependencyProperty ClearMessagesCommandProperty;
        private static readonly DependencyProperty ShowMessageTextAlignmentProperty;
        private static readonly DependencyProperty ShowMessageTextAreaMaxWidthProperty;

        /// <summary>
        /// Static constructor for <see cref="MessagePanel"/> registers dependency properties and events.
        /// </summary>
        static MessagePanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessagePanel),
                new FrameworkPropertyMetadata(typeof(MessagePanel)));

            HeaderTextProperty = DependencyProperty.Register("HeaderText", typeof (string), typeof (MessagePanel), new FrameworkPropertyMetadata("Messages"));

            MessagesProperty = DependencyProperty.Register("Messages",
                typeof(ObservableCollection<Message>),
                typeof(MessagePanel), new FrameworkPropertyMetadata(new ObservableCollection<Message>()));

            IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(MessagePanel), new FrameworkPropertyMetadata(true));

            PanelBackgroundProperty = DependencyProperty.Register("PanelBackground", typeof(Brush), typeof(MessagePanel));

            HeaderBackgroundProperty = DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(MessagePanel));

            ShowMessageTextAlignmentProperty = DependencyProperty.Register("ShowMessageTextAlignment", typeof(TextAlignment), typeof(MessagePanel), new FrameworkPropertyMetadata(TextAlignment.Center));

            ShowMessageTextAreaMaxWidthProperty = DependencyProperty.Register("ShowMessageTextAreaMaxWidth", typeof(int), typeof(MessagePanel), new FrameworkPropertyMetadata(250));

            ClearMessagesCommandProperty = DependencyProperty.Register("ClearMessages", typeof (ICommand),
                typeof (MessagePanel));
        }

        /// <summary>
        /// Initializes a new instance of the MessagePanel class.
        /// </summary>
        public MessagePanel()
        {
            Messages = new ObservableCollection<Message>();
        }

        /// <summary>
        /// Gets or sets the command to clear the list.
        /// </summary>
        public ICommand ClearMessages
        {
            get { return (ICommand)GetValue(ClearMessagesCommandProperty); }
            set { SetValue(ClearMessagesCommandProperty, value); }
        }

        /// <summary>
        /// Gets or sets a list of <see cref="Message"/>'s.
        /// </summary>
        public ObservableCollection<Message> Messages
        {
            get { return (ObservableCollection<Message>)GetValue(MessagesProperty); }
            set { SetValue(MessagesProperty, value); }
        }

        /// <summary>
        /// Gets or sets the panel header text.
        /// </summary>
        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the message panel is expanded or collapsed.
        /// </summary>
        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

        /// <summary>
        /// Gets or sets the header background colour.
        /// </summary>
        public Brush HeaderBackground
        {
            get { return (Brush) GetValue(HeaderBackgroundProperty); }
            set { SetValue(HeaderBackgroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets the panel background colour.
        /// </summary>
        public Brush PanelBackground
        {
            get { return (Brush)GetValue(PanelBackgroundProperty); }
            set { SetValue(PanelBackgroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets the text alignment when showing the message in the popup dialog box.
        /// </summary>
        public TextAlignment ShowMessageTextAlignment
        {
            get { return (TextAlignment)GetValue(ShowMessageTextAlignmentProperty); }
            set { SetValue(ShowMessageTextAlignmentProperty, value); }
        }

        /// <summary>
        /// Gets or sets the max width of the text area when showing the message in the popup dialog box.
        /// </summary>
        public int ShowMessageTextAreaMaxWidth
        {
            get { return (int)GetValue(ShowMessageTextAreaMaxWidthProperty); }
            set { SetValue(ShowMessageTextAreaMaxWidthProperty, value); }
        }
    }
}
