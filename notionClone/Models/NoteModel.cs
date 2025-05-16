    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Runtime.CompilerServices;

    namespace notionClone.Models
    {
        public class NoteModel : BaseModel, INotifyPropertyChanged
        {
            private Guid _pageId;
            private string _title;
            private string _content;

            public Guid PageId
            {
                get => _pageId;
                set
                {
                    if (_pageId != value)
                    {
                        _pageId = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string Title
            {
                get => _title;
                set
                {
                    if (_title != value)
                    {
                        _title = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string Content
            {
                get => _content;
                set
                {
                    if (_content != value)
                    {
                        _content = value;
                        OnPropertyChanged();
                    }
                }
            }

            public event PropertyChangedEventHandler? PropertyChanged;

            private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
