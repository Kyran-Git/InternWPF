using System.Collections.ObjectModel;

namespace InternWPF.Model
{
    public class Journal
    {
        public string Name { get; set; }
        public ObservableCollection<Entry> Entries { get; set; }
    }
}
