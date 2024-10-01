using System;
using System.ComponentModel;
using System.Windows.Input;

namespace InternWPF.ViewModel
{
    public class NavigationVM : INotifyPropertyChanged
    {
        private object _currentView;

        // Property to store the current view model
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        // Commands to switch between views
        public ICommand HomeCommand { get; }
        public ICommand JournalsCommand { get; }
        public ICommand SettingsCommand { get; }

        // Constructor to initialize commands and set default view
        public NavigationVM()
        {
            // Default view
            CurrentView = new HomeVM();

            HomeCommand = new RelayCommand(o => SwitchToHomeView());
            JournalsCommand = new RelayCommand(o => SwitchToJournalsView());
            SettingsCommand = new RelayCommand(o => SwitchToSettingsView());
        }

        // Methods to switch between views
        private void SwitchToHomeView() => CurrentView = new HomeVM();
        private void SwitchToJournalsView() => CurrentView = new JournalVM();
        private void SwitchToSettingsView() => CurrentView = new SettingVM();

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
