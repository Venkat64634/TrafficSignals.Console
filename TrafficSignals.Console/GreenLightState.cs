using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSignals.Console
{
    public class GreenLightState : LightState
    {
        private int timer;

        public GreenLightState(int timer)
        {
            this.timer = timer;
        }

        public int moveCars(int carsCount)
        {
            this.timer++;
            if (timer >= Constants.GREEN_WAIT_TIME)
            {
                return carsCount;
            }
            else
            {
                return ++carsCount;
            }
        }

        public LightState changeSignal()
        {
            return new RedLightState(1);
        }
    }
}
