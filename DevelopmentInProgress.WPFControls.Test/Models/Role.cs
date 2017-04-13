using System.Collections.ObjectModel;

namespace DevelopmentInProgress.WPFControls.Test.Models
{
    public class Role : NotifyChange
    {
        public Role()
        {
            Activities = new ObservableCollection<Activity>();
        }

        private string text;
        private string image;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public bool IsVisible { get; set; }

        public ObservableCollection<Activity> Activities { get; set; }
    }
}
