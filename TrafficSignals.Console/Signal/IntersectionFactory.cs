using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSignals.Console.Models;

namespace TrafficSignals.Console.Signal
{
    public class IntersectionFactory
    {
        public static Intersection createIntersection(string roadsType, List<Road> roads)
        {
            Intersection intersection = null;
            if (roadsType.ToUpper() == "NSEW")
            {
                intersection = new NSEWIntersection();
                intersection.populateSignals(roads);
            }
            return intersection;
        }
    }
}
