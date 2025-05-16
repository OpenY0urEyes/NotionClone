using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notionClone.Models
{
    public class PageModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = "New Page";
        public string Content { get; set; } = string.Empty;
        public ObservableCollection<PageModel> Children { get; set; } = new();
        public PageType Type { get; set; } = PageType.Note;
        public ObservableCollection<NoteModel> Note { get; set; } = new();
        public ObservableCollection<HabitItem> HabitItem { get; set; } = new();
        public ObservableCollection<Notification> Notifications { get; set; } = new();


    }
}
