using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSignals.Console
{
    public class RedLightState : LightState
    {
        private int timer;
        public RedLightState(int timer)
        {
            this.timer = timer;
        }

        public int moveCars(int carsCount)
        {
            if (timer == 0)
            {
                timer = 1;
                return carsCount;
            }
            else
            {
                return ++carsCount;
            }
        }

        public LightState changeSignal()
        {
            return new GreenLightState(Constants.SIGNAL_RESET);
        }
    }
}
