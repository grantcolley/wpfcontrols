using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevelopmentInProgress.WPFControls.Command;

namespace DevelopmentInProgress.WPFControls.Messaging
{
    public class MessagePanel : Control
    {
        private ICommand selectionChangedCommand;
        private ICommand expanderChangedCommand;

        private readonly static DependencyProperty SelectedMessageSettingsProperty;
        private readonly static DependencyProperty MessageSettingssProperty;
        private readonly static DependencyProperty IsExpandedProperty;
        private readonly static RoutedEvent ItemSelectedEvent;

        /// <summary>
        /// Static constructor for <see cref="MessagePanel"/> registers dependency properties and events.
        /// </summary>
        static MessagePanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessagePanel),
                new FrameworkPropertyMetadata(typeof(MessagePanel)));

            SelectedMessageSettingsProperty = DependencyProperty.Register("SelectedMessageSettings",
                typeof (MessagePanel), typeof (MessagePanel));

            MessageSettingssProperty = DependencyProperty.Register("MessageSettingss",
                typeof (List<MessagePanel>),
                typeof (MessagePanel), new FrameworkPropertyMetadata(new List<MessageSettings>()));

            IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof (bool), typeof (MessagePanel));

            ItemSelectedEvent = EventManager.RegisterRoutedEvent(
                "ItemSelected", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (MessagePanel));
        }

        /// <summary>
        /// Initializes a new instance of the MessagePanel class.
        /// </summary>
        public MessagePanel()
        {
            MessageSettingss = new List<MessageSettings>();
            selectionChangedCommand = new WpfCommand(OnSelectionChanged);
            expanderChangedCommand = new WpfCommand(OnExpanderChanged);
            IsExpanded = true;
        }
        
        /// <summary>
        /// Uses System.Windows.Interactivity in the Xaml where the 
        /// ListBox.SelectionChanged event triggers the SelectionChangedCommand. 
        /// </summary>
        public ICommand SelectionChangedCommand
        {
            get { return selectionChangedCommand; }
            set { selectionChangedCommand = value; }
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
        /// Gets or sets the selected <see cref="MessageSettings"/>.
        /// </summary>
        public MessageSettings SelectedMessageSettings
        {
            get { return (MessageSettings)GetValue(SelectedMessageSettingsProperty); }
            set { SetValue(SelectedMessageSettingsProperty, value); }
        }

        /// <summary>
        /// Gets or sets a list of <see cref="MessageSettings"/>'s.
        /// </summary>
        public List<MessageSettings> MessageSettingss
        {
            get { return (List<MessageSettings>)GetValue(MessageSettingssProperty); }
            set { SetValue(MessageSettingssProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the navigation panel list is expanded or collapsed.
        /// </summary>
        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="MessageSettings"/> is selected.
        /// </summary>
        public event RoutedEventHandler ItemSelected
        {
            add { AddHandler(ItemSelectedEvent, value); }
            remove { RemoveHandler(ItemSelectedEvent, value); }
        }

        /// <summary>
        /// Raises the ItemSelectedEvent passing in the selected MessageSettings.
        /// OnSelectionChanged handles the ListBox.SelectionChanged event which  
        /// triggers the SelectionChangedCommand using System.Windows.Interactivity.
        /// </summary>
        /// <param name="arg">The selected MessageSettings.</param>
        private void OnSelectionChanged(object arg)
        {
            if (arg == null)
            {
                return;
            }

            var MessageSettings = arg as MessageSettings;
            var args = new RoutedEventArgs(ItemSelectedEvent, MessageSettings);
            RaiseEvent(args);
        }

        /// <summary>
        /// Toggles the navigation panel list expanded / un-expanded.
        /// </summary>
        /// <param name="arg">Null</param>
        private void OnExpanderChanged(object arg)
        {

            if (arg == null)
            {
                return;
            }

            SelectedMessageSettings = arg as MessageSettings;
            IsExpanded = !IsExpanded;
        }
    }
}
