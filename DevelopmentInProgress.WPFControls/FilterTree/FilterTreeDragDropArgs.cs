namespace DevelopmentInProgress.WPFControls.FilterTree
{
    public class FilterTreeDragDropArgs
    {
        public FilterTreeDragDropArgs(object dragItem, object dropTarget)
        {
            DragItem = dragItem;
            DropTarget = dropTarget;
        }

        public object DragItem { get; private set; }
        public object DropTarget { get; private set; }
    }
}
