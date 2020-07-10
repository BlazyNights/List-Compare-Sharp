using System.Windows;

namespace ListCompareSharp
{
    /// <summary>
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        public InputWindow()
        {
            InitializeComponent();
            Title = $"{Application.ResourceAssembly.GetName().Name} v{Application.ResourceAssembly.GetName().Version}";
        }

        private void ButtonCompareClick(object sender, RoutedEventArgs e)
        {
            ResultWindow resultInstance = new ResultWindow();

            if (RadioCaseMatch.IsChecked == true)
            {
                resultInstance.ListBoxA = ListBoxA.Text;
                resultInstance.ListBoxB = ListBoxB.Text;
            }
            else if (RadioCaseLower.IsChecked == true)
            {
                resultInstance.ListBoxA = ListBoxA.Text.ToLower();
                resultInstance.ListBoxB = ListBoxB.Text.ToLower();
            }
            else if (RadioCaseUpper.IsChecked == true)
            {
                resultInstance.ListBoxA = ListBoxA.Text.ToUpper();
                resultInstance.ListBoxB = ListBoxB.Text.ToUpper();
            }

            resultInstance.NameBoxA = NameBoxA.Text;
            resultInstance.NameBoxB = NameBoxB.Text;
            resultInstance.RemoveCharQuotes = CheckboxRemoveCharQuotes.IsChecked == true;
            resultInstance.RemoveEmptyLines = CheckboxRemoveEmptyLines.IsChecked == true;
            resultInstance.TrimWhitespace = CheckboxTrimWhitespace.IsChecked == true;

            //ResultInstance.CustomCharsToRemove = null
            if (CheckboxRemoveCustomChars.IsChecked == true)
            {
                resultInstance.CustomCharsToRemove = TextboxCustomChars.Text;
            }
            

            resultInstance.Show();
        }

        private void ButtonAboutClick(object sender, RoutedEventArgs e)
        {
            new AboutWindowDisplay().Show();
        }

    }
}
