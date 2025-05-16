using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notionClone
{
    public class HabitDayRecord : INotifyPropertyChanged
    {
        public DateTime Date { get; set; }

        private Dictionary<string, bool> _habitStatus = new();
        public Dictionary<string, bool> HabitStatus
        {
            get => _habitStatus;
            set { _habitStatus = value; OnPropertyChanged(nameof(HabitStatus)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string? name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
