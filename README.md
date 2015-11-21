# wpfcontrols
A suite of custom WPF controls... *still in beta*.

[![Build status](https://ci.appveyor.com/api/projects/status/6o6weumr92epubkr/branch/master?svg=true)](https://ci.appveyor.com/project/grantcolley/wpfcontrols/branch/master)

[NuGet package](https://www.nuget.org/packages/DipWpfControls/).

## NavigationPanel
The navigation panel can be docked to the side of a window, and allows you to switch between views or areas within an application.
* **NavigationPanel** - The main navigation container for a list of *NavigationPanelItem's*.
* **NavigationPanelItem** - Displayed as tabs in the navigation panel to enable grouping of navigation lists.
* **NavigationList** - Contains a list of *NavigationListItem's*.
* **NavigationListItem** - A navigable item which raises the *ItemClickedEvent* event and executes the *Command* when clicked.

#####Xaml
```C#
<navigationPanel:NavigationPanel>
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
        <navigationPanel:NavigationPanelItem NavigationPanelItemName="User Admininstration" ImageLocation="pack://application:,,,/RelationshipManager;component/UserManagement.png">
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

## XamlFilterTree
A filterable tree view with support for adding and removing items and drag drop operations. 
