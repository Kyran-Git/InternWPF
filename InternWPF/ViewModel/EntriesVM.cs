using InternWPF.Utilities;
using Page_Navigation_App.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InternWPF.ViewModel
{
    class EntriesVM : Utilities.VMBase
    {
        private DateTime? _date;
        private string _title;
        private string _activities;

        public DateTime? Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Activities
        {
            get => _activities;
            set
            {
                _activities = value;
                OnPropertyChanged(nameof(Activities));
            }
        }

        public ICommand SubmitCommand { get; }

        public EntriesVMl()
        {
            SubmitCommand = new RelayCommand(OnSubmit, CanSubmit);
        }

        private bool CanSubmit(object parameter)
        {
            // Only allow submit if all fields are filled in
            return Date.HasValue && !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Activities);
        }

        private void OnSubmit(object parameter)
        {
            // Logic to submit the journal entry (e.g., save to a database or a list)
            // Example:
            Console.WriteLine($"Submitted Entry: {Date}, {Title}, {Activities}");
        }
    }
}
