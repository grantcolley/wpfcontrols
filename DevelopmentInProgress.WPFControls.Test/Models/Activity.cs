namespace DevelopmentInProgress.WPFControls.Test.Models
{
    public class Activity : NotifyChange
    {
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
    }
}
