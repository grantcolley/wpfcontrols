﻿using System.Windows.Controls;
using System.Windows.Input;

namespace DevelopmentInProgress.WPFControls.NavigationPanel
{
    partial class NavigationPanelResources
    {
        private void ExpanderImageMouseDown(object sender, MouseButtonEventArgs e)
        {
            var image = sender as Image;
            if (image == null
                || image.Tag == null)
            {
                return;
            }

            var navigationPanel = image.Tag as NavigationPanel;
            if (navigationPanel == null)
            {
                return;
            }

            navigationPanel.ExpanderChangedCommand.Execute(navigationPanel.SelectedNavigationPanelItem);
        }

        private void NavigationPanelItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox == null
                || listBox.Tag == null)
            {
                return;
            }

            var navigationPanel = listBox.Tag as NavigationPanel;
            if (navigationPanel == null)
            {
                return;
            }

            navigationPanel.SelectionChangedCommand.Execute(navigationPanel.SelectedNavigationPanelItem);
        }
    }
}
