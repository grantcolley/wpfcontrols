using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevelopmentInProgress.WPFControls.FilterTree
{
    public class XamlFilterTree : Control
    {
        private readonly static DependencyProperty HeaderProperty;
        private readonly static DependencyProperty FilterTextProperty;
        private readonly static DependencyProperty ItemsSourceProperty;
        private readonly static DependencyProperty IsExpandedProperty;
        private static readonly DependencyProperty AddItemCommandProperty;
        private static readonly DependencyProperty RemoveItemCommandProperty;

        static XamlFilterTree()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (XamlFilterTree),
                new FrameworkPropertyMetadata(typeof (XamlFilterTree)));

            HeaderProperty = DependencyProperty.Register("Header", typeof (string), typeof (XamlFilterTree));
            
            FilterTextProperty = DependencyProperty.Register("FilterText", typeof (string), typeof (XamlFilterTree));

            IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof (bool), typeof (XamlFilterTree));

            ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable),
                typeof(XamlFilterTree));

            AddItemCommandProperty = DependencyProperty.Register("AddItemCommand", typeof (ICommand),
                typeof (XamlFilterTree));

            RemoveItemCommandProperty = DependencyProperty.Register("RemoveItemCommand", typeof(ICommand),
                typeof (XamlFilterTree));
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

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public ICommand RemoveItemCommand
        {
            get { return (ICommand)GetValue(RemoveItemCommandProperty); }
            set { SetValue(RemoveItemCommandProperty, value); }
        }

        public ICommand AddItemCommand
        {
            get { return (ICommand)GetValue(AddItemCommandProperty); }
            set { SetValue(AddItemCommandProperty, value); }
        }
    }
}
