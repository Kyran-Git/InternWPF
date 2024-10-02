using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using InternWPF.Model;

namespace InternWPF.ViewModel
{
    public class JournalVM : INotifyPropertyChanged
    {
        public ObservableCollection<Journal> Journals { get; set; }

        // Commands
        public ICommand CreateJournalCommand { get; set; }
        public ICommand AddEntryCommand { get; set; }

        // Selected journal
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

        // New journal name
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

        // Properties for new entry
        public DateTime NewEntryDate { get; set; }
        public string NewEntryTitle { get; set; }
        public string NewEntryActivities { get; set; }

        public JournalVM()
        {
            Journals = new ObservableCollection<Journal>();
            CreateJournalCommand = new RelayCommand(CreateNewJournal);
            AddEntryCommand = new RelayCommand(AddNewEntry);

            // Initialize NewEntryDate to today's date
            NewEntryDate = DateTime.Now;
        }


        // Create new journal
        private void CreateNewJournal(object parameter)
        {
            if (!string.IsNullOrEmpty(NewJournalName))
            {
                var newJournal = new Journal { Name = NewJournalName, Entries = new ObservableCollection<Entry>() };
                Journals.Add(newJournal);
                SelectedJournal = newJournal; // Automatically select the new journal
                NewJournalName = string.Empty; // Clear the input field after creation
            }
        }

        // Add new entry to the selected journal
        private void AddNewEntry(object parameter)
        {
            if (SelectedJournal != null && !string.IsNullOrEmpty(NewEntryTitle) && !string.IsNullOrEmpty(NewEntryActivities))
            {
                var newEntry = new Entry
                {
                    Date = NewEntryDate,
                    Title = NewEntryTitle,
                    Activities = NewEntryActivities
                };
                SelectedJournal.Entries.Add(newEntry);

                // Clear entry fields after adding
                NewEntryDate = DateTime.Now;
                NewEntryTitle = string.Empty;
                NewEntryActivities = string.Empty;

                // Notify the UI of changes
                OnPropertyChanged(nameof(NewEntryDate));
                OnPropertyChanged(nameof(NewEntryTitle));
                OnPropertyChanged(nameof(NewEntryActivities));
            }
        }

        // Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
