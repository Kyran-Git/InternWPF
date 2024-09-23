using System;
using System.Collections.Generic;

namespace InternWPF.Model
{
    // User model to store user details
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }

    // JournalEntry model to store journal entry details
    public class JournalEntry
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Activity { get; set; }
    }

    // PageModel to hold the data related to users and their journal entries
    public class PageModel
    {
        public int UserCount { get; set; }

        public List<User> Users { get; set; }

        public List<JournalEntry> JournalEntries { get; set; }

        public PageModel()
        {
            Users = new List<User>();
            JournalEntries = new List<JournalEntry>();
        }

        public void AddUser(User user)
        {
            Users.Add(user);
            UserCount = Users.Count;
        }
        
        public void AddJournalEntry(JournalEntry entry)
        {
            JournalEntries.Add(entry);
        }
    }
}
