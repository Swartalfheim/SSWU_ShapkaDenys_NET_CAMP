using Task_1.Enums;
using Task_1.Interfaces;

namespace Task_1
{
    // світлофор як група вогнів (або вогні з 3 станами в однині), які можна розмістити на стовпі, висіти над дорогами тощо.
    public class TrafficLight : ITrafficLight
    {
        private static int _nextId = 1;
        private TrafficLightStates _nextState;
        public TrafficLight(string trafficDirection, List<TrafficLightDirections> controlledDirections, int redDuration, int yellowDuration, int greenDuration, TrafficLightStates startState)
        {
            Id = _nextId++;
            TrafficDirection = trafficDirection;
            ControlledDirections = controlledDirections;
            StateDurations = new Dictionary<TrafficLightStates, int>();
            StateDurations.Add(TrafficLightStates.Red, redDuration > 0 ? redDuration : 1);
            StateDurations.Add(TrafficLightStates.Yellow, yellowDuration > 0 ? yellowDuration : 1);
            StateDurations.Add(TrafficLightStates.Green, greenDuration > 0 ? greenDuration : 1);
            State = startState; // Червоний чи зелений
            Timer = StateDurations[State];
            _nextState = startState == TrafficLightStates.Red ? TrafficLightStates.Green : TrafficLightStates.Red;
        }

        public event Action<ITrafficLight>? OnUpdate;
        public event Action? OnStateSwitch;
        public int Id { get; private set; }
        public string TrafficDirection { get; private set; }
        public List<TrafficLightDirections> ControlledDirections { get; private set; }
        public Dictionary<TrafficLightStates, int> StateDurations { get; private set; }
        public TrafficLightStates State { get; private set; }
        public int Timer { get; private set; }
        public void Update(int time)
        {
            Timer -= time;
            if (Timer <= 0)
            {
                SwitchState();
            }

            OnUpdate?.Invoke(this);
        }

        public void SwitchState()
        {
            switch (State)
            {
                case TrafficLightStates.Red:
                case TrafficLightStates.Green:
                    State = TrafficLightStates.Yellow;
                    break;
                case TrafficLightStates.Yellow:
                    State = _nextState;
                    _nextState = _nextState == TrafficLightStates.Red ? TrafficLightStates.Green : TrafficLightStates.Red;
                    break;
            }

            Timer = StateDurations[State];
            OnStateSwitch?.Invoke();
        }

        public bool ChangeStateDuration(TrafficLightStates state, int duration)
        {
            if (duration > 0)
            {
                StateDurations[state] = duration;
                return true;
            }

            return false;
        }

        public object Clone()
        {
            TrafficLight clone = new TrafficLight(
                TrafficDirection,
                new List<TrafficLightDirections>(ControlledDirections),
                StateDurations[TrafficLightStates.Red],
                StateDurations[TrafficLightStates.Yellow],
                StateDurations[TrafficLightStates.Green],
                State);
            clone.Id = Id;
            _nextId--;
            return clone;
        }
    }
}
