using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    // світлофор як група вогнів (або вогні з 3 станами в однині), які можна розмістити на стовпі, висіти над дорогами тощо.
    public class TrafficLight : ICloneable
    {
        private static int _nextId = 1;
        private TrafficLightState _nextState;
        public TrafficLight(string trafficDirection, int redDuration, int yellowDuration, int greenDuration, TrafficLightState startState)
        {
            Id = _nextId++;
            TrafficDirection = trafficDirection;
            StateDurations = new Dictionary<TrafficLightState, int>();
            StateDurations.Add(TrafficLightState.Red, redDuration > 0 ? redDuration : 1);
            StateDurations.Add(TrafficLightState.Yellow, yellowDuration > 0 ? yellowDuration : 1);
            StateDurations.Add(TrafficLightState.Green, greenDuration > 0 ? greenDuration : 1);
            State = startState; // червоне чи зелене
            Timer = StateDurations[State];
            _nextState = startState == TrafficLightState.Red ? TrafficLightState.Green : TrafficLightState.Red;
        }

        public event Action? OnUpdate;
        public event Action? OnStateSwitch;
        public int Id { get; private set; }
        public string TrafficDirection { get; private set; }
        public Dictionary<TrafficLightState, int> StateDurations { get; private set; }
        public TrafficLightState State { get; private set; }
        public int Timer { get; private set; }
        public void Update(int time)
        {
            Timer -= time;
            if (Timer <= 0)
            {
                SwitchState();
            }

            OnUpdate?.Invoke();
        }

        public void SwitchState()
        {
            switch (State)
            {
                case TrafficLightState.Red:
                case TrafficLightState.Green:
                    State = TrafficLightState.Yellow;
                    break;
                case TrafficLightState.Yellow:
                    State = _nextState;
                    _nextState = _nextState == TrafficLightState.Red ? TrafficLightState.Green : TrafficLightState.Red;
                    break;
            }

            Timer = StateDurations[State];
            OnStateSwitch?.Invoke();
        }

        public bool ChangeStateDuration(TrafficLightState state, int duration)
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
                StateDurations[TrafficLightState.Red],
                StateDurations[TrafficLightState.Yellow],
                StateDurations[TrafficLightState.Green],
                State);
            clone.Id = Id;
            _nextId--;
            return clone;
        }
    }
}
