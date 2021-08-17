using ToyRobotSimulator.TableTop;
using ToyRobotSimulator.ToyRobot;
using ToyRobotSimulator.Validator;

namespace ToyRobotSimulator.CommandHandlers
{
    public class CommandHandler : ICommandHandler
    {
        private IRobot _robot;
        private ITableTop _tableTop;
        private ICommandParser _commandParser;
        private bool robotOnTheTable;

        public CommandHandler(IRobot robot, ITableTop tableTop, ICommandParser commandParser)
        {
            _robot = robot;
            _tableTop = tableTop;
            _commandParser = commandParser;
        }

        public string HandleCommand(string[] input)
        {
            var command = _commandParser.ParseCommand(input);

            if (command != Command.Place && _robot.Placement == null)
                return "Command Discarded. Robot has not yet been placed on the table.";

            switch (command)
            {
                case Command.Place:

                    var placeCommandParameter = _commandParser.ParsePlaceCommandParameter(input, robotOnTheTable, _robot.Direction);

                    // If requested position is out of bounds, display error.
                    if (!_tableTop.IsPlacementValid(placeCommandParameter.Placement))
                    {
                        return "Command Discarded. Requested placement out of bounds.";
                    }

                    _robot.Place(placeCommandParameter.Placement, placeCommandParameter.Direction);

                    robotOnTheTable = true;

                    break;

                case Command.Move:
                    var newPosition = _robot.GetNextPosition();
                    if (_tableTop.IsPlacementValid(newPosition))
                        _robot.Placement = newPosition;
                    break;

                case Command.Right:
                    _robot.RotateRight();
                    break;

                case Command.Left:
                    _robot.RotateLeft();
                    break;

                case Command.Report:
                    return _robot.GetReport();
            }
            return string.Empty;
        }

    }
}
