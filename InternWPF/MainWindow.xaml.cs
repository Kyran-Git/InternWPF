using System.Windows;
using System.Windows.Media.Animation;

namespace InternWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
