using notionClone.UserControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using notionClone.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace notionClone
{

    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PageModel> Pages { get; set; } = new();
        private PageModel? _selectedPage;
        private System.Windows.Controls.UserControl _selectedPageControl;
        public bool IsNote => SelectedPage?.Type == PageType.Note;


        public ICommand AddPageCommand { get; }
        public ICommand DeletePageCommand { get; }
        public ICommand ChangePageTypeCommand { get; }
        public ICommand AddTaskCommand { get; }
        public ICommand AddFolderCommand { get; }
        public ICommand RemoveTaskCommand { get; }
        public ICommand AddNotificationCommand { get; }


        public PageModel? SelectedPage
        {
            get => _selectedPage;
            set
            {
                _selectedPage = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNote));
                UpdateSelectedPageControl();
            }
        }


        private PageModel? FindFirstNotePage(ObservableCollection<PageModel> list)
        {
            foreach (var page in list)
            {
                if (page.Type == PageType.Note)
                    return page;

                var childResult = FindFirstNotePage(page.Children);
                if (childResult != null)
                    return childResult;
            }
            return null;
        }


        public System.Windows.Controls.UserControl SelectedPageControl
        {
            get => _selectedPageControl;
            set
            {
                _selectedPageControl = value;
                OnPropertyChanged();
            }
        }


       

        public MainViewModel()
        {

            AddPageCommand = new RelayCommand(_ =>
            {
                var newPage = new PageModel
                {
                    Title = "Новая страница",
                    Type = SelectedPageType
                };

                if (SelectedPage != null && SelectedPage.Type == PageType.Folder)
                    SelectedPage.Children.Add(newPage);
                else
                    Pages.Add(newPage);

                Guid? parentId = SelectedPage?.Id;

            });


            AddFolderCommand = new RelayCommand(_ =>
            {
                var newFolder = new PageModel
                {
                    Title = "Новая папка",
                    Type = PageType.Folder
                };

                if (SelectedPage != null && SelectedPage.Type == PageType.Folder)
                {
                    SelectedPage.Children.Add(newFolder);
                }
                else
                {
                    Pages.Add(newFolder);
                }

            });


            DeletePageCommand = new RelayCommand(_ => DeletePage(), _ => SelectedPage != null);
            ChangePageTypeCommand = new RelayCommand(param =>
            {
                if (SelectedPage != null && Enum.TryParse(param?.ToString(), out PageType type))
                {
                    SelectedPage.Type = type;
                    OnPropertyChanged(nameof(IsNote));
                    UpdateSelectedPageControl();
                }
            });
          ;
           
        }

        private PageType _selectedPageType = PageType.Note;
        public PageType SelectedPageType
        {
            get => _selectedPageType;
            set
            {
                _selectedPageType = value;
                OnPropertyChanged();
                UpdateSelectedPageControl();
            }
        }

        private void RemoveRecursive(ObservableCollection<PageModel> list, PageModel target)
        {
            if (list.Remove(target)) return;
            foreach (var p in list) RemoveRecursive(p.Children, target);
        }

        private void UpdateSelectedPageControl()
        {
            if (SelectedPage == null) return;

            switch (SelectedPage.Type)
            {
                case PageType.Note:
                    SelectedPageControl = new NoteControl();
                    break;

                case PageType.HabitTracker:

                    SelectedPageControl = new HabitTrackerControl();
                    break;

                case PageType.CustomTable:
                    SelectedPageControl = new CustomTableControl();
                    break;

                case PageType.ScheduleTracker:
                    SelectedPageControl = new ScheduleTrackerControl();
                    break;

                default:
                    SelectedPageControl = null;
                    break;
            }
        }



        private void DeletePage()
        {
            void RecursiveDelete(ObservableCollection<PageModel> list, PageModel target)
            {
                if (list.Remove(target)) return;
                foreach (var p in list)
                    RecursiveDelete(p.Children, target);
            }
            if (SelectedPage != null)
                RecursiveDelete(Pages, SelectedPage);
            SelectedPage = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
