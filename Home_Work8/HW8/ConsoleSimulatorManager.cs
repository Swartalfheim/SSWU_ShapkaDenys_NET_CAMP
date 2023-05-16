using Task_1.Enums;
using Task_1.Interfaces;

namespace Task_1
{
    public class ConsoleSimulatorManager : ISimulatorVisualizer
    {
        public ConsoleSimulatorManager()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Manager = new SimulatorManager(
                new CrossroadSimulator(),
                () =>
                {
                    Console.WriteLine("Елементи Управління:");
                    Console.WriteLine("Esc - зупинити симуляцію");
                    Console.WriteLine("P - пауза/продовжити");
                    Console.WriteLine("D - показати дані світлофора");
                    Console.WriteLine("C - змінити тривалість стану світлофора (ПАУЗА МОДЕЛЮВАННЯ ПЕРЕД ПРОДОВЖЕННЯМ)");
                },
                () =>
                {
                    Console.WriteLine("Моделювання зупинено");
                },
                () =>
                {
                    Console.WriteLine();
                },
                (state) =>
                {
                    if (state)
                    {
                        Console.WriteLine("Продовжити моделювання");
                    }
                    else
                    {
                        Console.WriteLine("Моделювання призупинено");
                    }
                },
                (trafficLight) =>
                {
                    Console.Write($"[{trafficLight.TrafficDirection}: ");
                    for (int i = 0; i < trafficLight.ControlledDirections.Count; i++)
                    {
                        Console.Write($"{trafficLight.ControlledDirections[i]}");
                        if (i < trafficLight.ControlledDirections.Count - 1)
                        {
                            Console.Write(", ");
                        }
                        else
                        {
                            Console.Write(" - ");
                        }
                    }

                    switch (trafficLight.State)
                    {
                        case TrafficLightStates.Red:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case TrafficLightStates.Yellow:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case TrafficLightStates.Green:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                    }

                    Console.Write(trafficLight.State);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("] ");
                });
        }

        public ISimulatorManager Manager { get; private set; }
        public void Simulate()
        {
            Manager.Start(1);
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.WriteLine();
                switch (key)
                {
                    case ConsoleKey.P:
                        Manager.Pause();
                        break;
                    case ConsoleKey.D:
                        PrintTrafficLightData();
                        break;
                    case ConsoleKey.C:
                        ChangeTrafficLightStateDuration();
                        break;
                }
            }

            Manager.Stop();
        }

        public void PrintTrafficLightData()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            foreach (IRoad road in Manager.GetRoads())
            {
                foreach (IRoadLane lane in road.Lanes)
                {
                    if (lane.TrafficLights != null)
                    {
                        foreach (ITrafficLight trafficLight in lane.TrafficLights)
                        {
                            Console.Write(
                                $"Номер: {trafficLight.Id}, " +
                                $"Напрям руху: {trafficLight.TrafficDirection}, " +
                                $"Контролер напряму: ");
                            for (int i = 0; i < trafficLight.ControlledDirections.Count; i++)
                            {
                                Console.Write($"{trafficLight.ControlledDirections[i]}, ");
                            }

                            Console.WriteLine(
                                $"Тривалість стану: [Червоний: {trafficLight.StateDurations[TrafficLightStates.Red]}, " +
                                $"Жовтий: {trafficLight.StateDurations[TrafficLightStates.Yellow]}, " +
                                $"Зелений: {trafficLight.StateDurations[TrafficLightStates.Green]}]");
                        }
                    }
                }
            }
        }

        public void ChangeTrafficLightStateDuration()
        {
            PrintTrafficLightData();
            Console.WriteLine("\nВведіть дані так: id стан (1 - червоний, 2 - жовтий, 3 - зелений) продолжительность");
            Console.WriteLine("Приклад: 1 1 20");
            try
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int state = Convert.ToInt32(data[1]) - 1;
                if (state < 0 || state > 2)
                {
                    throw new Exception("Стан не знайдено");
                }

                Console.WriteLine(Manager.ChangeTrafficLightStateDuration(Convert.ToInt32(data[0]), (TrafficLightStates)state, Convert.ToInt32(data[2])));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
