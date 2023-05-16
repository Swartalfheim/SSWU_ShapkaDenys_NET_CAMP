using Task_1.Interfaces;

namespace Task_1
{
    public class Road : IRoad
    {
        private static int _nextId = 1;
        public Road(List<IRoadLane> lanes)
        {
            Id = _nextId++;
            Lanes = lanes;
        }

        public int Id { get; private set; }
        public List<IRoadLane> Lanes { get; private set; }
        public void AddLane(IRoadLane lane)
        {
            Lanes.Add(lane);
        }

        public object Clone()
        {
            Road clone = new Road(new List<IRoadLane>(Lanes));
            clone.Id = Id;
            _nextId--;
            return clone;
        }
    }
}
