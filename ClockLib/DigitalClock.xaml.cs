using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClockLib
{
    /// <summary>
    /// Interaction logic for DigitalClock.xaml
    /// </summary>
    public partial class DigitalClock : UserControl
    {
        public event EventHandler ClockStarted;
        public event EventHandler TimeUpdated;
        public DispatcherTimer timer;

        public DigitalClock()
        {
            timer = new DispatcherTimer();
            this.timer.Tick += new EventHandler(this.OnTimedEvent);
            this.timer.Interval = new TimeSpan(0, 0, 1);

            InitializeComponent();
        }

        private void OnTimedEvent(object source, EventArgs args)
        {
            DateTime now = DateTime.Now;
            int hh = now.Hour;
            int mm = now.Minute;
            int ss = now.Second;
            this.timeTxt.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", hh, mm, ss);
            TimeUpdated?.Invoke(this,
                new ClockTickArgs(timeTxt.Text));
        }

        private void StartTimer(object sender, RoutedEventArgs e)
        {
            timer.Start();
            DateTime now = DateTime.Now;
            int hh = now.Hour;
            int mm = now.Minute;
            int ss = now.Second;
            this.timeTxt.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", hh, mm, ss);
            ClockStarted?.Invoke(this,
                new ClockTickArgs(timeTxt.Text));
        }
        private void StopTimer(object sender, RoutedEventArgs e)
        {
            this.timer.Stop();
        }
        private void ResetTimer(object sender, RoutedEventArgs e)
        {
            timeTxt.Text = "";
        }
    }
}
