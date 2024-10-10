using InternWPF.ViewModel;
using System.Windows;

namespace InternWPF.View
{
    /// <summary>
    /// Interaction logic for JournalPopup.xaml
    /// </summary>
    public partial class JournalPopup : Window
    {
        public JournalPopup()
        {
            InitializeComponent();
            this.DataContext = new JournalVM();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // This closes the popup window
        }

    }

}
