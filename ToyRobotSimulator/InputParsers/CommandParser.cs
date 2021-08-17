using System;
using ToyRobotSimulator.ToyRobot;

namespace ToyRobotSimulator.Validator
{
    public class CommandParser : ICommandParser
    {
        public Command ParseCommand(string[] input)
        {
            if (input == null)
                throw new ArgumentNullException("Command");

            if (input.Length == 0)
                throw new ArgumentException("Command is empty.");

            if (!Enum.TryParse(input[0], true, out Command command))
            {
                throw new ArgumentException("Invalid command. Please try again with the following format: PLACE X,Y,DIRECTION, MOVE, LEFT, RIGHT, REPORT");
            }
            return command;
        }

        public PlaceCommandParameters ParsePlaceCommandParameter(string[] input, bool robotOnTheTable, Direction lastDirection)
        {
            var placeCommandValidator = new PlaceCommandParser();

            return placeCommandValidator.ValidateAndParseParams(input, robotOnTheTable, lastDirection);
        }
    }
}
