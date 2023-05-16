using Task_1.Enums;

namespace Task_1.Interfaces
{
    public interface ISimulatorManager : ITimer
    {
        List<IRoad> GetRoads();
        void AddRoad(IRoad road);
        bool AddRoadLane(int roadId, IRoadLane lane);
        bool AddTrafficLight(int roadId, int laneId, ITrafficLight trafficLight);
        string ChangeTrafficLightStateDuration(int id, TrafficLightStates state, int duration);
    }
}
