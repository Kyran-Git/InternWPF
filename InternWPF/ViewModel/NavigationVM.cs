using Page_Navigation_App.Utilities;
using System.Windows.Input;

namespace InternWPF.ViewModel
{
    class NavigationVM : Utilities.VMBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand JournalsCommand { get; set; }
        public ICommand EntriesCommand { get; set; }
        public ICommand SettingsCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Journals(object obj) => CurrentView = new JournalsVM();
        private void Entries(object obj) => CurrentView = new EntriesVM();
        private void Settings(object obj) => CurrentView = new SettingVM();


        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            JournalsCommand = new RelayCommand(Journals);
            EntriesCommand = new RelayCommand(Entries);
            SettingsCommand = new RelayCommand(Settings);

            CurrentView = new HomeVM();
        }

    }
}
