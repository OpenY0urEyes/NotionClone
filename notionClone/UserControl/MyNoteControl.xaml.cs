using notionClone.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class NoteControl : System.Windows.Controls.UserControl
    {

        public NoteModel? Note { get; private set; }

        public event EventHandler<NoteModel> NoteChanged;

        public NoteControl()
        {
            InitializeComponent();
        }

        private void Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Editor.Selection.IsEmpty)
            {
                FormatPopup.IsOpen = false;
                return;
            }

            var rect = Editor.Selection.Start.GetCharacterRect(LogicalDirection.Forward);

            FormatPopup.HorizontalOffset = rect.X;
            FormatPopup.VerticalOffset = rect.Y - 30; 
            FormatPopup.IsOpen = true;
        }




        protected virtual void OnNoteChanged()
        {
            NoteChanged?.Invoke(this, Note);
        }


        private void ApplyToSelection(DependencyProperty prop, object value)
        {
            var sel = Editor.Selection;
            if (!sel.IsEmpty)
                sel.ApplyPropertyValue(prop, value);
        }

        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            var sel = Editor.Selection;
            if (!sel.IsEmpty)
            {
                var currentWeight = sel.GetPropertyValue(TextElement.FontWeightProperty);
                var isBold = (currentWeight != DependencyProperty.UnsetValue) && currentWeight.Equals(FontWeights.Bold);
                ApplyToSelection(TextElement.FontWeightProperty, isBold ? FontWeights.Normal : FontWeights.Bold);
            }
        }


        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            var sel = Editor.Selection;
            if (!sel.IsEmpty)
            {
                var currentStyle = sel.GetPropertyValue(TextElement.FontStyleProperty);
                var isItalic = (currentStyle != DependencyProperty.UnsetValue) && currentStyle.Equals(FontStyles.Italic);
                ApplyToSelection(TextElement.FontStyleProperty, isItalic ? FontStyles.Normal : FontStyles.Italic);
            }
        }


        private void Underline_Click(object sender, RoutedEventArgs e)
        {
            var sel = Editor.Selection;
            if (!sel.IsEmpty)
            {
                var currentDecorations = sel.GetPropertyValue(Inline.TextDecorationsProperty);
                var isUnderlined = (currentDecorations != DependencyProperty.UnsetValue) && currentDecorations.Equals(TextDecorations.Underline);
                ApplyToSelection(Inline.TextDecorationsProperty, isUnderlined ? null : TextDecorations.Underline);
            }
        }


        private void Heading1_Click(object sender, RoutedEventArgs e)
        {
            var sel = Editor.Selection;
            if (!sel.IsEmpty)
            {
                var currentSize = sel.GetPropertyValue(TextElement.FontSizeProperty);
                var isHeading = (currentSize != DependencyProperty.UnsetValue) && (double)currentSize == 24.0;
                if (isHeading)
                {
                    ApplyToSelection(TextElement.FontSizeProperty, 12.0);
                    ApplyToSelection(TextElement.FontWeightProperty, FontWeights.Normal);
                }
                else
                {
                    ApplyToSelection(TextElement.FontSizeProperty, 24.0);
                    ApplyToSelection(TextElement.FontWeightProperty, FontWeights.Bold);
                }
            }
        }
        private void Heading2_Click(object sender, RoutedEventArgs e)
        {
            var sel = Editor.Selection;
            if (!sel.IsEmpty)
            {
                var currentSize = sel.GetPropertyValue(TextElement.FontSizeProperty);
                var isHeading = (currentSize != DependencyProperty.UnsetValue) && (double)currentSize == 18.0;
                if (isHeading)
                {
                    ApplyToSelection(TextElement.FontSizeProperty, 12.0);
                    ApplyToSelection(TextElement.FontWeightProperty, FontWeights.Normal);
                }
                else
                {
                    ApplyToSelection(TextElement.FontSizeProperty, 18.0);
                    ApplyToSelection(TextElement.FontWeightProperty, FontWeights.Bold);
                }
            }
        }


        private void BulletList_Click(object sender, RoutedEventArgs e)
            => EditingCommands.ToggleBullets.Execute(null, Editor);

        private void NumberedList_Click(object sender, RoutedEventArgs e)
            => EditingCommands.ToggleNumbering.Execute(null, Editor);
    }
}
