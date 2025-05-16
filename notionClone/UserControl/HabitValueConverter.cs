using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Data;
using notionClone.Models;

namespace notionClone.UserControl
{
    public class HabitValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var row = value as DataRowView;
            if (row == null) return null;

            var result = new List<HabitItem>();

            foreach (DataColumn column in row.DataView.Table.Columns)
            {
                if (column.ColumnName == "Date") continue;

                bool isChecked = row[column.ColumnName] is bool b && b;
                result.Add(new HabitItem { HabitName = column.ColumnName, IsChecked = isChecked });
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }

}

