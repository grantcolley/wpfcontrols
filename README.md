# wpfcontrols
[![Build status](https://ci.appveyor.com/api/projects/status/6o6weumr92epubkr/branch/master?svg=true)](https://ci.appveyor.com/project/grantcolley/wpfcontrols/branch/master)

[NuGet package](https://www.nuget.org/packages/DipWpfControls/).

A suite of custom WPF controls including:
* [NavigationPanel](#navigationpanel)
* [XamlFilterTree](#xamlfiltertree)
* [Messaging](#messaging)
   * [MessagePanel](#messagepanel)
   * [ShowMessage](#showmessage)
   * [ShowException](#showmessage)
  
An example WPF window with a **NavigationPanel** docked to the left and **XamlFilterTree** filling the centre.

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
var customerList = new NavigationListItem();
customerList.ItemName = "Customer List";
customerList.ImageLocation = @"pack://application:,,,/RelationshipManager;component/CustomerList.png";
customerList.ItemClicked += CustomerListClicked;

var addNewCustomer = new NavigationListItem();
addNewCustomer.ItemName = "Add New Customer";
addNewCustomer.ImageLocation = @"pack://application:,,,/RelationshipManager;component/AddNewCustomer.png";
addNewCustomer.ItemClicked += AddNewCustomerClicked;

var customers = new NavigationList();
customers.NavigationListName = "Customers";
customers.NavigationListItems.Add(customerList);
customers.NavigationListItems.Add(addNewCustomer);

var contactList = new NavigationListItem();
contactList.ItemName = "Contact List";
contactList.ImageLocation = @"pack://application:,,,/RelationshipManager;component/ContactList.png";
contactList.ItemClicked += ContactListClicked;

var addNewContact = new NavigationListItem();
addNewContact.ItemName = "Add New Contact";
addNewContact.ImageLocation = @"pack://application:,,,/RelationshipManager;component/AddNewContact.png";
addNewContact.ItemClicked += AddNewContactClicked;

var contacts = new NavigationList();
contacts.NavigationListName = "Contacts";
contacts.NavigationListItems.Add(contactList);
contacts.NavigationListItems.Add(addNewContact);

var manageRelationships = new NavigationPanelItem();
manageRelationships.NavigationPanelItemName = "Manage Relationships";
manageRelationships.ImageLocation = @"pack://application:,,,/RelationshipManager;component/ManageRelationships.png";
manageRelationships.NavigationList.Add(customers);
manageRelationships.NavigationList.Add(contacts);

var userList = new NavigationListItem();
userList.ItemName = "User List";
userList.ImageLocation = @"pack://application:,,,/RelationshipManager;component/UserList.png";
userList.ItemClicked += UserListClicked;

var addNewUser = new NavigationListItem();
addNewUser.ItemName = "Add New User";
addNewUser.ImageLocation = @"pack://application:,,,/RelationshipManager;component/AddNewUser.png";
addNewUser.ItemClicked += AddNewUserClicked;

var users = new NavigationList();
users.NavigationListName = "Users";
users.NavigationListItems.Add(userList);
users.NavigationListItems.Add(addNewUser);

var roleList = new NavigationListItem();
roleList.ItemName = "Role List";
roleList.ImageLocation = @"pack://application:,,,/RelationshipManager;component/RoleList.png";
roleList.ItemClicked += RoleListClicked;

var addNewRole = new NavigationListItem();
addNewRole.ItemName = "Add New Role";
addNewRole.ImageLocation = @"pack://application:,,,/RelationshipManager;component/AddNewRole.png";
addNewRole.ItemClicked += AddNewRoleClicked;

var roles = new NavigationList();
roles.NavigationListName = "Roles";
roles.NavigationListItems.Add(roleList);
roles.NavigationListItems.Add(addNewRole);

var userAdministration = new NavigationPanelItem();
userAdministration.NavigationPanelItemName = "User Administration";
userAdministration.ImageLocation = @"pack://application:,,,/RelationshipManager;component/UserAdministration.png";
userAdministration.NavigationList.Add(users);
userAdministration.NavigationList.Add(roles);

navigationPanel.NavigationPanelItems.Add(manageRelationships);
navigationPanel.NavigationPanelItems.Add(userAdministration);
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
<ft:XamlFilterTree 
    Header="User List" 
    ItemsSource="{Binding Users}" 
    RemoveItemCommand="{Binding ItemDeletedCommand}"
    AddItemCommand="{Binding ItemAddCommand}"
    SelectItemCommand="{Binding ItemSelectCommand}"
    DragDropCommand="{Binding DragDropCommand}">
    <ft:XamlFilterTree.Resources>
        <HierarchicalDataTemplate DataType="{x:Type relationshipManager:User}"
                                  ItemsSource="{Binding Roles}">
            <StackPanel Orientation="Horizontal">
                <Image Source="{Binding Path=Image, Converter={StaticResource UriStringToImageConverter}}" 
                       ToolTip="{Binding Text}" Margin="2" MaxHeight="20" MaxWidth="20" VerticalAlignment="Center"/>
                <TextBlock Text="{Binding Text}" Margin="2" VerticalAlignment="Center"/>
            </StackPanel>
        </HierarchicalDataTemplate>
        <HierarchicalDataTemplate DataType="{x:Type relationshipManager:Role}"
                                  ItemsSource="{Binding Activities}">
            <StackPanel Orientation="Horizontal">
                <Image Source="{Binding Path=Image, Converter={StaticResource UriStringToImageConverter}}" 
                       ToolTip="{Binding Text}" Margin="2" MaxHeight="20" MaxWidth="20" VerticalAlignment="Center"/>
                <TextBlock Text="{Binding Text}" Margin="2" VerticalAlignment="Center"/>
            </StackPanel>
        </HierarchicalDataTemplate>
        <DataTemplate DataType="{x:Type relationshipManager:Activity}">
            <StackPanel Orientation="Horizontal">
                <Image Source="{Binding Path=Image, Converter={StaticResource UriStringToImageConverter}}" 
                       ToolTip="{Binding Text}" Margin="2" MaxHeight="20" MaxWidth="20" VerticalAlignment="Center"/>
                <TextBlock Text="{Binding Text}" Margin="2" VerticalAlignment="Center"/>
            </StackPanel>
        </DataTemplate>
    </ft:XamlFilterTree.Resources>
</ft:XamlFilterTree>
```

## Messaging

#### MessagePanel

#### ShowMessage

#### ShowException
