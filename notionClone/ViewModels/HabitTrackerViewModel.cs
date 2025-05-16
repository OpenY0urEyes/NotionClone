using notionClone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace notionClone
{
    public class HabitTrackerViewModel : INotifyPropertyChanged
    {
        public DateTime StartDate { get; set; } = DateTime.Today.AddDays(-7);
        public DateTime EndDate { get; set; } = DateTime.Today;

        public ObservableCollection<HabitItem> HabitNames { get; } = new();
        public ICommand AddHabitCommand { get; }
        public ICommand RemoveHabitCommand { get; }
        public ICommand GenerateCommand { get; }

        private DataView _tableView;
        public DataView TableView
        {
            get => _tableView;
            set { _tableView = value; OnPropertyChanged(); }
        }

        private int _columns = 3;
        public int Columns
        {
            get => _columns;
            set
            {
                _columns = value;
                OnPropertyChanged();
            }
        }


        public HabitTrackerViewModel()
        {
            AddHabitCommand = new RelayCommand(_ =>
            {
                var newHabit = new HabitItem { Name = "" };
                newHabit.PropertyChanged += (_, __) => RebuildTable();
                HabitNames.Add(newHabit);
            });

            RemoveHabitCommand = new RelayCommand(h =>
            {
                if (h is HabitItem habit)
                {
                    HabitNames.Remove(habit);
                    RebuildTable();
                }
            });

            GenerateCommand = new RelayCommand(_ => RebuildTable());
            RebuildTable();
        }



        private void RebuildTable()
        {
            var tbl = new DataTable();
            tbl.Columns.Add("Date", typeof(DateTime));

            foreach (var habit in HabitNames.Where(h => !string.IsNullOrWhiteSpace(h.Name)))
                tbl.Columns.Add(habit.Name, typeof(bool));


            for (var d = StartDate.Date; d <= EndDate.Date; d = d.AddDays(1))
            {
                var row = tbl.NewRow();
                row["Date"] = d;

                foreach (var habit in HabitNames.Where(h => !string.IsNullOrWhiteSpace(h.Name)))
                {
                    row[habit.Name] = false;
                   
                }

                tbl.Rows.Add(row);
            }
            TableView = tbl.DefaultView;
            OnPropertyChanged(nameof(TableView));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string p = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
    }

 


    public static class Extensions
    {
        public static bool Exists<T>(this ObservableCollection<T> col, Predicate<T> pred)
        {
            foreach (var x in col) if (pred(x)) return true;
            return false;
        }
    }

}
