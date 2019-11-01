using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSignals.Console
{
    public class Constants
    {
        public const string NORTH = "N";
        public const string SOUTH = "S";
        public const string EAST = "E";
        public const string WEST = "W";
        public const int GREEN_WAIT_TIME = 2;
        public const int GREEN_MAX_TIME = 3;
        public const int RED_MAX_TIME = 1;
        public const int SIGNAL_RESET = 0;
        public const int THREAD_SLEEP_TIME = 1000;
        public const int MAX_REPEATS = 1;
    }
}
