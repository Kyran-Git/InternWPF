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
    }

}
