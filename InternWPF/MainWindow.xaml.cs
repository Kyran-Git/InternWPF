using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace InternWPF
{
    public partial class MainWindow : Window
    {
        // List to store journal entries
        private List<JournalEntry> journalEntries;

        public MainWindow()
        {
            InitializeComponent();
            journalEntries = new List<JournalEntry>();
        }

        // Event handler for the submit button
        private void sbmt_Click(object sender, RoutedEventArgs e)
        {
            // Create a new journal entry
            var newEntry = new JournalEntry
            {
                dateTxt = dateTxt.SelectedDate.HasValue ? dateTxt.SelectedDate.Value.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd"),
                titleTxt = titleTxt.Text
            };

            // Add the new entry to the list and sort it by date
            journalEntries.Add(newEntry);
            journalEntries = journalEntries.OrderBy(entry => entry.dateTxt).ToList();

            // Update the ListView
            JournalListView.ItemsSource = null;
            JournalListView.ItemsSource = journalEntries;

            // Clear the inputs after submission
            dateTxt.SelectedDate = null;
            titleTxt.Text = string.Empty;
            actTxt.Text = string.Empty;
        }
    }

    // Class to represent a journal entry
    public class JournalEntry
    {
        public string dateTxt { get; set; }
        public string titleTxt { get; set; }
    }
}
