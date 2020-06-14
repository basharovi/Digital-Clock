using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using DigitalClock.WPF.Manager;

namespace DigitalClock.WPF
{
    /// <summary>
    /// Interaction logic for SetupTime.xaml
    /// </summary>
    public partial class SetupTime : Window
    {
        private readonly ScheduleManager _scheduleManager;

        enum Prayers
        {
            Jumma,
            Fajr,
            Duhr,
            Asr,
            Magrib,
            Isha,
        }

        public SetupTime()
        {
            InitializeComponent();
            _scheduleManager = new ScheduleManager();

            BindUi();
        }

        private void BindUi()
        {
            ComboBox.ItemsSource = Enum.GetValues(typeof(Prayers)).Cast<Prayers>();
        }

        private void TimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string prayerName = ComboBox.Text;
                var time = TimePicker.Text;

                _scheduleManager.UpdatePrayerTime(time, prayerName);

                MessageBox.Show("Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TimePicker.Text = _scheduleManager.GetPrayerTime(ComboBox.SelectedItem.ToString());
        }

        private void StartClock_Click(object sender, RoutedEventArgs e)
        {
            var window = new Dashboard();

            window.Show();
            Hide();
        }
    }
}
