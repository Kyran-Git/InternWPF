using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternWPF.Model
{
    public class Journal
    {
        public string Name { get; set; }
        public ObservableCollection<Entry> Entries { get; set; }

        public Journal(string name)
        {
            Name = name;
            Entries = new ObservableCollection<Entry>();
        }
    }
}
