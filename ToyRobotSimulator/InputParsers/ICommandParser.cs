using ToyRobotSimulator.ToyRobot;

namespace ToyRobotSimulator.Validator
{
    public interface ICommandParser
    {
        /// <summary>
        /// Validates and parses the input command.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Command ParseCommand(string[] input);
        /// <summary>
        /// Validates and parses the place command.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="robotOnTheTable"></param>
        /// <param name="lastDirection"></param>
        /// <returns></returns>
        PlaceCommandParameters ParsePlaceCommandParameter(string[] input, bool robotOnTheTable, Direction lastDirection);
    }
}