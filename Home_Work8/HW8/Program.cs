using Task_1.Enums;
using Task_1.Interfaces;

namespace Task_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ISimulatorVisualizer simulator = new ConsoleSimulatorManager();
            simulator.Manager.AddRoad(
                new Road(
                    new List<IRoadLane>()
                    {
                        new RoadLane(1, "Північ-Південь"),
                        new RoadLane(2, "Північ-Південь"),
                        new RoadLane(3, "Південь-Північ"),
                        new RoadLane(4, "Південь-Північ")
                    }));
            simulator.Manager.AddRoad(
                new Road(
                    new List<IRoadLane>()
                    {
                        new RoadLane(1, "Схід-Захід"),
                        new RoadLane(2, "Схід-Захід"),
                        new RoadLane(3, "Захід-Схід"),
                        new RoadLane(4, "Захід-Схід")
                    }));
            simulator.Manager.AddTrafficLight(
                1,
                1,
                new TrafficLight(
                    "Північ-Південь",
                    new List<TrafficLightDirections>() { TrafficLightDirections.Straight },
                    10,
                    1,
                    10,
                    TrafficLightStates.Green));
            simulator.Manager.AddTrafficLight(
                1,
                1,
                new TrafficLight(
                    "Північ-Південь",
                    new List<TrafficLightDirections>() { TrafficLightDirections.Right },
                    10,
                    1,
                    10,
                    TrafficLightStates.Red));
            simulator.Manager.AddTrafficLight(
                1,
                3,
                new TrafficLight(
                    "Південь-Північ",
                    new List<TrafficLightDirections>() { TrafficLightDirections.Straight },
                    10,
                    1,
                    10,
                    TrafficLightStates.Green));
            simulator.Manager.AddTrafficLight(
                1,
                3,
                new TrafficLight(
                    "Південь-Північ",
                    new List<TrafficLightDirections>() { TrafficLightDirections.Right },
                    10,
                    1,
                    10,
                    TrafficLightStates.Red));

            simulator.Manager.AddTrafficLight(
                2,
                1,
                new TrafficLight(
                    "Захід-Схід",
                    new List<TrafficLightDirections>() { TrafficLightDirections.Straight },
                    10,
                    1,
                    10,
                    TrafficLightStates.Red));
            simulator.Manager.AddTrafficLight(
                2,
                1,
                new TrafficLight(
                    "Захід-Схід",
                    new List<TrafficLightDirections>() { TrafficLightDirections.Right },
                    10,
                    1,
                    10,
                    TrafficLightStates.Green));
            simulator.Manager.AddTrafficLight(
                2,
                3,
                new TrafficLight(
                    "Схід-Захід",
                    new List<TrafficLightDirections>() { TrafficLightDirections.Straight },
                    10,
                    1,
                    10,
                    TrafficLightStates.Red));
            simulator.Manager.AddTrafficLight(
                2,
                3,
                new TrafficLight(
                    "Схід-Захід",
                    new List<TrafficLightDirections>() { TrafficLightDirections.Right },
                    10,
                    1,
                    10,
                    TrafficLightStates.Green));
            simulator.Simulate();
        }
    }
}