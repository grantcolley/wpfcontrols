using System;
using System.Windows.Controls;

namespace DevelopmentInProgress.WPFControls.FilterTree
{
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

            foreach (var item in items)
            {
                Contains(item, textBox.Text, true);
            }
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
    }
}
