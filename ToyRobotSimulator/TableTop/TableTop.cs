using ToyRobotSimulator.ToyRobot;

namespace ToyRobotSimulator.TableTop
{
    public class TableTop : ITableTop
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public TableTop(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        public bool IsPlacementValid(Placement placement)
        {
            return placement.X >= 0 && placement.X < Columns
                   && placement.Y >= 0 && placement.Y < Rows;
        }
    }
}
