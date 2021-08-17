namespace ToyRobotSimulator.ToyRobot
{
    public interface IRobot
    {
        Placement Placement { get; set; }
        Direction Direction { get; set; }
        Placement GetNextPosition();
        string GetReport();
        void Move(Placement placement);
        void Place(Placement placement, Direction direction);
        void RotateLeft();
        void RotateRight();
    }
}