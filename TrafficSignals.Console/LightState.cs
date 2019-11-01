using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSignals.Console
{
    public interface LightState
    {
        int moveCars(int carsCount);

        LightState changeSignal();
    }
}
