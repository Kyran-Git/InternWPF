using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InternWPF.View
{
    public partial class Journals : UserControl
    {
        public Journals()
        {
            InitializeComponent();

            // Early examples
            journalList.Items.Add("Travel Journal");
            journalList.Items.Add("Work Journal");
            journalList.Items.Add("Personal Diary");
        }

        // Event handler for Create button
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string newJournal = newJournalTxt.Text;

            if (string.IsNullOrWhiteSpace(newJournal))
            {
                MessageBox.Show("Please enter a journal name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                // Logic to add a new journal (placeholder)
                journalList.Items.Add(newJournal);
                newJournalTxt.Clear();

                MessageBox.Show($"Journal '{newJournal}' created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
