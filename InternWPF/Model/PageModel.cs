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
        // Tracks the number of users
        public int UserCount { get; set; }

        // List of users in the system
        public List<User> Users { get; set; }

        // List of journal entries for each user (could be tied to a specific user later if needed)
        public List<JournalEntry> JournalEntries { get; set; }

        // Constructor to initialize the lists
        public PageModel()
        {
            Users = new List<User>();
            JournalEntries = new List<JournalEntry>();
        }

        // Method to add a new user
        public void AddUser(User user)
        {
            Users.Add(user);
            UserCount = Users.Count;
        }

        // Method to add a journal entry
        public void AddJournalEntry(JournalEntry entry)
        {
            JournalEntries.Add(entry);
        }
    }
}
