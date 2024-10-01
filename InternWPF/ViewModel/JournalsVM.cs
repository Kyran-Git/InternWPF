using InternWPF.Model;
using Page_Navigation_App.Utilities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace InternWPF.ViewModel
{
    public class JournalsVM : INotifyPropertyChanged
    {
        // ObservableCollection to hold all the journals
        public ObservableCollection<Journal> Journals { get; set; } = new ObservableCollection<Journal>();

        // Selected journal property for tracking the currently selected journal
        private Journal _selectedJournal;
        public Journal SelectedJournal
        {
            get { return _selectedJournal; }
            set
            {
                _selectedJournal = value;
                OnPropertyChanged(nameof(SelectedJournal));
            }
        }

        // Command for adding a new journal
        public ICommand AddJournalCommand { get; set; }

        // Property to hold the name of the new journal
        private string _newJournalName;
        public string NewJournalName
        {
            get { return _newJournalName; }
            set
            {
                _newJournalName = value;
                OnPropertyChanged(nameof(NewJournalName));
            }
        }

        // Constructor
        public JournalsVM()
        {
            // Initialize the command
            AddJournalCommand = new RelayCommand(AddJournal);
        }

        // Method to add a new journal
        private void AddJournal()
        {
            if (!string.IsNullOrEmpty(NewJournalName))
            {
                // Create a new journal with the name provided by the user
                var newJournal = new Journal(NewJournalName);
                Journals.Add(newJournal);
                SelectedJournal = newJournal; // Automatically select the new journal
                NewJournalName = string.Empty; // Clear the input field after adding
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
