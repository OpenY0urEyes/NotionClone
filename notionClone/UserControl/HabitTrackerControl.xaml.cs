using notionClone;
using notionClone.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace notionClone.UserControl
{
    public partial class HabitTrackerControl : System.Windows.Controls.UserControl
    {

        public HabitItem? Habit { get; private set; }
        public HabitTrackerControl()
        {
            InitializeComponent();
            this.Loaded += HabitTrackerControl_Loaded;
            this.SizeChanged += HabitTrackerControl_SizeChanged;
        }

        private void HabitTrackerControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateColumns();
        }

        private void HabitTrackerControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateColumns();
        }

        private void UpdateColumns()
        {
            var viewModel = this.DataContext as HabitTrackerViewModel;
            if (viewModel != null)
            {
                double width = this.ActualWidth;

                if (width < 700)
                    viewModel.Columns = 3;
                else if (width < 900)
                    viewModel.Columns = 4;
                else if (width < 1100)
                    viewModel.Columns = 5;
                else if (width < 1400)
                    viewModel.Columns = 6;
                else
                    viewModel.Columns = 7;
            }
        }

       


    }
}
