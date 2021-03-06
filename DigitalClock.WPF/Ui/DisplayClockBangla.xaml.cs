﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using DigitalClock.WPF.Manager;

namespace DigitalClock.WPF.Ui
{
    /// <summary>
    /// Interaction logic for DisplayClockBangla.xaml
    /// </summary>
    public partial class DisplayClockBangla
    {
        private readonly ScheduleManager _scheduleManager;

        public DisplayClockBangla()
        {
            InitializeComponent();
            _scheduleManager = new ScheduleManager();

            InitializeClock();
            BindPrayerTimes();
            BindBackgroundColor();
        }

        private void InitializeClock()
        {
            try
            {
                var dt = new DispatcherTimer
                {
                    Interval = TimeSpan.FromSeconds(1)
                };

                dt.Tick += Dt_Tick;

                dt.Start();

                var timerText = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(35)
                };

                timerText.Tick += TimerText_Tick;

                timerText.Start();

                DisplayDateBox.Content = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                DisplayNoticeBox.Content = _scheduleManager.Get("NoticeBangla");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void TimerText_Tick(object sender, EventArgs e)
        {
            var currentMargin = DisplayNoticeBox.Margin;

            try
            {
                if (currentMargin.Left > Width)
                {
                    currentMargin.Left = -1 * DisplayNoticeBox.Width;
                    currentMargin.Right = Width;
                }
                else
                {
                    currentMargin.Left += 5;
                    currentMargin.Right -= 5;
                }

                DisplayNoticeBox.Margin = currentMargin;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            DisplayClockBox.Content = BindAmPm(DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private void BindPrayerTimes()
        {
            FajrTextBox.Content = BindAmPm(_scheduleManager.Get("Fajr"));
            DuhrTextBox.Content = BindAmPm(_scheduleManager.Get("Duhr"));
            AsrTextBox.Content = BindAmPm(_scheduleManager.Get("Asr"));
            MagribTextBox.Content = BindAmPm(_scheduleManager.Get("Magrib"));
            IchaTextBox.Content = BindAmPm(_scheduleManager.Get("Isha"));
            JummaTextBox.Content = BindAmPm(_scheduleManager.Get("Jumma"));
        }

        private void BindColor(dynamic color)
        {
            DisplayDateBox.Foreground = color;
            DisplayClockBox.Foreground = color;

            if (DisplayNoticeBox != null) DisplayNoticeBox.Foreground = color;

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

        private void BindBackgroundColor()
        {
            var bgColor = _scheduleManager.Get("BgColor");

            if (!bgColor.Contains("Black"))
                return;

            GridView.Background = Brushes.Black;
            BindColor(Brushes.White);
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == System.Windows.Input.Key.Escape)
                    Application.Current.Shutdown(0);
                //e.Handled = true;

                if (e.Key != System.Windows.Input.Key.Back) return;

                var window = new Dashboard();
                window.Show();
                Hide();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private string BindAmPm(string time)
        {
            var modifiedTime = time.Replace("AM", @"পূর্বাহ্ণ");

            modifiedTime = modifiedTime.Replace("PM", @"অপরাহ্ণ");

            return modifiedTime;
        }
    }
}
