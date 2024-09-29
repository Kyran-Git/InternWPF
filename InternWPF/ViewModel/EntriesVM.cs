using Page_Navigation_App.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace InternWPF.ViewModel
{
    class EntriesVM : Utilities.VMBase
    {
        private DateTime? _date;
        private string _title;
        private string _activities;

        public Journal SelectedJournal { get; set; }
        public ObservableCollection<JournalEntry> SelectedJournalEntries { get; set; }


        public DateTime? Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Activities
        {
            get => _activities;
            set
            {
                _activities = value;
                OnPropertyChanged(nameof(Activities));
            }
        }

        public ICommand SubmitCommand { get; }

        public EntriesVM()
        {
            SubmitCommand = new RelayCommand(OnSubmit, CanSubmit);
        }

        private bool CanSubmit(object parameter)
        {
            // Only allow submit if all fields are filled in
            return Date.HasValue && !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Activities);
        }

        private void OnSubmit(object parameter)
        {
            if (SelectedJournal != null)
            {
                var newEntry = new JournalEntry
                {
                    EntryDate = Date?.ToString("d"),
                    Title = Title,
                    Activities = Activities
                };

                SelectedJournal.Entries.Add(newEntry);
                SelectedJournalEntries.Add(newEntry);

                // Clear fields after submission
                Date = null;
                Title = string.Empty;
                Activities = string.Empty;
            }
        }
    }
}
