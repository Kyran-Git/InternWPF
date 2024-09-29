using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternWPF.ViewModel
{
    class MainViewModel : Utilities.VMBase
    {
        public JournalsVM JournalsVM { get; set; }
        public EntriesVM EntriesVM { get; set; }

        public MainViewModel()
        {
            JournalsVM = new JournalsVM();
            EntriesVM = new EntriesVM();

            // Listen to changes in selected journal and bind entries
            JournalsVM.PropertyChanged += JournalsVM_PropertyChanged;
        }

        private void JournalsVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(JournalsVM.SelectedJournal))
            {
                // Update EntriesVM when a new journal is selected
                EntriesVM.SelectedJournal = JournalsVM.SelectedJournal;
                EntriesVM.SelectedJournalEntries = JournalsVM.SelectedJournalEntries;
            }
        }
    }
}
