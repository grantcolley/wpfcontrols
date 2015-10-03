namespace DevelopmentInProgress.WPFControls.FilterTree
{
    public interface IFilterTreeItem
    {
        string Text { get; set; }
        bool IsVisible { get; set; }
        void Filter(string filterText);
    }
}
