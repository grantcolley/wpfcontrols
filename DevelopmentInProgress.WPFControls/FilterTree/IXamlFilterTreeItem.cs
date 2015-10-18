namespace DevelopmentInProgress.WPFControls.FilterTree
{
    /// <summary>
    /// An interface that can be optionally implemented by items in the
    /// hierarchical items source. Implementing the <see cref="IXamlFilterTreeItem"/>
    /// ensures items comply with the members expected by the <see cref="FilterTree"/>
    /// when filtering the hierarchical list.
    /// <see cref="IXamlFilterTreeItem"/> is optional because the <see cref="FilterTree"/>
    /// will attempt to find the expected members using reflection rather than the
    /// interface.
    /// </summary>
    public interface IXamlFilterTreeItem
    {
        /// <summary>
        ///  Gets or sets the display text.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item
        /// has been filtered out (false) or in (true).
        /// </summary>
        bool IsVisible { get; set; }
    }
}