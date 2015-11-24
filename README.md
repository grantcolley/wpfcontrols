# wpfcontrols
A suite of custom WPF controls... *still in beta*.

[![Build status](https://ci.appveyor.com/api/projects/status/6o6weumr92epubkr/branch/master?svg=true)](https://ci.appveyor.com/project/grantcolley/wpfcontrols/branch/master)

[NuGet package](https://www.nuget.org/packages/DipWpfControls/).

Example WPF window with a **NavigationPanel** docked to the left and **XamlFilterTree** filling the centre.
![Alt text](/README-images/main.PNG?raw=true "Example WPF window with a NavigationPanel and XamlFilterTree")

## NavigationPanel
The *NavigationPanel* can be docked to the side of a window, and allows you to switch between views or areas within an application.

* **NavigationPanel**
    The *NavigationPanel* contains a list of *NavigationPanelItem's*, each of which is a logical area within the application.

* **NavigationPanelItem**
    Each *NavigationPanelItem* is displayed as a tab in the navigation panel and contains a list of *NavigationList's*, which groups views within an area of an application. 

* **NavigationList**
    A *NavigationList* groups lists of views or *NavigationListItem's*, that can be navigated to.

* **NavigationListItem** - A navigable item or view, which when clicked, raises the *ItemClickedEvent* event and executes the *Command*.

The following example shows a navigation panel with two main areas within an application, *Manage Relationships* and *User Administration*. 
* The *Manage Relationships* tab groups the views for maintaining *Customers* and *Contacts*
* The *User Administration* tab groups the views for managing *Users* and their *Roles*.

![Alt text](/README-images/navigationPanel.PNG?raw=true "Navigation Panel")

#####Xaml
```C#
<navigationPanel:NavigationPanel x:Name="navigationPanel">
    <navigationPanel:NavigationPanel.NavigationPanelItems>
        <navigationPanel:NavigationPanelItem NavigationPanelItemName="Manage Relationships" ImageLocation="pack://application:,,,/RelationshipManager;component/ManageRelationships.png">
            <navigationPanel:NavigationPanelItem.NavigationList>
                <navigationPanel:NavigationList NavigationListName="Customers">
                    <navigationPanel:NavigationList.NavigationListItems>
                        <navigationPanel:NavigationListItem ItemName="Customer List" ItemClicked="CustomerListClicked" ImageLocation="pack://application:,,,/RelationshipManager;component/CustomerList.png"/>
                        <navigationPanel:NavigationListItem ItemName="Add New Customer" ItemClicked="AddNewCustomerClicked" ImageLocation="pack://application:,,,/RelationshipManager;component/AddNewCustomer.png"/>
                    </navigationPanel:NavigationList.NavigationListItems>
                </navigationPanel:NavigationList>
                <navigationPanel:NavigationList NavigationListName="Contacts">
                    <navigationPanel:NavigationList.NavigationListItems>
                        <navigationPanel:NavigationListItem ItemName="Contact List" ItemClicked="ContactListClicked" ImageLocation="pack://application:,,,/RelationshipManager;component/ContactList.png"/>
                        <navigationPanel:NavigationListItem ItemName="Add New Contact" ItemClicked="AddNewContactClicked" ImageLocation="pack://application:,,,/RelationshipManager;component/AddNewContact.png"/>
                    </navigationPanel:NavigationList.NavigationListItems>
                </navigationPanel:NavigationList>
            </navigationPanel:NavigationPanelItem.NavigationList>
        </navigationPanel:NavigationPanelItem>
        <navigationPanel:NavigationPanelItem NavigationPanelItemName="User Admininstration" ImageLocation="pack://application:,,,/RelationshipManager;component/UserAdministration.png">
            <navigationPanel:NavigationPanelItem.NavigationList>
                <navigationPanel:NavigationList NavigationListName="Users">
                    <navigationPanel:NavigationList.NavigationListItems>
                        <navigationPanel:NavigationListItem ItemName="User List" ItemClicked="UserListClicked" ImageLocation="pack://application:,,,/RelationshipManager;component/UserList.png"/>
                        <navigationPanel:NavigationListItem ItemName="Add New User" ItemClicked="AddNewUserClicked" ImageLocation="pack://application:,,,/RelationshipManager;component/AddNewUser.png"/>
                    </navigationPanel:NavigationList.NavigationListItems>
                </navigationPanel:NavigationList>
                <navigationPanel:NavigationList NavigationListName="Roles">
                    <navigationPanel:NavigationList.NavigationListItems>
                        <navigationPanel:NavigationListItem ItemName="Role List" ItemClicked="RoleListClicked" ImageLocation="pack://application:,,,/RelationshipManager;component/RoleList.png"/>
                        <navigationPanel:NavigationListItem ItemName="Add New Role" ItemClicked="AddNewRoleClicked" ImageLocation="pack://application:,,,/RelationshipManager;component/AddNewRole.png"/>
                    </navigationPanel:NavigationList.NavigationListItems>
                </navigationPanel:NavigationList>
            </navigationPanel:NavigationPanelItem.NavigationList>
        </navigationPanel:NavigationPanelItem>
    </navigationPanel:NavigationPanel.NavigationPanelItems>
</navigationPanel:NavigationPanel>
```

#####C# 
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
A filterable tree view with support for adding and removing items and drag drop operations. 

In order for an object to qualify for filtering it must have two public settable properties:
- Text (string)
- IsVisible (bool)

The example below shows a list of users, their assigned roles and the activities associated with each role. The *User*, *Role* and *Activity* objects expose public *Text* and *IsVisible* properties and can be filtered in or out of view when the user types in the filter textbox above the list.

![Alt text](/README-images/filterTree.PNG?raw=true "Filter Tree")

#####Xaml
```C#
<filterTree:XamlFilterTree Header="User List" 
                    ItemsSource="{Binding Users}" 
                    RemoveItemCommand="{Binding ItemDeletedCommand}"
                    AddItemCommand="{Binding ItemAddCommand}"
                    SelectItemCommand="{Binding ItemSelectCommand}"
                    DragDropCommand="{Binding DragDropCommand}">
    <filterTree:XamlFilterTree.Resources>
        <HierarchicalDataTemplate DataType="{x:Type relationshipManager:User}"
                                        ItemsSource="{Binding Roles}">
            <StackPanel Orientation="Horizontal">
                <Image Source="{Binding Path=Image, Converter={StaticResource UriStringToImageConverter}}" 
                                ToolTip="{Binding Text}"
                                Margin="2" MaxHeight="20" MaxWidth="20" VerticalAlignment="Center"/>
                <TextBlock Text="{Binding Text}" 
                                    Margin="2" VerticalAlignment="Center"/>
            </StackPanel>
        </HierarchicalDataTemplate>
        <HierarchicalDataTemplate DataType="{x:Type relationshipManager:Role}"
                                        ItemsSource="{Binding Activities}">
            <StackPanel Orientation="Horizontal">
                <Image Source="{Binding Path=Image, Converter={StaticResource UriStringToImageConverter}}" 
                                ToolTip="{Binding Text}"
                                Margin="2" MaxHeight="20" MaxWidth="20" VerticalAlignment="Center"/>
                <TextBlock Text="{Binding Text}" 
                                    Margin="2" VerticalAlignment="Center"/>
            </StackPanel>
        </HierarchicalDataTemplate>
        <DataTemplate DataType="{x:Type relationshipManager:Activity}">
            <StackPanel Orientation="Horizontal">
                <Image Source="{Binding Path=Image, Converter={StaticResource UriStringToImageConverter}}" 
                                ToolTip="{Binding Text}"
                                Margin="2" MaxHeight="20" MaxWidth="20" VerticalAlignment="Center"/>
                <TextBlock Text="{Binding Text}" 
                                    Margin="2" VerticalAlignment="Center"/>
            </StackPanel>
        </DataTemplate>
    </filterTree:XamlFilterTree.Resources>
</filterTree:XamlFilterTree>
```
