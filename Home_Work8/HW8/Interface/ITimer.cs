namespace Task_1.Interfaces
{
    public interface ITimer
    {
        void Start(int interval);
        void Stop();
        void Pause();
    }
}
