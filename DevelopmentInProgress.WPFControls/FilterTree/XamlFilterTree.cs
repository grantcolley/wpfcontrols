using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevelopmentInProgress.WPFControls.Command;

namespace DevelopmentInProgress.WPFControls.FilterTree
{
    public class XamlFilterTree : Control
    {
        private ICommand itemDeletedCommand;

        private readonly static DependencyProperty HeaderProperty;
        private readonly static DependencyProperty FilterTextProperty;
        private readonly static DependencyProperty ItemsSourceProperty;
        private readonly static DependencyProperty IsExpandedProperty;
        private static readonly RoutedEvent ItemDeletedEvent;
            
        static XamlFilterTree()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (XamlFilterTree),
                new FrameworkPropertyMetadata(typeof (XamlFilterTree)));

            HeaderProperty = DependencyProperty.Register("Header", typeof (string), typeof (XamlFilterTree));
            
            FilterTextProperty = DependencyProperty.Register("FilterText", typeof (string), typeof (XamlFilterTree));

            IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof (bool), typeof (XamlFilterTree));

            ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable),
                typeof(XamlFilterTree), new FrameworkPropertyMetadata(new List<object>()));

            ItemDeletedEvent = EventManager.RegisterRoutedEvent("ItemDeleted", RoutingStrategy.Bubble,
                typeof (RoutedEventHandler), typeof (XamlFilterTree));
        }

        public XamlFilterTree()
        {
            ItemsSource = new List<object>();
            itemDeletedCommand = new WpfCommand(OnItemDeleted);
        }

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public string FilterText
        {
            get { return GetValue(FilterTextProperty).ToString(); }
            set { SetValue(FilterTextProperty, value); }
        }

        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

        public List<object> ItemsSource
        {
            get { return (List<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public ICommand ItemDeletedCommand
        {
            get { return itemDeletedCommand; }
            set { itemDeletedCommand = value; }
        }

        public event RoutedEventHandler ItemDeleted
        {
            add { AddHandler(ItemDeletedEvent, value); }
            remove { RemoveHandler(ItemDeletedEvent, value); }
        }

        private void OnItemDeleted(object arg)
        {
            if (arg == null)
            {
                return;
            }

            var args = new RoutedEventArgs(ItemDeletedEvent, arg);
            RaiseEvent(args);
        }

        private void TextBoxBaseOnTextChanged(object sender, TextChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
