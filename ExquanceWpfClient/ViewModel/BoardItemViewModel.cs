
namespace ExquanceWpfClient.ViewModel
{
    public class BoardItemViewModel : ViewModelBase
    {
        #region private

        private string _title;

        #endregion

        public int[] Position { get; }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
        
                OnPropertyChanged(nameof(Title));
            }
        }

        public BoardItemViewModel(int[] position, string title)
        {
             Position = position;
             Title=title;
        }
    }
}