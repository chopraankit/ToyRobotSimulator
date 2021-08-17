using ToyRobotSimulator.ToyRobot;

namespace ToyRobotSimulator.TableTop
{
    public interface ITableTop
    {
        /// <summary>
        /// Checks if the placement is valid.
        /// </summary>
        /// <param name="placement"></param>
        /// <returns></returns>
        bool IsPlacementValid(Placement placement);
    }
}