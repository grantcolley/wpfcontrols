using System.ComponentModel;

namespace DevelopmentInProgress.WPFControls.Test
{
    public class NotifyChange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var propertyChangedHandler = PropertyChanged;

            if (propertyChangedHandler != null)
            {
                propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
