namespace Task_1.Interfaces
{
    public interface ICrossroadSimulator : ITimer
    {
        event Action? OnStart;
        event Action? OnStop;
        event Action? OnUpdate;
        event Action<bool>? OnPause;
        public List<IRoad> Roads { get; }
        void AddRoad(IRoad road);
    }
}
