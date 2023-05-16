namespace Task_1.Interfaces
{
    public interface ISimulatorVisualizer
    {
        ISimulatorManager Manager { get; }
        void Simulate();
        void PrintTrafficLightData();
        void ChangeTrafficLightStateDuration();
    }
}
