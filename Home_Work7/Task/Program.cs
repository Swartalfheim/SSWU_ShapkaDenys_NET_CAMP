namespace Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SimulatorManager simulator = new SimulatorManager();
            simulator.AddTrafficLight(new TrafficLight("Пiвнiч-Пiвдень", 10, 1, 10, TrafficLightState.Green));
            simulator.AddTrafficLight(new TrafficLight("Пiвдень-Пiвнiч", 10, 1, 10, TrafficLightState.Green));
            simulator.AddTrafficLight(new TrafficLight("Схiд-Захiд", 10, 1, 10, TrafficLightState.Red));
            simulator.AddTrafficLight(new TrafficLight("Захiд-Схiд", 10, 1, 10, TrafficLightState.Red));
            simulator.Simulate(1);
        }
    }
}