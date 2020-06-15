using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DigitalClock.WPF.Manager;

namespace DigitalClock.WPF.Ui
{
    /// <summary>
    /// Interaction logic for SetupTime.xaml
    /// </summary>
    public partial class SetupTime
    {
        private readonly ScheduleManager _scheduleManager;
        private const string NoticeFileName = "Notice";

        private enum Prayers
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
            NoticeTextBox.Text = _scheduleManager.Get(NoticeFileName);
        }

        private void TimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var prayerName = ComboBox.Text;
                var time = TimePicker.Text;

                _scheduleManager.Update(time, prayerName);

                var text = NoticeTextBox.Text;
                _scheduleManager.Update(text, NoticeFileName);

                MessageBox.Show("Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TimePicker.Text = _scheduleManager.Get(ComboBox.SelectedItem.ToString());
        }

        private void StartClock_Click(object sender, RoutedEventArgs e)
        {
            var window = new Dashboard();

            window.Show();
            Hide();
        }
    }
}
