using System.Collections;
using System.Collections.Generic;
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
        private static readonly DependencyProperty RemoveItemCommandProperty;

        static XamlFilterTree()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (XamlFilterTree),
                new FrameworkPropertyMetadata(typeof (XamlFilterTree)));

            HeaderProperty = DependencyProperty.Register("Header", typeof (string), typeof (XamlFilterTree));
            
            FilterTextProperty = DependencyProperty.Register("FilterText", typeof (string), typeof (XamlFilterTree));

            IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof (bool), typeof (XamlFilterTree));

            ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable),
                typeof(XamlFilterTree), new FrameworkPropertyMetadata(new List<object>()));

            RemoveItemCommandProperty = DependencyProperty.Register("RemoveItemCommand", typeof(ICommand),
                typeof (XamlFilterTree));
        }

        public XamlFilterTree()
        {
            ItemsSource = new List<object>();
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

        public ICommand RemoveItemCommand
        {
            get { return (ICommand)GetValue(RemoveItemCommandProperty); }
            set { SetValue(RemoveItemCommandProperty, value); }
        }

        private void TextBoxBaseOnTextChanged(object sender, TextChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
