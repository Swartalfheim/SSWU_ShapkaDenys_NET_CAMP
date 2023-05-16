using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8
{
    public class TrafficLight
    {
        public TrafficLight()
        {
            StateDurations = new Dictionary<TrafficLightState, int>();
            StateDurations.Add(TrafficLightState.Red, 0);
            StateDurations.Add(TrafficLightState.Yellow, 1);
            StateDurations.Add(TrafficLightState.Green, 2);
        }

        public delegate void State(string message);
        public event State EventState;
        public Dictionary<TrafficLightState, int> StateDurations { get; set; }

        public void SvichState()
        {
        }
    }
}
