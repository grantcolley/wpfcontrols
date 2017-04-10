using System.Windows;

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
        }

        private void NavigationListItem_OnItemClicked(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
