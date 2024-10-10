using System.Collections.ObjectModel;

namespace InternWPF.Model
{
    public class JournalModel
    {
        public string Name { get; set; }
        public ObservableCollection<Entry> Entries { get; set; }
    }
}
