using Page_Navigation_App.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InternWPF.ViewModel
{

    class JournalsVM : Utilities.VMBase
    {
        public JournalsVM()
        {
            Journals = new ObservableCollection<Journal>(); 
            SelectedJournalEntries = new ObservableCollection<JournalEntry>();  
            CreateJournalCommand = new RelayCommand(OnCreateJournal, CanCreateJournal);
        }

        private string _newJournalName;
        private Journal _selectedJournal;

        public ObservableCollection<Journal> Journals { get; set; }
        public ObservableCollection<JournalEntry> SelectedJournalEntries { get; set; }

        public string NewJournalName
        {
            get => _newJournalName;
            set
            {
                _newJournalName = value;
                OnPropertyChanged(nameof(NewJournalName));
            }
        }

        public Journal SelectedJournal
        {
            get => _selectedJournal;
            set
            {
                _selectedJournal = value;
                OnPropertyChanged(nameof(SelectedJournal));
                LoadEntries(); // Load entries when a journal is selected
            }
        }

        public ICommand CreateJournalCommand { get; }

       
        private bool CanCreateJournal(object parameter)
        {
            return !string.IsNullOrWhiteSpace(NewJournalName);
        }

        private void OnCreateJournal(object parameter)
        {
            if (!Journals.Any(j => j.JournalName == NewJournalName))
            {
                Journals.Add(new Journal { JournalName = NewJournalName, Entries = new ObservableCollection<JournalEntry>() });
                NewJournalName = string.Empty;  // Clear after creation
            }
        }

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

    public class Journal
    {
        public string JournalName { get; set; }
        public ObservableCollection<JournalEntry> Entries { get; set; }
    }

    public class JournalEntry
    {
        public string EntryDate { get; set; }
        public string Title { get; set; }
        public string Activities { get; set; }
    }
}