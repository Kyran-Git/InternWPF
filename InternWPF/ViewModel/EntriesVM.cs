using Page_Navigation_App.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace InternWPF.ViewModel
{
    public class EntriesVM : Utilities.VMBase
    {
        private DateTime? _date;
        private string _title;
        private string _activities;

        private readonly JournalsVM _journalsVM;

        public ObservableCollection<JournalEntry> SelectedJournalEntries { get; set; } = new ObservableCollection<JournalEntry>();

        // Constructor requiring JournalsVM
        public EntriesVM(JournalsVM journalsVM)
        {
            _journalsVM = journalsVM;
            _journalsVM.PropertyChanged += JournalsVM_PropertyChanged; // Subscribe to changes in JournalsVM
        }

        private void JournalsVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(JournalsVM.SelectedJournal))
            {
                SelectedJournal = _journalsVM.SelectedJournal; // Update selected journal in EntriesVM
            }
        }

        private Journal _selectedJournal;
        public Journal SelectedJournal
        {
            get => _selectedJournal;
            set
            {
                if (_selectedJournal != value)
                {
                    _selectedJournal = value;
                    OnPropertyChanged();
                    LoadEntries(); // Load entries when a journal is selected
                }
            }
        }

        public ObservableCollection<Journal> Journals => _journalsVM.Journals;

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

        private void LoadEntries()
        {
            SelectedJournalEntries.Clear();
            if (SelectedJournal != null)
            {
                foreach (var entry in SelectedJournal.Entries)
                {
                    SelectedJournalEntries.Add(entry);
                }
            }
        }
    }
}
