using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternWPF.Model
{
    public class Entry
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Activities { get; set; }

        public Entry(DateTime date, string title, string activities)
        {
            Date = date;
            Title = title;
            Activities = activities;
        }
    }
}
