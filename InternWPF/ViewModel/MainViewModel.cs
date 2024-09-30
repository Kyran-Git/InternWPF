using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace InternWPF.ViewModel
{
    class MainViewModel : Utilities.VMBase
    {
        public JournalsVM JournalsVM { get; set; }
        public EntriesVM EntriesVM { get; set; }

        public MainViewModel()
        {
            JournalsVM = new JournalsVM();
            EntriesVM = new EntriesVM(JournalsVM);

            // Listen to changes in selected journal and bind entries
            JournalsVM.PropertyChanged += JournalsVM_PropertyChanged;
        }

        private void JournalsVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(JournalsVM.SelectedJournal))
            {
                // Check if the selected journal is not null before assigning
                if (JournalsVM.SelectedJournal != null)
                {
                    EntriesVM.SelectedJournal = JournalsVM.SelectedJournal;
                    EntriesVM.SelectedJournalEntries = JournalsVM.SelectedJournalEntries;
                }
            }
        }
    }
}
