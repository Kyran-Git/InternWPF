using InternWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternWPF.ViewModel
{
    public class MainVM
    {
        public ObservableCollection<Journal> Journals { get; set; }

        public MainVM()
        {
            Journals = new ObservableCollection<Journal>();
            // Initialize the Journals collection here.
        }
    }

}
