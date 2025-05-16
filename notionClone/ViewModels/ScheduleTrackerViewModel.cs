using notionClone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace notionClone
{
    public class ScheduleTrackerViewModel : INotifyPropertyChanged
    {
        public DateTime SelectedDate { get; set; } = DateTime.Today;

        public TimeSpan StartTime { get; set; } = TimeSpan.FromHours(9);
        public TimeSpan EndTime { get; set; } = TimeSpan.FromHours(10);

        public ObservableCollection<TimeSpan> AvailableTimes { get; } = new();

        public ObservableCollection<ScheduleItem> Items { get; } = new();

        public ICommand AddItemCommand { get; }

        public ScheduleTrackerViewModel()
        {
            for (int h = 0; h < 24; h++)
                for (int m = 0; m < 60; m += 30)
                    AvailableTimes.Add(new TimeSpan(h, m, 0));

            AddItemCommand = new RelayCommand(_ =>
            {
                Items.Add(new ScheduleItem
                {
                    Date = SelectedDate,
                    StartTime = StartTime,
                    EndTime = EndTime,
                    Description = "Новое событие",
                    IsDone = false
                });
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }

}
