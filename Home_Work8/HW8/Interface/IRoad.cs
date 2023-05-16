namespace Task_1.Interfaces
{
    public interface IRoad : ICloneable
    {
        int Id { get; }
        List<IRoadLane> Lanes { get; }
        void AddLane(IRoadLane lane);
    }
}
