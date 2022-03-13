using System;
using System.Collections.Generic;
using System.Text;

namespace ClockLib
{
    public class ClockTickArgs : EventArgs
    {
        private (int,int,int) clockTick;
        public (int,int,int) ClockTick
        {
            get
            {
                return clockTick;
            }
            set
            {
                clockTick = value;
            }
        }

        public ClockTickArgs(string str)
        {
            string[] args = str.Split(':');

            clockTick = (int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]));
        }

    }
}
