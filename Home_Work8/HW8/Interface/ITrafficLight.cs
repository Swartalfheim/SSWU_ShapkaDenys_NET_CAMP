using Task_1.Enums;

namespace Task_1.Interfaces
{
    public interface ITrafficLight : ICloneable
    {
        event Action<ITrafficLight>? OnUpdate;
        event Action? OnStateSwitch;
        int Id { get; }
        string TrafficDirection { get; }
        List<TrafficLightDirections> ControlledDirections { get; }
        Dictionary<TrafficLightStates, int> StateDurations { get; }
        TrafficLightStates State { get; }
        int Timer { get; }
        void Update(int time);
        void SwitchState();
        bool ChangeStateDuration(TrafficLightStates state, int duration);
    }
}
