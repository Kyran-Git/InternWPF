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
    public partial class Entries : UserControl
    {
        public Entries()
        {
            InitializeComponent();
        }

        // Event handler for Submit button
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            // Logic to handle the submission of the entry
            string date = dateTxt.SelectedDate.HasValue ? dateTxt.SelectedDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            string title = titleTxt.Text;
            string activity = actTxt.Text;

            if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(activity))
            {
                MessageBox.Show("Please fill in all fields before submitting.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                // Placeholder: You can add your logic to save the journal entry
                MessageBox.Show($"Journal Entry Submitted:\nDate: {date}\nTitle: {title}\nActivities: {activity}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void actTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}