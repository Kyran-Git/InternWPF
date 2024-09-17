using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
                titleTxt = titleTxt.Text,
                actTxt = actTxt.Text
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

            MessageBox.Show("Successfully Submitted","Congrats",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        // Event handler for ListView selection change
        private void JournalListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (JournalListView.SelectedItem is JournalEntry selectedEntry)
            {
                // Display the details of the selected journal entry in a message box
                MessageBox.Show($"Date: {selectedEntry.dateTxt}\nTitle: {selectedEntry.titleTxt}\nActivities:\n{selectedEntry.actTxt}",
                                "Journal Entry Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //Button for sorting by date
        private void date_Click(object sender, RoutedEventArgs e)
        {
            SortListView("Date");
        }

        //Button for sorting by title
        private void title_Click(object sender, RoutedEventArgs e)
        {
            SortListView("Title");
        }

        //Sorting method
        private void SortListView(string sortBy)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(JournalListView.ItemsSource);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(sortBy, ListSortDirection.Ascending));
        }

        private void actTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    // Journal entry class
    public class JournalEntry
    {
        public string dateTxt { get; set; }
        public string titleTxt { get; set; }
        public string actTxt { get; set; }
    }
}
