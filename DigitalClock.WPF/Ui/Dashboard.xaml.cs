using System.Windows;

namespace DigitalClock.WPF.Ui
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (RadioEnglish.IsChecked == true)
            {
                var window = new DisplayClock();
                window.Show();
            }
            else
            {
                var window = new DisplayClockBangla();
                window.Show();
            }
            
            Hide();
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            if (RadioEnglish.IsChecked == true)
            {
                var window = new SetupTime();
                window.Show();
            }
            else
            {
                var window = new SetupTimeBangla();
                window.Show();
            }

            Hide();
        }
    }
}
