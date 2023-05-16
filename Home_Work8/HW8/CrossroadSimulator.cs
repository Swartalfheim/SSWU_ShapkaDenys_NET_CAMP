using System.Timers;
using Task_1.Interfaces;

namespace Task_1
{
    public class CrossroadSimulator : ICrossroadSimulator
    {
        private System.Timers.Timer? _timer;
        public CrossroadSimulator()
        {
            Roads = new List<IRoad>();
        }

        public event Action? OnStart;
        public event Action? OnStop;
        public event Action? OnUpdate;
        public event Action<bool>? OnPause;
        public List<IRoad> Roads { get; private set; }
        public void AddRoad(IRoad road)
        {
            Roads.Add(road);
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
            foreach (IRoad road in Roads)
            {
                foreach (IRoadLane lane in road.Lanes)
                {
                    if (lane.TrafficLights != null)
                    {
                        foreach (ITrafficLight trafficLight in lane.TrafficLights)
                        {
                            trafficLight.Update((int)(_timer.Interval / 1000));
                        }
                    }
                }
            }

            OnUpdate?.Invoke();
        }
    }
}
