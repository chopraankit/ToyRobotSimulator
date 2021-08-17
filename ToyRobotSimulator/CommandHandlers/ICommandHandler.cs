namespace ToyRobotSimulator.CommandHandlers
{
    public interface ICommandHandler
    {
        /// <summary>
        /// Handles command to place, move, turn.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string HandleCommand(string[] input);
    }
}