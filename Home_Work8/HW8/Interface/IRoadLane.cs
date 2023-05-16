namespace Task_1.Interfaces
{
    public interface IRoadLane : ICloneable
    {
        int Id { get; }
        List<ITrafficLight>? TrafficLights { get; }
        string TrafficDirection { get; }
        void AddTrafficLight(ITrafficLight trafficLight);
        ITrafficLight? GetTrafficLight(int id);
    }
}
