using System.Windows.Controls;
using System.Windows.Input;

namespace DevelopmentInProgress.WPFControls.NavigationPanel
{
    partial class NavigationPanelResources
    {
        private void ExpanderImageMouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new System.NotImplementedException();

                                    //            <!--<i:Interaction.Triggers>
                                    //    <i:EventTrigger EventName="MouseDown">
                                    //        <i:InvokeCommandAction Command="{Binding ExpanderChangedCommand, RelativeSource={RelativeSource TemplatedParent}}"
                                    //                               CommandParameter="{Binding SelectedItem, ElementName=modulesList}"/>
                                    //    </i:EventTrigger>
                                    //</i:Interaction.Triggers>-->


        }

        private void ModulesListOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                                //            <!--<i:Interaction.Triggers>
                                //    <i:EventTrigger EventName="SelectionChanged">
                                //        <i:InvokeCommandAction Command="{Binding SelectionChangedCommand, RelativeSource={RelativeSource TemplatedParent}}"
                                //                               CommandParameter="{Binding SelectedItem, ElementName=modulesList}"/>
                                //    </i:EventTrigger>
                                //</i:Interaction.Triggers>-->
        }
    }
}
