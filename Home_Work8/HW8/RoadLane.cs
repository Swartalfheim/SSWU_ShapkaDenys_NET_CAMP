using Task_1.Interfaces;

namespace Task_1
{
    public class RoadLane : IRoadLane
    {
        public RoadLane(int id, string trafficDirection)
        {
            Id = id;
            TrafficDirection = trafficDirection;
        }

        public int Id { get; private set; }
        public List<ITrafficLight>? TrafficLights { get; private set; }
        public string TrafficDirection { get; private set; }
        public void AddTrafficLight(ITrafficLight trafficLight)
        {
            TrafficLights ??= new List<ITrafficLight>();
            TrafficLights.Add(trafficLight);
        }

        public ITrafficLight? GetTrafficLight(int id)
        {
            return TrafficLights?.FirstOrDefault(l => l.Id == id);
        }

        public object Clone()
        {
            return new RoadLane(Id, TrafficDirection);
        }
    }
}
