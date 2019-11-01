using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSignals.Console.Models;

namespace TrafficSignals.Console.Signal
{
    public interface Intersection
    {
        void changeSignal();

        void populateSignals(List<Road> roads);

        string reportStatus();

        void startSignal();
    }
}
