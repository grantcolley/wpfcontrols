//-----------------------------------------------------------------------
// <copyright file="MessagePanel.cs" company="Development In Progress Ltd">
//     Copyright © Development In Progress Ltd 2017. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevelopmentInProgress.WPFControls.Command;

namespace DevelopmentInProgress.WPFControls.Messaging
{
    public class MessagePanel : Control
    {
        private ICommand expanderChangedCommand;

        private readonly static DependencyProperty HeaderTextProperty;
        private readonly static DependencyProperty MessagesProperty;
        private readonly static DependencyProperty IsMessagePanelExpandedProperty;
        private readonly static DependencyProperty IsMessagePanelVisibleProperty;

        /// <summary>
        /// Static constructor for <see cref="MessagePanel"/> registers dependency properties and events.
        /// </summary>
        static MessagePanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessagePanel),
                new FrameworkPropertyMetadata(typeof(MessagePanel)));

            HeaderTextProperty = DependencyProperty.Register("HeaderText", typeof (string), typeof (MessagePanel));

            MessagesProperty = DependencyProperty.Register("Messages",
                typeof(ObservableCollection<Message>),
                typeof(MessagePanel), new FrameworkPropertyMetadata(new ObservableCollection<Message>()));

            IsMessagePanelExpandedProperty = DependencyProperty.Register("IsMessagePanelExpanded", typeof(bool), typeof(MessagePanel));

            IsMessagePanelVisibleProperty = DependencyProperty.Register("IsMessagePanelVisible", typeof(bool), typeof(MessagePanel));
        }

        /// <summary>
        /// Initializes a new instance of the MessagePanel class.
        /// </summary>
        public MessagePanel()
        {
            Messages = new ObservableCollection<Message>();
            expanderChangedCommand = new WpfCommand(OnExpanderChanged);
            IsMessagePanelExpanded = true;
            IsMessagePanelVisible = true;
        }

        /// <summary>
        /// Uses System.Windows.Interactivity in the Xaml where the
        /// Image.MouseDown event triggers the ExpanderChangedCommand.
        /// </summary>
        public ICommand ExpanderChangedCommand
        {
            get { return expanderChangedCommand; }
            set { expanderChangedCommand = value; }
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
        public bool IsMessagePanelExpanded
        {
            get { return (bool)GetValue(IsMessagePanelExpandedProperty); }
            set { SetValue(IsMessagePanelExpandedProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the message panel is visible or collapsed.
        /// </summary>
        public bool IsMessagePanelVisible
        {
            get { return (bool)GetValue(IsMessagePanelVisibleProperty); }
            set { SetValue(IsMessagePanelVisibleProperty, value); }
        }

        /// <summary>
        /// Toggles the message panel is expanded or callapsed.
        /// </summary>
        /// <param name="arg">Null</param>
        private void OnExpanderChanged(object arg)
        {

            if (arg == null)
            {
                return;
            }

            IsMessagePanelExpanded = !IsMessagePanelExpanded;
        }
    }
}
