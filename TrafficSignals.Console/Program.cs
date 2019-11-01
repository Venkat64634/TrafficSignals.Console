using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSignals.Console.Models;
using TrafficSignals.Console.Signal;

namespace TrafficSignals.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Road> roads;
                roads = new List<Road>();
                roads.Add(new Road("Snell Road", Constants.NORTH, "N"));
                roads.Add(new Road("Snell Road", Constants.SOUTH, "S"));
                roads.Add(new Road("Weaver Road", Constants.EAST, "E"));
                roads.Add(new Road("Weaver Road", Constants.WEST, "W"));

                Intersection intersection = IntersectionFactory.createIntersection("NSEW", roads);
                intersection.startSignal();
                System.Console.ReadLine();
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
            }
        }
    }
}
