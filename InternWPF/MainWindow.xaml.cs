using InternWPF.View;
using InternWPF.ViewModel;
using System.Windows;
using System.Windows.Media.Animation;

namespace InternWPF
{
    public partial class MainWindow : Window
    {
        private JournalsVM journalsVM;

        public MainWindow()
        {
            InitializeComponent();

            JournalsVM journalsVM = new JournalsVM();
            Journals journalsView = new Journals { DataContext = journalsVM };
            Entries entriesView = new Entries(journalsVM);

        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SidebarToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Storyboard expandStoryboard = (Storyboard)FindResource("ExpandSidebarStoryboard");
            expandStoryboard.Begin();
        }

        private void SidebarToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Storyboard collapseStoryboard = (Storyboard)FindResource("CollapseSidebarStoryboard");
            collapseStoryboard.Begin();
        }
    }
}
