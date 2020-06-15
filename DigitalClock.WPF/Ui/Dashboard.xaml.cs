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
            var window = new DisplayClock();

            window.Show();
            Hide();
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new SetupTime();

            window.Show();
            Hide();
        }
    }
}
