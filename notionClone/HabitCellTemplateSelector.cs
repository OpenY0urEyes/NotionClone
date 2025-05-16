using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace notionClone
{
    public class HabitCellTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Template { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
            => Template;
    }
}
