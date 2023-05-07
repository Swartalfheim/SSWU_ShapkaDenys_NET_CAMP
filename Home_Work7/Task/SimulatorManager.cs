using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class SimulatorManager
    {
        private readonly CrossroadSimulator _crossroadSimulator;
        public SimulatorManager()
        {
            _crossroadSimulator = new CrossroadSimulator();
            _crossroadSimulator.OnStart += () =>
            {
                Console.WriteLine("Елементи керування:");
                Console.WriteLine("Esc - зупинити моделювання");
                Console.WriteLine("P - пауза/продовження");
                Console.WriteLine("D - показати данi свiтлофора");
                Console.WriteLine("C - змiнити тривалiсть стану свiтлофора (призупинiть симуляцiю перед продовженням)");
            };
            _crossroadSimulator.OnStop += () => { Console.WriteLine("Симуляцію зупинено"); };
            _crossroadSimulator.OnUpdate += () => { Console.WriteLine(); };
            _crossroadSimulator.OnPause += (bool state) =>
            {
                if (state)
                {
                    Console.WriteLine("Симуляція триває");
                }
                else
                {
                    Console.WriteLine("Симуляцію призупинено");
                }
            };
        }

        public void Simulate(int interval)
        {
            _crossroadSimulator.Start(interval);
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
                        _crossroadSimulator.Pause();
                        break;
                    case ConsoleKey.D:
                        PrintTrafficLightData();
                        break;
                    case ConsoleKey.C:
                        ChangeTrafficLightStateDuration();
                        break;
                }
            }

            _crossroadSimulator.Stop();
        }

        public void AddTrafficLight(TrafficLight trafficLight)
        {
            _crossroadSimulator.AddTrafficLight(trafficLight);
            TrafficLight? light = _crossroadSimulator.GetTrafficLight(trafficLight.Id);
            if (light != null)
            {
                light.OnUpdate += () =>
                {
                    Console.Write($"[{light.TrafficDirection} - ");
                    switch (light.State)
                    {
                        case TrafficLightState.Red:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case TrafficLightState.Yellow:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case TrafficLightState.Green:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                    }

                    Console.Write(light.State);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("] ");
                };
            }
        }

        public void PrintTrafficLightData()
        {
            foreach (TrafficLight trafficLight in _crossroadSimulator.TrafficLights)
            {
                Console.WriteLine(
                    $"Id: {trafficLight.Id}, " +
                    $"Напрямок руху: {trafficLight.TrafficDirection}, " +
                    $"Тривалiсть стану: [Red: {trafficLight.StateDurations[TrafficLightState.Red]}, " +
                    $"Жовтий: {trafficLight.StateDurations[TrafficLightState.Yellow]}, " +
                    $"Зелений: {trafficLight.StateDurations[TrafficLightState.Green]}]");
            }
        }

        public bool ChangeTrafficLightStateDuration()
        {
            PrintTrafficLightData();
            Console.WriteLine("\nВведіть такі данi: стан iдентифікатора (1 - червоний, 2 - жовтий, 3 - зелений) тривалiсть");
            Console.WriteLine("Приклад: 1 1 20");
            try
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                TrafficLight? trafficLight = _crossroadSimulator.GetTrafficLight(Convert.ToInt32(data[0]));
                if (trafficLight == null)
                {
                    Console.WriteLine("Світлофор не знайдено");
                    return false;
                }

                int state = Convert.ToInt32(data[1]) - 1;
                if (state < 0 || state > 2)
                {
                    Console.WriteLine("Стан не знайдено");
                    return false;
                }

                trafficLight.ChangeStateDuration((TrafficLightState)state, Convert.ToInt32(data[2]));
                Console.WriteLine("Дані успішно змінено");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
