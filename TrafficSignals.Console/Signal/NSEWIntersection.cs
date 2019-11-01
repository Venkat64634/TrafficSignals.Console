using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrafficSignals.Console.Models;

namespace TrafficSignals.Console.Signal
{
    public class NSEWIntersection : Intersection
    {
        private Dictionary<int, List<Road>> roadMap;
        private int currentRoadMap;
        private int timer;


        public NSEWIntersection()
        {
            this.currentRoadMap = 1;
            this.timer = -1;
        }

        public void populateSignals(List<Road> roads)
        {
            int MAX_ROADS = 4;
            if (roads == null || roads.Count != MAX_ROADS) {
                throw new ArgumentNullException("Not Enough Roads");
            }

            roadMap = new Dictionary<int, List<Road>>();
            List<Road> roadMapList;
            int index = 1;
            foreach (Road road in roads) {
                if (road.getDirection().ToUpper() == (Constants.NORTH) || road.getDirection().ToUpper() == (Constants.SOUTH)) {
                    roadMapList = !roadMap.ContainsKey(index) ? new List<Road>() : roadMap[index];
                    road.setLightState(new GreenLightState(Constants.GREEN_MAX_TIME));
                    roadMapList.Add(road);
                    roadMap.Add(index, roadMapList);
                    index++;
                }
                else if (road.getDirection().ToUpper() == (Constants.EAST) || road.getDirection().ToUpper() == (Constants.WEST)) {
                    roadMapList = !roadMap.ContainsKey(index) ? new List<Road>() : roadMap[index];
                    road.setLightState(new RedLightState(Constants.SIGNAL_RESET));
                    roadMapList.Add(road);
                    roadMap.Add(index, roadMapList);
                    index++;
                }
            }
        }

        public void changeSignal()
        {
            if (timer == Constants.GREEN_MAX_TIME)
            {
                var currRoadMap = roadMap[currentRoadMap];
                foreach (var eachRoad in currRoadMap) {
                    changeSignal();
                }
            }
            if (timer == (Constants.GREEN_MAX_TIME + Constants.RED_MAX_TIME))
            {
                currentRoadMap = currentRoadMap == 1 ? 2 : 1;
                var currRoadMap = roadMap[currentRoadMap];
                foreach (var eachRoad in currRoadMap)
                {
                    changeSignal();
                };
                timer = Constants.SIGNAL_RESET;
            }
            timer++;

            foreach (var eachItem in roadMap) {
                foreach (var eachValue in eachItem.Value) {
                    eachValue.moveCars();
                }
            }
        }

        public string reportStatus()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int key in roadMap.Keys)
            {
                foreach (Road road in roadMap[key])
                {
                    sb.Append(road.reportStatus());
                }
            }
            return sb.ToString();
        }

        public void startSignal()
        {
            try
            {
                int i = 0;
                while (i < Constants.MAX_REPEATS)
                {
                    changeSignal();
                    System.Console.WriteLine(i + ": " + reportStatus());
                    i++;
                    Thread.Sleep(Constants.THREAD_SLEEP_TIME);
                }
            }
            catch (Exception ex)
            {
               string errormessage =  ex.Message;
            }
        }
    }
}
