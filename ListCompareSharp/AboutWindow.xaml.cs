using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows.Navigation;

namespace ListCompareSharp
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindowDisplay : Window
    {
        public AboutWindowDisplay()
        {
            InitializeComponent();
            Title = $"{Application.ResourceAssembly.GetName().Name} v{Application.ResourceAssembly.GetName().Version} by BlazyNights";
        }

        private void HyperlinkRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void AboutWindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
