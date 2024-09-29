using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public ICommand UsersCommand { get; set; }
        public ICommand SettingsCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Journals(object obj) => CurrentView = new JournalsVM();
        private void Entries(object obj) => CurrentView = new EntriesVM();
        private void Users(object obj) => CurrentView = new UsersVM();
        private void Settings(object obj) => CurrentView = new SettingVM();

        private MainViewModel _mainViewModel;


        public NavigationVM()
        {
            _mainViewModel = new MainViewModel();

            HomeCommand = new RelayCommand(Home);
            JournalsCommand = new RelayCommand(Journals);
            EntriesCommand = new RelayCommand(Entries);
            UsersCommand = new RelayCommand(Users);
            SettingsCommand = new RelayCommand(Settings);

            CurrentView = new HomeVM();
        }

    }
}
