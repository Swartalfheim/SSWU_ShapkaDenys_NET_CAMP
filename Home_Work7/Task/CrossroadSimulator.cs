using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Task
{
    public class CrossroadSimulator
    {
        private System.Timers.Timer? _timer;
        public CrossroadSimulator()
        {
            TrafficLights = new List<TrafficLight>();
        }

        public event Action? OnStart;
        public event Action? OnStop;
        public event Action? OnUpdate;
        public event Action<bool>? OnPause;
        public List<TrafficLight> TrafficLights { get; private set; }
        public void AddTrafficLight(TrafficLight trafficLight)
        {
            TrafficLights.Add((TrafficLight)trafficLight.Clone());
        }

        public TrafficLight? GetTrafficLight(int id)
        {
            return TrafficLights.FirstOrDefault(l => l.Id == id);
        }

        public void ChangeTrafficLightStateDuration(int id, TrafficLightState state, int duration)
        {
            GetTrafficLight(id)?.ChangeStateDuration(state, duration);
        }

        public void Start(int interval)
        {
            OnStart?.Invoke();
            _timer = new System.Timers.Timer(interval * 1000);
            _timer.Elapsed += OnElapsed;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        public void Stop()
        {
            _timer?.Stop();
            _timer?.Dispose();
            OnStop?.Invoke();
        }

        public void Pause()
        {
            if (_timer != null)
            {
                _timer.Enabled = !_timer.Enabled;
                OnPause?.Invoke(_timer.Enabled);
            }
        }

        private void OnElapsed(object source, ElapsedEventArgs e)
        {
            foreach (TrafficLight trafficLight in TrafficLights)
            {
                trafficLight.Update((int)(_timer.Interval / 1000));
            }

            OnUpdate?.Invoke();
        }
    }
}
