using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevelopmentInProgress.WPFControls.FilterTree
{
    /// <summary>
    /// The <see cref="FilterTree"/> class provides the code behind the resource dictionary. 
    /// </summary>
    partial class FilterTree
    {
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
            {
                return;
            }

            var xamlFilterTree = textBox.Tag as XamlFilterTree;
            if (xamlFilterTree == null)
            {
                return;
            }

            var items = xamlFilterTree.ItemsSource;
            Contains(items, textBox.Text);
        }

        private bool Contains(IEnumerable items, string text)
        {
            bool result = false;
            foreach (var item in items)
            {
                var innerResult = false;
                var properties = item.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var interfaces = property.PropertyType.GetInterfaces();
                    foreach (var interfaceType in interfaces)
                    {
                        if (interfaceType.IsGenericType &&
                            interfaceType.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)))
                        {
                            var itemTypes = property.PropertyType.GetGenericArguments();
                            foreach (var itemType in itemTypes)
                            {
                                var textPropertyInfo = itemType.GetProperty("Text");
                                var visiblePropertyInfo = itemType.GetProperty("IsVisible");
                                if (textPropertyInfo != null
                                    && visiblePropertyInfo != null)
                                {
                                    innerResult = Contains((IEnumerable)property.GetValue(item, null), text);
                                }
                            }
                        }
                    }
                }

                if (Contains(item, text, innerResult))
                {
                    result = true;
                }
            }

            return result;
        }

        private bool Contains<T>(T t, string text, bool hasVisibleChild)
        {
            var textPropertyInfo = t.GetType().GetProperty("Text");
            var visiblePropertyInfo = t.GetType().GetProperty("IsVisible");

            if (textPropertyInfo != null
                && visiblePropertyInfo != null)
            {
                if (String.IsNullOrEmpty(text)
                    || hasVisibleChild)
                {
                    visiblePropertyInfo.SetValue(t, true, null);
                    return true;
                }

                var val = textPropertyInfo.GetValue(t, null);
                if (val != null
                    && val.ToString().ToLower().Contains(text.ToLower()))
                {
                    visiblePropertyInfo.SetValue(t, true, null);
                    return true;
                }

                visiblePropertyInfo.SetValue(t, false, null);
            }

            return false;
        }

        private void OnSelectItemDoubleClickHandler(object sender, MouseButtonEventArgs e)
        {
            OnSelectItem(sender);
            e.Handled = true;
        }

        private void OnSelectItemKeyUpHandler(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return)
            {
                return;
            }

            OnSelectItem(sender);
            e.Handled = true;
        }

        private void OnSelectItem<T>(T sender)
        {
            var item = sender as TreeViewItem;
            if (item == null)
            {
                return;
            }

            if (item.IsSelected)
            {
                var xamlFilterTree = item.Tag as XamlFilterTree;
                if (xamlFilterTree == null)
                {
                    return;
                }

                xamlFilterTree.SelectItemCommand.Execute(item.Header);
            }
        }

        //http://blogs.msdn.com/b/jaimer/archive/2007/07/12/drag-drop-in-wpf-explained-end-to-end.aspx
    }
}
