using InternWPF.ViewModel;
using System.Windows.Controls;

namespace InternWPF.View
{
    public partial class Journals : UserControl
    {
        public JournalsVM JournalsVM { get; private set; }

        public Journals()
        {
            InitializeComponent();
            JournalsVM = new JournalsVM();
            this.DataContext = JournalsVM;
        }
    }

}
