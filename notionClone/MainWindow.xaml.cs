using notionClone.Models;
using notionClone;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace notionClone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel ViewModel => (MainViewModel)DataContext;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            (DataContext as MainViewModel)!.SelectedPage = e.NewValue as PageModel;
        }




        private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var treeViewItem = sender as TreeViewItem;
            var page = treeViewItem?.DataContext as PageModel;

            if (page != null)
            {
                var textBox = new TextBox
                {
                    Text = page.Title,
                    Margin = new Thickness(5)
                };

                textBox.LostFocus += (s, args) => SavePageTitle(page, textBox, treeViewItem);
                textBox.KeyDown += (s, args) =>
                {
                    if (args.Key == Key.Enter)
                    {
                        SavePageTitle(page, textBox, treeViewItem);
                    }
                };

                treeViewItem.Header = textBox;
                textBox.Focus();
            }
        }

        private void SavePageTitle(PageModel page, TextBox textBox, TreeViewItem treeViewItem)
        {
            page.Title = textBox.Text;
            treeViewItem.Header = new TextBlock { Text = page.Title };
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is ComboBoxItem item && item.Tag is PageType type)
            {
                ViewModel.SelectedPageType = type;
            }
        }

    }
}