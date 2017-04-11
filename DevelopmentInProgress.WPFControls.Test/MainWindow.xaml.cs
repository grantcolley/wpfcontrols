using System.Windows;
using DevelopmentInProgress.WPFControls.NavigationPanel;

namespace DevelopmentInProgress.WPFControls.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

            NavigationPanel = new NavigationPanel.NavigationPanel();

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
        }

        private void NavigationListItem_OnItemClicked(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
