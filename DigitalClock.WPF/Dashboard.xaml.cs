using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using DigitalClock.WPF.Manager;


namespace DigitalClock.WPF
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private readonly ScheduleManager _scheduleManager;

        public Dashboard()
        {
            InitializeComponent();
            _scheduleManager = new ScheduleManager();

            InitializeClock();
            BindPrayerTimes();
        }

        private void InitializeClock()
        {
            var dt = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            dt.Tick += Dt_Tick;

            dt.Start();

            DisplayDate.Content = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            DisplayClock.Content = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void BindPrayerTimes()
        {
            FajrTextBox.Content = _scheduleManager.GetPrayerTime("Fajr");
            DuhrTextBox.Content = _scheduleManager.GetPrayerTime("Duhr");
            AsrTextBox.Content = _scheduleManager.GetPrayerTime("Asr");
            MagribTextBox.Content = _scheduleManager.GetPrayerTime("Magrib");
            IchaTextBox.Content = _scheduleManager.GetPrayerTime("Isha");
            JummaTextBox.Content = _scheduleManager.GetPrayerTime("Jumma");
        }

        private void BindColor(dynamic color)
        {
            DisplayDate.Foreground = color;
            DisplayClock.Foreground = color;

            WhiteRadio.Foreground = color;
            BlackRadio.Foreground = color;

            FajrTextBox.Foreground = color;
            DuhrTextBox.Foreground = color;
            AsrTextBox.Foreground = color;
            MagribTextBox.Foreground = color;
            IchaTextBox.Foreground = color;
            JummaTextBox.Foreground = color;

            FajrTB.Foreground = color;
            DuhrTB.Foreground = color;
            AsrTB.Foreground = color;
            MagribTB.Foreground = color;
            IshaTB.Foreground = color;
            JummaTB.Foreground = color;
        }

        private void WhiteRadio_Checked(object sender, RoutedEventArgs e)
        {
            GridView.Background = Brushes.LightSkyBlue;
            BindColor(Brushes.Black);
        }

        private void BlackRadio_Checked(object sender, RoutedEventArgs e)
        {
            GridView.Background = Brushes.Black;
            BindColor(Brushes.White);
        }
    }
}
