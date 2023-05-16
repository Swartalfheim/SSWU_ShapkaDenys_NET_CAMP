using Task_1.Enums;
using Task_1.Interfaces;

namespace Task_1
{
    public class SimulatorManager : ISimulatorManager
    {
        private readonly ICrossroadSimulator _crossroadSimulator;
        private readonly Action<ITrafficLight> _onTrafficLightUpdate;
        public SimulatorManager(ICrossroadSimulator crossroadSimulator, Action onSimulatorStart, Action onSimulatorStop, Action onSimulatorUpdate, Action<bool> onSimulatorPause, Action<ITrafficLight> onTrafficLightUpdate)
        {
            _crossroadSimulator = crossroadSimulator;
            _crossroadSimulator.OnStart += onSimulatorStart;
            _crossroadSimulator.OnStop += onSimulatorStop;
            _crossroadSimulator.OnUpdate += onSimulatorUpdate;
            _crossroadSimulator.OnPause += onSimulatorPause;
            _onTrafficLightUpdate = onTrafficLightUpdate;
        }

        public void Start(int interval)
        {
            _crossroadSimulator.Start(interval);
        }

        public void Stop()
        {
            _crossroadSimulator.Stop();
        }

        public void Pause()
        {
            _crossroadSimulator.Pause();
        }

        public List<IRoad> GetRoads()
        {
            return _crossroadSimulator.Roads;
        }

        public void AddRoad(IRoad road)
        {
            _crossroadSimulator.AddRoad((IRoad)road.Clone());
        }

        public bool AddRoadLane(int roadId, IRoadLane lane)
        {
            IRoad? road = _crossroadSimulator.Roads.FirstOrDefault(r => r.Id == roadId);
            if (road == null)
            {
                return false;
            }

            road.AddLane((IRoadLane)lane.Clone());
            return true;
        }

        public bool AddTrafficLight(int roadId, int laneId, ITrafficLight trafficLight)
        {
            IRoad? road = _crossroadSimulator.Roads.FirstOrDefault(r => r.Id == roadId);
            if (road == null)
            {
                return false;
            }

            IRoadLane? lane = road.Lanes.FirstOrDefault(l => l.Id == laneId);
            if (lane == null)
            {
                return false;
            }

            lane.AddTrafficLight((ITrafficLight)trafficLight.Clone());
            ITrafficLight? light = lane.TrafficLights?.FirstOrDefault(l => l.Id == trafficLight.Id);
            if (light != null)
            {
                light.OnUpdate += _onTrafficLightUpdate;
            }

            return true;
        }

        public string ChangeTrafficLightStateDuration(int id, TrafficLightStates state, int duration)
        {
            ITrafficLight? trafficLight = _crossroadSimulator.Roads.
                SelectMany(r => r.Lanes).
                Where(l => l.TrafficLights != null).
                SelectMany(l => l.TrafficLights).
                FirstOrDefault(t => t.Id == id);
            if (trafficLight == null)
            {
                return "Світлофор не знайдено";
            }

            bool result = trafficLight.ChangeStateDuration(state, duration);
            if (result)
            {
                return "Дані успішно змінено";
            }
            else
            {
                return "Дані не змінено";
            }
        }
    }
}
