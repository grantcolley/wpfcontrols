# wpfcontrols
A suite of custom WPF controls... *still in beta*.

[![Build status](https://ci.appveyor.com/api/projects/status/6o6weumr92epubkr/branch/master?svg=true)](https://ci.appveyor.com/project/grantcolley/wpfcontrols/branch/master)

[NuGet package](https://www.nuget.org/packages/DipWpfControls/).

## NavigationPanel
The navigation panel can be docked to the side of a window, and allows you to switch between views or areas within an application.
* **NavigationPanel** - The main navigation container for a list of *NavigationPanelItem*'s.
* **NavigationPanelItem** - Displayed as tabs in the navigation panel to enable grouping of navigation lists.
* **NavigationList** - Contains a list of *NavigationListItem*'s.
* **NavigationListItem** - A navigable item which raises the *ItemClickedEvent* event and executes the *Command* when clicked.

## XamlFilterTree
A filterable tree view with support for adding and removing items and drag drop operations. 
