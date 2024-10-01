using InternWPF.Model;
using Page_Navigation_App.Utilities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace InternWPF.ViewModel
{
    public class EntriesVM : INotifyPropertyChanged
    {
        public ObservableCollection<Journal> Journals { get; set; }

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

        private string _entryTitle;
        public string EntryTitle
        {
            get { return _entryTitle; }
            set
            {
                _entryTitle = value;
                OnPropertyChanged(nameof(EntryTitle));
            }
        }

        private string _activities;
        public string Activities
        {
            get { return _activities; }
            set
            {
                _activities = value;
                OnPropertyChanged(nameof(Activities));
            }
        }

        private DateTime _entryDate = DateTime.Now;
        public DateTime EntryDate
        {
            get { return _entryDate; }
            set
            {
                _entryDate = value;
                OnPropertyChanged(nameof(EntryDate));
            }
        }

        public ICommand AddEntryCommand { get; set; }

        public EntriesVM(ObservableCollection<Journal> journals)
        {
            Journals = journals;
            AddEntryCommand = new RelayCommand(AddEntry);
        }

        private void AddEntry()
        {
            if (SelectedJournal != null && !string.IsNullOrEmpty(EntryTitle) && !string.IsNullOrEmpty(Activities))
            {
                SelectedJournal.Entries.Add(new Entry(EntryDate, EntryTitle, Activities));
                // Reset fields after entry creation
                EntryTitle = string.Empty;
                Activities = string.Empty;
                EntryDate = DateTime.Now;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
