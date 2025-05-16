using notionClone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace notionClone.UserControl
{
    public partial class CustomTableControl : System.Windows.Controls.UserControl
    {
        private ObservableCollection<Models.ColumnDefinition> _columns = new();

        public CustomTableControl()
        {
            InitializeComponent();
            ColumnDefinitionList.ItemsSource = _columns;
            _columns.Add(new Models.ColumnDefinition()); 
        }

        private void AddColumn_Click(object sender, RoutedEventArgs e)
        {
            _columns.Add(new Models.ColumnDefinition());
        }

        private void CreateTable_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(RowCountBox.Text, out int rowCount) || rowCount <= 0)
            {
                MessageBox.Show("Введите корректное число строк.");
                return;
            }

            if (_columns.Count == 0 || _columns.Any(c => string.IsNullOrWhiteSpace(c.Name)))
            {
                MessageBox.Show("Убедитесь, что у всех столбцов есть имя.");
                return;
            }

            var table = new DataTable();
            foreach (var column in _columns)
            {
                Type columnType = column.Type switch
                {
                    "Number" => typeof(double),
                    "Date" => typeof(DateTime),
                    "Boolean" => typeof(bool),
                    _ => typeof(string),
                };
                table.Columns.Add(column.Name, columnType);
            }

            for (int i = 0; i < rowCount; i++)
            {
                var row = table.NewRow();
                table.Rows.Add(row);
            }

            CustomDataGrid.Columns.Clear();
            foreach (var column in _columns)
            {
                DataGridColumn gridColumn;

                switch (column.Type)
                {
                    case "Number":
                        gridColumn = new DataGridTextColumn
                        {
                            Header = column.Name,
                            Binding = new Binding(column.Name)
                            {
                                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                            }
                        };
                        break;

                    case "Boolean":
                        gridColumn = new DataGridCheckBoxColumn
                        {
                            Header = column.Name,
                            Binding = new Binding(column.Name)
                        };
                        break;

                    case "Date":
                        gridColumn = new DataGridTemplateColumn
                        {
                            Header = column.Name,
                            CellTemplate = CreateDateTemplate(column.Name, false),
                            CellEditingTemplate = CreateDateTemplate(column.Name, true)
                        };
                        break;

                    default: 
                        gridColumn = new DataGridTextColumn
                        {
                            Header = column.Name,
                            Binding = new Binding(column.Name)
                            {
                                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                            }
                        };
                        break;
                }

                CustomDataGrid.Columns.Add(gridColumn);
            }

            CustomDataGrid.ItemsSource = table.DefaultView;
        }

        private DataTemplate CreateDateTemplate(string columnName, bool isEditing)
        {
            var xaml = isEditing
                ? $"<DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><DatePicker SelectedDate='{{Binding {columnName}, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}}'/></DataTemplate>"
                : $"<DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><TextBlock Text='{{Binding {columnName}, StringFormat={{}}{{0:d}}}}'/></DataTemplate>";

            return (DataTemplate)System.Windows.Markup.XamlReader.Parse(xaml);
        }
    }


}
