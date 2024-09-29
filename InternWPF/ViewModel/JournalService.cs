using System.Collections.ObjectModel;

namespace InternWPF.ViewModel
{
    public class JournalService
    {
        public ObservableCollection<Journal> Journals { get; set; } = new ObservableCollection<Journal>();
        public Journal SelectedJournal { get; set; }
    }
}
