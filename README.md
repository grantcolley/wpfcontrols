# wpfcontrols
[![Build status](https://ci.appveyor.com/api/projects/status/6o6weumr92epubkr/branch/master?svg=true)](https://ci.appveyor.com/project/grantcolley/wpfcontrols/branch/master)

[NuGet package](https://www.nuget.org/packages/DipWpfControls/).

A suite of custom WPF controls including:
* [NavigationPanel](#navigationpanel)
* [XamlFilterTree](#xamlfiltertree)
* [Messaging](#messaging)
   * [MessagePanel](#messagepanel)
   * [Dialog.ShowMessage](#dialog.showmessage)
   * [Dialog.ShowException](#dialog.showmessage)
  
An example WPF window with a **NavigationPanel** docked to the left, a **MessagePanel** docked to the bottom and a **XamlFilterTree** filling the centre.

![Alt text](/README-images/mainExample.PNG?raw=true "Example WPF window with a NavigationPanel and XamlFilterTree")

## NavigationPanel
The *NavigationPanel* can be docked to the side of a window, and allows you to switch between views or areas within an application.

* **NavigationPanel** - The *NavigationPanel* contains a list of *NavigationPanelItem's*, each of which is a logical area within the application.

* **NavigationPanelItem** - Each *NavigationPanelItem* is displayed as a tab in the navigation panel and contains a list of *NavigationList's*, which groups views within an area of an application. 

* **NavigationList** - A *NavigationList* groups lists of views or *NavigationListItem's*, that can be navigated to.

* **NavigationListItem** - A navigable item or view, which when clicked, raises the *ItemClickedEvent* event and executes the *Command*.

The following example shows a navigation panel with two main areas within an application, *Manage Relationships* and *User Administration*. 
* The *Manage Relationships* tab groups the views for maintaining *Customers* and *Contacts*
* The *User Administration* tab groups the views for managing *Users* and their *Roles*.

![Alt text](/README-images/navigationPanel.PNG?raw=true "Navigation Panel")

##### Xaml
```C#
<navigationPanel:NavigationPanel x:Name="NavigationPanel" DockPanel.Dock="Left" Margin="2">
    <navigationPanel:NavigationPanel.NavigationPanelItems>
        <navigationPanel:NavigationPanelItem NavigationPanelItemName="Manage Users" ImageLocation="pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/User_Manage.png">
            <navigationPanel:NavigationPanelItem.NavigationList>
                <navigationPanel:NavigationList NavigationListName="Users">
                    <navigationPanel:NavigationList.NavigationListItems>
                        <navigationPanel:NavigationListItem ItemName="Users" ItemClicked="NavigationListItem_OnItemClicked"  ImageLocation="pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/User_List.png"/>
                        <navigationPanel:NavigationListItem ItemName="Add New User" ItemClicked="NavigationListItem_OnItemClicked"  ImageLocation="pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/User_Add.png"/>
                    </navigationPanel:NavigationList.NavigationListItems>
                </navigationPanel:NavigationList>
                <navigationPanel:NavigationList NavigationListName="Roles &amp; Activities">
                    <navigationPanel:NavigationList.NavigationListItems>
                        <navigationPanel:NavigationListItem ItemName="Roles" ItemClicked="NavigationListItem_OnItemClicked"  ImageLocation="pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/Roles.png"/>
                        <navigationPanel:NavigationListItem ItemName="Activities" ItemClicked="NavigationListItem_OnItemClicked"  ImageLocation="pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/Activities.png"/>
                    </navigationPanel:NavigationList.NavigationListItems>
                </navigationPanel:NavigationList>
            </navigationPanel:NavigationPanelItem.NavigationList>
        </navigationPanel:NavigationPanelItem>
        <navigationPanel:NavigationPanelItem NavigationPanelItemName="Customers &amp; Orders" ImageLocation="pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/customers.png">
            <navigationPanel:NavigationPanelItem.NavigationList>
                <navigationPanel:NavigationList NavigationListName="Customers">
                    <navigationPanel:NavigationList.NavigationListItems>
                        <navigationPanel:NavigationListItem ItemName="Customers" ItemClicked="NavigationListItem_OnItemClicked" ImageLocation="pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/CustomerList.png"/>
                        <navigationPanel:NavigationListItem ItemName="Add New Customer" ItemClicked="NavigationListItem_OnItemClicked" ImageLocation="pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/AddNewCustomer.png"/>
                    </navigationPanel:NavigationList.NavigationListItems>
                </navigationPanel:NavigationList>
                <navigationPanel:NavigationList NavigationListName="Orders">
                    <navigationPanel:NavigationList.NavigationListItems>
                        <navigationPanel:NavigationListItem ItemName="Orders" ItemClicked="NavigationListItem_OnItemClicked" ImageLocation="pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/Orders.png"/>
                        <navigationPanel:NavigationListItem ItemName="Place New Order" ItemClicked="NavigationListItem_OnItemClicked" ImageLocation="pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/neworder.png"/>
                    </navigationPanel:NavigationList.NavigationListItems>
                </navigationPanel:NavigationList>
            </navigationPanel:NavigationPanelItem.NavigationList>
        </navigationPanel:NavigationPanelItem>
    </navigationPanel:NavigationPanel.NavigationPanelItems>
</navigationPanel:NavigationPanel>
```

##### C# 
```C#
var manageUsersPanelItem = new NavigationPanelItem();
manageUsersPanelItem.NavigationPanelItemName = "Manage Users";
manageUsersPanelItem.ImageLocation = @"pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/User_Manage.png";

var userAdministrationList = new NavigationList();
userAdministrationList.NavigationListName = "User Administration";

var usersListItem = new NavigationListItem();
usersListItem.ItemName = "Users";
usersListItem.ImageLocation = @"pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/User_List.png";
usersListItem.ItemClicked += NavigationListItem_OnItemClicked;

var addNewUserListItem = new NavigationListItem();
addNewUserListItem.ItemName = "Add New User";
addNewUserListItem.ImageLocation = @"pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/User_Add.png";
addNewUserListItem.ItemClicked += NavigationListItem_OnItemClicked;

userAdministrationList.NavigationListItems.Add(usersListItem);
userAdministrationList.NavigationListItems.Add(addNewUserListItem);

var rolesAndActivitiesList = new NavigationList();
rolesAndActivitiesList.NavigationListName = "Roles & Activities";

var rolesListItem = new NavigationListItem();
rolesListItem.ItemName = "Roles";
rolesListItem.ImageLocation = @"pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/Roles.png";
rolesListItem.ItemClicked += NavigationListItem_OnItemClicked;

var activitiesListItem = new NavigationListItem();
activitiesListItem.ItemName = "Activities";
activitiesListItem.ImageLocation = @"pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/Activities.png";
activitiesListItem.ItemClicked += NavigationListItem_OnItemClicked;

rolesAndActivitiesList.NavigationListItems.Add(rolesListItem);
rolesAndActivitiesList.NavigationListItems.Add(activitiesListItem);

manageUsersPanelItem.NavigationList.Add(userAdministrationList);
manageUsersPanelItem.NavigationList.Add(rolesAndActivitiesList);

var customersAndOrdersPanelItem = new NavigationPanelItem();
customersAndOrdersPanelItem.NavigationPanelItemName = "Customers & Orders";
customersAndOrdersPanelItem.ImageLocation = @"pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/Customers.png";

var customerAdministrationList = new NavigationList();
userAdministrationList.NavigationListName = "Customers Administration";

var customersListItem = new NavigationListItem();
customersListItem.ItemName = "Customers";
customersListItem.ImageLocation = @"pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/Customers_List.png";
customersListItem.ItemClicked += NavigationListItem_OnItemClicked;

var addNewCustomerListItem = new NavigationListItem();
addNewCustomerListItem.ItemName = "Add New Customer";
addNewCustomerListItem.ImageLocation = @"pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/Add_Customer.png";
addNewCustomerListItem.ItemClicked += NavigationListItem_OnItemClicked;

customerAdministrationList.NavigationListItems.Add(customersListItem);
customerAdministrationList.NavigationListItems.Add(addNewCustomerListItem);

var manageOrdersList = new NavigationList();
manageOrdersList.NavigationListName = "Manage Orders";

var ordersListItem = new NavigationListItem();
ordersListItem.ItemName = "Orders";
ordersListItem.ImageLocation = @"pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/Orders.png";
ordersListItem.ItemClicked += NavigationListItem_OnItemClicked;

var newOrderListItem = new NavigationListItem();
newOrderListItem.ItemName = "Place New Order";
newOrderListItem.ImageLocation = @"pack://application:,,,/DevelopmentInProgress.WPFControls.Test;component/Images/neworder.png";
newOrderListItem.ItemClicked += NavigationListItem_OnItemClicked;

manageOrdersList.NavigationListItems.Add(ordersListItem);
manageOrdersList.NavigationListItems.Add(newOrderListItem);

customersAndOrdersPanelItem.NavigationList.Add(customerAdministrationList);
customersAndOrdersPanelItem.NavigationList.Add(manageOrdersList);

NavigationPanel.NavigationPanelItems.Add(manageUsersPanelItem);
NavigationPanel.NavigationPanelItems.Add(customersAndOrdersPanelItem);
```

## XamlFilterTree
The **XamFilterTree** is a filterable treeview with support for adding and removing items and drag drop operations.

#### Filtering
In order for an object to qualify for filtering it must have two public settable properties:
* Text (string)
* IsVisible (bool)

As the user enters text into the filter textbox the treeview’s *ItemsSource* is traversed. If the items *Text* property contains the filter text, it’s *IsVisible* property is set to true, else it is set to false. If an item’s “IsVisible” property is set to true, then so will its parent’s regardless of the value of the parent’s *Text* property, all the way up the hierarchy to the root. If no text is entered into the filter textbox, all items with a *IsVisible* property will be set to true. If an item does not have the *Text* and *IsVisible* properties then it is ignored i.e. it will remain visible as long its parent is visible.

> **NOTE:** _The filter does not add or remove items from a list but rather sets the *IsVisible* field on each item as appropriate._

#### Commands
The **XamlFilterTree** also allows a view model to respond to the following commands:
* RemoveItemCommand
* AddItemCommand
* SelectItemCommand
* DragDropCommand

The example below shows a list of users, their assigned roles and the activities associated with each role. The *User*, *Role* and *Activity* objects expose public *Text* and *IsVisible* properties and can be filtered in or out of view when the user types in the filter textbox above the list.

![Alt text](/README-images/filterTree.PNG?raw=true "Filter Tree")

##### Xaml
```C#
<filterTree:XamlFilterTree 
    Header="Users" 
    Margin="2"
    ItemsSource="{Binding Users}" 
    RemoveItemCommand="{Binding ItemDeletedCommand}"
    AddItemCommand="{Binding ItemAddCommand}"
    SelectItemCommand="{Binding ItemSelectCommand}"
    DragDropCommand="{Binding DragDropCommand}">
    <filterTree:XamlFilterTree.Resources>
        <HierarchicalDataTemplate DataType="{x:Type model:User}"
                    ItemsSource="{Binding Roles}">
            <StackPanel Orientation="Horizontal">
                <Image Source="{Binding Path=Image, Converter={StaticResource UriStringToImageConverter}}" 
                       ToolTip="{Binding Text}" Margin="2" MaxHeight="20" MaxWidth="20" VerticalAlignment="Center"/>
                <TextBlock Text="{Binding Text}" Margin="2" VerticalAlignment="Center"/>
            </StackPanel>
        </HierarchicalDataTemplate>
        <HierarchicalDataTemplate DataType="{x:Type model:Role}"
                    ItemsSource="{Binding Activities}">
            <StackPanel Orientation="Horizontal">
                <Image Source="{Binding Path=Image, Converter={StaticResource UriStringToImageConverter}}" 
                       ToolTip="{Binding Text}" Margin="2" MaxHeight="20" MaxWidth="20" VerticalAlignment="Center"/>
                <TextBlock Text="{Binding Text}" Margin="2" VerticalAlignment="Center"/>
            </StackPanel>
        </HierarchicalDataTemplate>
        <DataTemplate DataType="{x:Type model:Activity}">
            <StackPanel Orientation="Horizontal">
                <Image Source="{Binding Path=Image, Converter={StaticResource UriStringToImageConverter}}" 
                       ToolTip="{Binding Text}" Margin="2" MaxHeight="20" MaxWidth="20" VerticalAlignment="Center"/>
                <TextBlock Text="{Binding Text}" Margin="2" VerticalAlignment="Center"/>
            </StackPanel>
        </DataTemplate>
    </filterTree:XamlFilterTree.Resources>
</filterTree:XamlFilterTree>
```

## Messaging

#### MessagePanel

#### Dialog.ShowMessage

#### Dialog.ShowException
