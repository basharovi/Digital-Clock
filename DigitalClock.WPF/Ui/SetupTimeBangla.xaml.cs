using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DigitalClock.WPF.Manager;

namespace DigitalClock.WPF.Ui
{
    /// <summary>
    /// Interaction logic for SetupTimeBangla.xaml
    /// </summary>
    public partial class SetupTimeBangla
    {
        private readonly ScheduleManager _scheduleManager;

        public SetupTimeBangla()
        {
            InitializeComponent();
            _scheduleManager = new ScheduleManager();

            BindUi();
        }

        private void BindUi()
        {
            FajrTimePicker.Text = _scheduleManager.Get("Fajr");
            DurhTimePicker.Text = _scheduleManager.Get("Duhr");
            AsrTimePicker.Text = _scheduleManager.Get("Asr");
            MagribTimePicker.Text = _scheduleManager.Get("Magrib");
            IshaTimePicker.Text = _scheduleManager.Get("Isha");
            JummaTimePicker.Text = _scheduleManager.Get("Jumma");

            NoticeTextBox.Text = _scheduleManager.Get("NoticeBangla");

            if (_scheduleManager.Get("BgColor").Contains("Black"))
            {
                RadioBlack.IsChecked = true;
            }
            else
            {
                RadioLight.IsChecked = true;
            }

        }

        private void TimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var model = new Dictionary<string, string>
                {
                    { "Fajr", FajrTimePicker.Text },
                    { "Duhr", DurhTimePicker.Text },
                    { "Asr", AsrTimePicker.Text },
                    { "Magrib", MagribTimePicker.Text },
                    { "Isha", IshaTimePicker.Text },
                    { "Jumma", JummaTimePicker.Text },

                    { "NoticeBangla", NoticeTextBox.Text },
                    { "BgColor", RadioBlack.IsChecked == true ? "Black" : string.Empty }
                };

                _scheduleManager.Update( model);

                MessageBox.Show("Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var dashboard = new Dashboard();

            dashboard.Show();
            Hide();
        }
    }
}
