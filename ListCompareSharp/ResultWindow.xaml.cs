using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ListCompareSharp
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public string NameBoxA;
        public string NameBoxB;
        public string ListBoxA;
        public string ListBoxB;
        public string CustomCharsToRemove;

        public bool RemoveCharQuotes;
        public bool RemoveEmptyLines;
        public bool TrimWhitespace;

        public ResultWindow()
        {
            InitializeComponent();
        }

		private void ButtonCopyListAClick(object sender, RoutedEventArgs e) => Clipboard.SetText(TextBoxListA.Text);

		private void ButtonCopyOnlyAClick(object sender, RoutedEventArgs e) => Clipboard.SetText(TextBoxOnlyA.Text);

		private void ButtonCopyAOrBClick(object sender, RoutedEventArgs e) => Clipboard.SetText(TextBoxAOrB.Text);

		private void ButtonCopyListBClick(object sender, RoutedEventArgs e) => Clipboard.SetText(TextBoxListB.Text);

		private void ButtonCopyOnlyBClick(object sender, RoutedEventArgs e) => Clipboard.SetText(TextBoxOnlyB.Text);

		private void ButtonCopyAAndBClick(object sender, RoutedEventArgs e) => Clipboard.SetText(TextBoxAAndB.Text);

		private void ResultWindowName_Loaded(object sender, RoutedEventArgs e)
        {
            // remove quotes, if checked
            if (RemoveCharQuotes)
            {
                ListBoxA = ListBoxA.Replace("\'", "").Replace("\"", "");
                ListBoxB = ListBoxB.Replace("\'", "").Replace("\"", "");
            }

            // remove custom chars
            if (CustomCharsToRemove != null)
            {
                foreach (var item in CustomCharsToRemove)
                {
                    ListBoxA = ListBoxA.Replace(item.ToString(), "");
                    ListBoxB = ListBoxB.Replace(item.ToString(), "");
                }
            }

            // set labels
            LabelA.Content = NameBoxA;
            LabelB.Content = NameBoxB;
            LabelOnlyA.Content = "Only " + NameBoxA;
            LabelOnlyB.Content = "Only " + NameBoxB;
            LabelAOrB.Content = NameBoxA + " OR " + NameBoxB;
            LabelAAndB.Content = NameBoxA + " AND " + NameBoxB;

            // make HashSet out of lists
            var hashSetA = new HashSet<string>();
            var hashSetB = new HashSet<string>();
			
			AddListToHashSet(ListBoxA, hashSetA, TrimWhitespace);
            AddListToHashSet(ListBoxB, hashSetB, TrimWhitespace);

            //Restate lists
            TextBoxListA.Text = string.Join("\n", hashSetA);
            TextBoxListB.Text = string.Join("\n", hashSetB);

            LabelCountRestateA.Content = hashSetA.Count;
            LabelCountRestateB.Content = hashSetB.Count;

            //Only lists
            TextBoxOnlyA.Text = string.Join("\n", hashSetA.Except(hashSetB));
            TextBoxOnlyB.Text = string.Join("\n", hashSetB.Except(hashSetA));

            LabelCountOnlyA.Content = hashSetA.Except(hashSetB).Count();
            LabelCountOnlyB.Content = hashSetB.Except(hashSetA).Count();

            //And list
            TextBoxAAndB.Text = string.Join("\n", hashSetA.Intersect(hashSetB));

            LabelCountAAndB.Content = hashSetA.Intersect(hashSetB).Count();

            //Or list
            TextBoxAOrB.Text = string.Join("\n", hashSetA.Union(hashSetB));

            LabelCountAOrB.Content = hashSetA.Union(hashSetB).Count();
        }

        private void ResultWindowName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

		// remove white space, if check
		// trim, if checked
		public void AddListToHashSet(string list, HashSet<string> set, bool trim)
		{
			if (trim)
			{
				set.UnionWith(from l in list.SplitLines() where !string.IsNullOrWhiteSpace(l) || !RemoveEmptyLines select l.Trim());
			}
			else
			{
				set.UnionWith(from l in list.SplitLines() where !string.IsNullOrWhiteSpace(l) || !RemoveEmptyLines select l);
			}
		}
	}

}
