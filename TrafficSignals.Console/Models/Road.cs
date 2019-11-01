using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSignals.Console.Models
{
    public class Road
    {
        private LightState lightState;

        private string direction;
        private string displayName;
        private int carsCount;

        public Road(string name, string direction, string displayName)
        {
            this.direction = direction;
            this.displayName = displayName;
            this.carsCount = 0;
        }

        public string getDirection()
        {
            return direction;
        }


        public void setLightState(LightState lightState)
        {
            this.lightState = lightState;
        }

        public void moveCars()
        {
            this.carsCount = lightState.moveCars(this.carsCount);
        }

        public string reportStatus()
        {
            return displayName + " = " + carsCount + "; ";
        }

        public void changeSignal()
        {
            this.lightState = lightState.changeSignal();
        }
    }
}
