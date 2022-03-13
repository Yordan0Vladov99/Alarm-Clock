using ClockLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlarmClockApp
{
    public partial class MainWindow : Window
    {
        private (int, int, int) startTime;
        private (int, int, int) currentTime;
        private Random rand;
        private double ringAfter;

        public MainWindow()
        {
            rand = new Random();
            ringAfter = 0.1;
            InitializeComponent();
        }

        private void ClockStarted(object sender,EventArgs e)
        {
            ClockTickArgs a = e as ClockTickArgs;
            startTime = a.ClockTick;
            ringAfter = double.Parse(beepAfter.Text);
            logData.Text = String.Format("Start time: {0}:{1}:{2}", startTime.Item1, startTime.Item2, startTime.Item3);
        }

        private void TimeUpdated(object sender,EventArgs e)
        {
            ClockTickArgs a = e as ClockTickArgs;
            currentTime = a.ClockTick;
            ringAfter = double.Parse(beepAfter.Text);
            if (currentTime.Item3 % 2 == 0)
            {
                int randInt = 10 + rand.Next(41);
                stats.Text += randInt + " ";
            }
            int difference = (startTime.Item1 * 3600 + startTime.Item2 * 60 + startTime.Item3) - (currentTime.Item1 * 3600 + currentTime.Item2 * 60 + currentTime.Item3);
            if((double)difference/60 > ringAfter)
            {
                SystemSounds.Beep.Play();
            }
        }

        private void FindNumbers(object sender, RoutedEventArgs e)
        {
            string numbersStr = stats.Text;

            string[] numbersArr = numbersStr.Split();
            List<int> numbers = new List<int>();

            for (int i = 0; i < numbersArr.Length - 1; i++)
            {
                numbers.Add(int.Parse(numbersArr[i]));
            }

            var numericRange =
                from number in numbers
                group number by number into rangeGroup
                orderby rangeGroup.Key
                select rangeGroup;

            string result="";
            string groups = "\nDistinct numbers ";
            foreach (var rangeGroup in numericRange)
            {
                groups += rangeGroup.Key + " ";
                int count = rangeGroup.Count();

                result += String.Format("Number:{0} Found {1} times\n", rangeGroup.Key,count);

            }

            logData.Text += groups + "\nFrequency\n" + result;

        }

        
    }
}
